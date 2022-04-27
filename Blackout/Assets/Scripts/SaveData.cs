using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;

[System.Serializable]
public class UserInfo
{
    public string sex;
    public int age, weight;
}


[System.Serializable]
public class GameData
{
    public string sex;
    public int age, weight;
    public int currentIndex = 0;
    public List<History> History = new List<History>();

}

[System.Serializable]
public class History
{
    public string dateCreated;
    public int GameTime;
    public List<Drinks> _Drinks = new List<Drinks>();
    // public int beer = 0;
    // public int wine = 0;
    // public int shot = 0;
    public double MaxPromille = 0;
    public double promille = 0;
}

[System.Serializable]
public class Drinks
{
    public int numberOfDrinks = 0;
    public Dictionary<int, string> beer = new Dictionary<int, string>();
    public Dictionary<int, string> wine = new Dictionary<int, string>();
    public Dictionary<int, string> shot = new Dictionary<int, string>();
    // public int beer = 0;
    // public int wine = 0;
    // public int shot = 0;

}
[System.Serializable]
public class Location
{

}



public class SaveData : MonoBehaviour
{
    [SerializeField] private Text _textPromille;
    private UserInfo ui;
    private GameData gameData;
    private History _history;
    private Drinks _drinks;
    private CalcController calc;
    private double promille, currentPromille;
    private DateTime startTime, currentTime;
    //private int index = 0;
    //private DateTime currentTime;
    private string timeCreated;
    public Button[] sceneButtons;


    void Awake()
    {
        calc = gameObject.AddComponent<CalcController>();

    }

    /*Start() laddar in tidigare data från två JSON filer. Skulle det vara så att programmet stängts av utan att kalla på gameOver() så kan användaren fortfarande forstätta spela på sitt
        tidigare spel. Däremot om användaren väljer att avluta sin session, kommer List<DrinkData> History att ökas med ett nytt objekt*/
    void Start()
    {
        startTime = System.DateTime.Now;
        ui = LoadUserInfo();

        if (!File.Exists(Application.persistentDataPath + "GameData.json"))
        {
            Debug.Log("file does not exsit");
        }
        else
        {
            gameData = LoadUserData();
        }
        if (gameData == null) { gameData = new GameData(); }

        if (_history == null && gameData.currentIndex == gameData.History.Count)
        {
            _history = new History();
            _drinks = new Drinks();
        }
        else
        {
            _history = gameData.History[gameData.History.Count - 1];
            _drinks = gameData.History[gameData.History.Count - 1]._Drinks[0];
        }

        timeCreated = System.DateTime.Now.ToLocalTime().ToString("dd-MM-yyyy HH:mm");

        foreach (Button btn in sceneButtons)
        {
            btn.onClick.AddListener(() => calcPromille(btn.name));
        }
    }


    /*    private void displayPromille(double promille)
{
result.text = "" + int_weight;
result.gameObject.SetActive(true);
result.text = "Din promille halt = " + System.Math.Round(promille, 2);
}*/
    void showPromilleOnSceen(double promille, double untilSober)
    {
        _textPromille.gameObject.SetActive(true);
        _textPromille.text = "Din promillehalt är cirka " + System.Math.Round(promille, 2) + ". Du förväntas vara nykter om cirka " + untilSober + "h";
        // visa promille p� sk�rm med max 2 decimaler
        // 
    }
    /*    För kvinnor:
        Alkohol i g/(kroppsvikten i kg x 60 %) - (0,15 x timmar från intagets början) = promille
        För män:
        Alkohol i g/(kroppsvikten i kg x 70 %) - (0,15 x timmar från intagets början) = promille */

