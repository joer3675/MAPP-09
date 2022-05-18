using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    [SerializeField] private Text _textPromille;
    private UserData userData;
    private GameData gameData;
    private History _history;
    private Drinks _drinks;
    private CalcController calc;
    private double promille, previousPerMille;
    private int age, weight;
    private string sex;
    private DateTime startTime, currentTime;
    private string timeCreated;
    public Button[] sceneButtons;
    //private int _history.previousTimeDiff = 0;

    void Awake()
    {
        calc = gameObject.AddComponent<CalcController>();
    }

    /*Start() laddar in tidigare data från två JSON filer. Skulle det vara så att programmet stängts av utan att kalla på gameOver() så kan användaren fortfarande forstätta spela på sitt
        tidigare spel. Däremot om användaren väljer att avluta sin session, kommer List<DrinkData> History att ökas med ett nytt objekt*/
    void Start()
    {

        userData = DataHandler.LoadUserData();
        timeCreated = System.DateTime.Now.ToLocalTime().ToString("dd-MM-yyyy HH:mm");
        //// GameActiveScript.setBoolean(true);
        if (File.Exists(Application.persistentDataPath + "GameData.json"))
        {
            gameData = DataHandler.LoadGameData();
        }
        else
        {

            Debug.Log("file does not exsit");
        }
        if (gameData == null)
        {
            Debug.Log("gameData null, new gameData created");
            gameData = new GameData();
        }

        if (_history == null && gameData.currentIndex == gameData.History.Count)
        {
            PlayerPrefs.SetInt("hasStarted", 0);
            Debug.Log("New Game Started!");
            _history = new History();
            _drinks = new Drinks();
            _history.timeLastDrink = System.DateTime.Now;
        }
        else
        {
            PlayerPrefs.SetInt("hasStarted", 1);
            Debug.Log("Ongoing Session Loaded");
            _history = gameData.History[gameData.History.Count - 1];
            _drinks = gameData.History[gameData.History.Count - 1]._Drinks[0];
        }

        if (_history.promille > 0)
        {
            //Debug.Log(_history.promille);
            double currentPerMille = getPerMille();
            showPromilleOnSceen(currentPerMille, (currentPerMille / 0.15));
            _history.promille = currentPerMille;
            //showPromilleOnSceen(_history.promille, getTimeDiffrence());
        }
        // gameData.age = userData.age;
        // gameData.weight = userData.weight;
        // gameData.sex = userData.sex;
        age = userData.age;
        weight = userData.weight;
        sex = userData.sex;


        foreach (Button btn in sceneButtons)
        {
            btn.onClick.AddListener(() => calcPromille(btn.name));
        }
    }

    void showPromilleOnSceen(double promille, double untilSober)
    {
        promille = Math.Round(promille, 2);
        untilSober = Math.Round(untilSober, 2);
        Debug.Log(untilSober + " Time til sober");
        Debug.Log(promille + " permille");
        Debug.Log(Math.Round(((untilSober % 1) * 60), 2) + " Untill sober minutes");
        _textPromille.gameObject.SetActive(true);
        System.DateTime clockASober = System.DateTime.Now;
        clockASober = clockASober.Date.AddHours(clockASober.Hour + (int)untilSober).AddMinutes(clockASober.Minute + ((untilSober % 1) * 60));//(System.DateTime.Now.Hour + untilSober) % 24;
        //Debug.Log(clockASober);
        _textPromille.text = "Your Per Mille is about " + System.Math.Round(promille, 2) + ". Expected to be sober " + clockASober.ToString("HH:mm"); // "day" + toString(dddd HH:mm)
    }

    private double getPerMille()
    {
        double perMille = (_history.promille - 0.15 * getTimeDiffrence() / 60);
        // Debug.Log(perMille + " permille");
        return perMille <= 0 ? 0 : perMille;
    }

    public void calcPromille(string nameButton)
    {
        PlayerPrefs.SetInt("hasStarted", 1);
        if (_history.promille < 0) _history.promille = 0;
        /*Räknar ut promillehalt i blodet först genom att ta tidigare promille - 0.15 * antal timmar som passerat. 
        Sedan addera nya promillehalt från ny dryck*/
        double gram = getGram(nameButton);
        _history.promille += (calc.CalculatePromille(sex, weight, gram));

        double max = System.Math.Max(previousPerMille, _history.promille);
        max = System.Math.Round(max, 2);
        //double untilSober = System.Math.Ceiling(_history.promille / 0.15);

        //_history.GameTime = getTimeDiffrence();
        double timeD = getTimeDiffrence();
        if (timeD > 0 && _history.promille > 0)
        {
            _history.promille -= (0.15 * timeD / 60); // (-0.15 promille/h), timeD = antal minuter sedan senaste drickan

        }
        //double untilSober = System.Math.Ceiling(_history.promille / 0.15);
        //double untilSober = System.Math.Round((_history.promille / 0.15), 2);
        double untilSober = _history.promille / 0.15;
        Debug.Log(untilSober);
        previousPerMille = _history.promille;

        // if (previousPerMille < 0) previousPerMille = 0;

        _history.MaxPromille = max;

        AddDrinks(nameButton);

        if (gameData.History.Count <= gameData.currentIndex)
        {
            gameData.History.Add(_history);
            _history._Drinks.Add(_drinks);
        }
        else
        {
            gameData.History[gameData.History.Count - 1] = _history;
            _history._Drinks[0] = _drinks;
        }

        _history.dateCreated = timeCreated;
        _history.timeLastDrink = System.DateTime.Now.AddSeconds(-DateTime.Now.Second);   // Minus sekunder för att bara spara timmar och minuter. Sekunder blir altid satt till 0 ex 11.59.59 blir till 11.59
        DataHandler.SaveDataToFile(gameData);
        showPromilleOnSceen(_history.promille, untilSober);
    }

    public void GameOver()
    {
        if (PlayerPrefs.GetInt("hasStarted") == 1)
        {
            gameData.currentIndex++;
            DataHandler.SaveDataToFile(gameData);
            PlayerPrefs.SetInt("hasStarted", 0); ;
            SceneManager.LoadScene("Menu");
        }
    }

    private double getTimeDiffrence()
    {
        currentTime = System.DateTime.Now;

        /*Tid från att spelet startar till att en ny dryck adderas, detta för att beräkna previousPerMille*/
        TimeSpan localTimeDiffrence = (currentTime - _history.timeLastDrink);
        double timeDiff = localTimeDiffrence.Minutes;
        // previousPerMille = _history.promille;
        if (timeDiff > _history.previousTimeDiff)
        {
            timeDiff -= _history.previousTimeDiff;
            // _history.promille += -(0.15 * timeDiff / 60); // (timeDiff/60) för att få antal timmar
            // if (_history.promille < 0) { _history.promille = 0; }
            _history.previousTimeDiff = timeDiff;

        }
        return timeDiff;
    }

    private void AddDrinks(string name)
    {
        _drinks.numberOfDrinks++;
        if (name == "Button_Beer")
        {
            _drinks.drinks.Add(_drinks.numberOfDrinks + " Beer", currentTime.ToString("dd-MM-yyyy HH:mm"));
        }
        else if (name == "Button_Wine")
        {
            _drinks.drinks.Add(_drinks.numberOfDrinks + " Wine", currentTime.ToString("dd-MM-yyyy HH:mm"));
        }
        else if (name == "Button_Shot")
        {
            _drinks.drinks.Add(_drinks.numberOfDrinks + " Shot", currentTime.ToString("dd-MM-yyyy HH:mm"));
        }
    }

    private double getGram(string name)
    {
        switch (name)
        {
            case "Button_Beer":
                return calc.TotalSumOfGram(1, 0, 0);
            case "Button_Wine":
                return calc.TotalSumOfGram(0, 1, 0);
            case "Button_Shot":
                return calc.TotalSumOfGram(0, 0, 1);
            default:
                return 0;
        }
    }

}