    void calcPromille(string nameButton)
    {
        currentTime = System.DateTime.Now;

        /*Tid från att spelet startar till att en ny dryck adderas, detta för att beräkna currentPromille*/
        var localTimeDiffrence = (currentTime - startTime);
        int timeDiff = (int)localTimeDiffrence.TotalMinutes;

        currentPromille = _history.promille;
        double gram = getGram(nameButton);

        /*Räknar ut promillehalt i blodet först genom att ta tidigare promille - 0.15 * antal timmar som passerat. 
        Sedan addera nya promillehalt från ny dryck*/
        _history.promille += -(0.15 * timeDiff / 60);
        _history.promille += (calc.CalculatePromille(ui.sex, ui.weight, gram));
        double max = System.Math.Max(currentPromille, _history.promille);
        max = System.Math.Round(max, 2);

        double tillNykter = System.Math.Ceiling(_history.promille / 0.15);

        gameData.age = ui.age;
        gameData.weight = ui.weight;
        gameData.sex = ui.sex;
        _history.GameTime = timeDiff;
        //Debug.Log("CurrentPromille = " + currentPromille + " Promille now = " + promille);
        //Gör funktion som adderar object till List<DrinkData> drinks   loopa igenom object i listan? skriv inte över!
        if (currentPromille < 0) currentPromille = 0;

        //Debug.Log(currentPromille);

        _history.MaxPromille = max;
        //drinkData.promille = promille;
        AddDrinks(nameButton);

        //Debug.Log(gameData.History.Count);

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

        SaveDataToFile(gameData);
        showPromilleOnSceen(_history.promille, tillNykter);





    }

    public void GameOver()
    {
        gameData.currentIndex++;
        SaveDataToFile(gameData);
        SceneManager.LoadScene("Menu");
    }

    private void AddDrinks(string name)
    {
        _drinks.numberOfDrinks++;
        if (name == "Button_Beer")
        {
            _drinks.beer.Add(_drinks.numberOfDrinks, timeCreated);
            //_drinks.beer++;
        }
        else if (name == "Button_Wine")
        {
            _drinks.wine.Add(_drinks.numberOfDrinks, timeCreated);
            //_drinks.wine++;
        }
        else if (name == "Button_Shot")
        {
            _drinks.shot.Add(_drinks.numberOfDrinks, timeCreated);
            //_drinks.shot++;
        }

        //index++;


    }


    private double getGram(string name)
    {
        double gram;
        switch (name)
        {
            case "Button_Beer":
                gram = calc.TotalSumOfGram(1, 0, 0);
                break;
            case "Button_Wine":
                gram = calc.TotalSumOfGram(0, 1, 0);
                break;
            case "Button_Shot":
                gram = calc.TotalSumOfGram(0, 0, 1);
                break;
            default:
                gram = 0;
                break;
        }

        return gram;
    }

    private void SaveDataToFile(GameData gameData)
    {
        // string dataUser = JsonUtility.ToJson(gameData, true);
        try
        {
            var dataUser = JsonConvert.SerializeObject(gameData, Formatting.Indented);
            System.IO.File.WriteAllText(Application.persistentDataPath + "GameData.json", dataUser);
            //Debug.Log("Data Saved");
        }
        catch (Exception e)
        {
            Debug.Log("Data failed to save!" + e);
            throw;
        }
    }

    private UserInfo LoadUserInfo()
    {
        try
        {
            //Debug.Log("Data Loaded");
            var jsonObject = (File.ReadAllText(Application.persistentDataPath + "UserData.json"));
            var newGameData = JsonConvert.DeserializeObject<UserInfo>(jsonObject);
            return newGameData;
            //return JsonUtility.FromJson<UserInfo>(File.ReadAllText(Application.persistentDataPath + "UserData.json"));
        }
        catch (Exception e)
        {
            Debug.Log("Error To Load Data" + e);
            throw;
        }
    }
    private GameData LoadUserData()
    {
        //Debug.Log("Data Loaded");
        try
        {
            //var newPerson = JsonConvert.DeserializeObject<Person>(serializedPerson);
            var jsonObject = (File.ReadAllText(Application.persistentDataPath + "GameData.json"));
            var newGameData = JsonConvert.DeserializeObject<GameData>(jsonObject);
            return newGameData;
            //return JsonUtility.FromJson<GameData>(File.ReadAllText(Application.persistentDataPath + "GameData.json"));
        }
        catch (Exception e)
        {
            Debug.Log("Error To Load Data" + e);
            throw;
        }
    }
}
