using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    [SerializeField] private Text _textPromille;
    private UserInfo ui;
    private GameData gameData;
    private History _history;
    private Drinks _drinks;
    private CalcController calc;
    private double promille, currentPromille;
    private DateTime startTime, currentTime;
    private string timeCreated;
    public Button[] sceneButtons;
    private int currentTimeDiff = 0;
    void Awake()
    {
        calc = gameObject.AddComponent<CalcController>();
    }

    /*Start() laddar in tidigare data från två JSON filer. Skulle det vara så att programmet stängts av utan att kalla på gameOver() så kan användaren fortfarande forstätta spela på sitt
        tidigare spel. Däremot om användaren väljer att avluta sin session, kommer List<DrinkData> History att ökas med ett nytt objekt*/
    void Start()
    {
        startTime = System.DateTime.Now;
        ui = DataHandler.LoadUserData();
        //// GameActiveScript.setBoolean(true);
        if (!File.Exists(Application.persistentDataPath + "GameData.json"))
        {
            Debug.Log("file does not exsit");
        }
        else
        {
            gameData = DataHandler.LoadGameData();
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

    void showPromilleOnSceen(double promille, double untilSober)
    {
        _textPromille.gameObject.SetActive(true);
        _textPromille.text = "Din promillehalt är cirka " + System.Math.Round(promille, 2) + ". Du förväntas vara nykter om cirka " + untilSober + "h";
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
        Debug.Log(timeDiff + " ::::: " + currentTimeDiff);

        currentPromille = _history.promille;
        double gram = getGram(nameButton);
        if(timeDiff > currentTimeDiff)
        {
            timeDiff -= currentTimeDiff;
            _history.promille += -(0.15 * timeDiff);
            currentTimeDiff = timeDiff;
            //timeDiff -= currentTimeDiff;
        }

        /*Räknar ut promillehalt i blodet först genom att ta tidigare promille - 0.15 * antal timmar som passerat. 
        Sedan addera nya promillehalt från ny dryck*/
        
        _history.promille += (calc.CalculatePromille(ui.sex, ui.weight, gram));
        double max = System.Math.Max(currentPromille, _history.promille);
        max = System.Math.Round(max, 2);
        double tillNykter = System.Math.Ceiling(_history.promille / 0.15);
        gameData.age = ui.age;
        gameData.weight = ui.weight;
        gameData.sex = ui.sex;
        _history.GameTime = timeDiff;

        if (currentPromille < 0) currentPromille = 0;

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
        Debug.Log(currentPromille);
        DataHandler.SaveDataToFile(gameData);
        showPromilleOnSceen(_history.promille, tillNykter);
    }

    public void GameOver()
    {
        gameData.currentIndex++;
        DataHandler.SaveDataToFile(gameData);
        SceneManager.LoadScene("Menu");
    }

    private void AddDrinks(string name)
    {
        _drinks.numberOfDrinks++;
        if (name == "Button_Beer")
        {
            _drinks.beer.Add(_drinks.numberOfDrinks, currentTime.ToString("dd-MM-yyyy HH:mm"));
        }
        else if (name == "Button_Wine")
        {
            _drinks.wine.Add(_drinks.numberOfDrinks, currentTime.ToString("dd-MM-yyyy HH:mm"));
        }
        else if (name == "Button_Shot")
        {
            _drinks.shot.Add(_drinks.numberOfDrinks, currentTime.ToString("dd-MM-yyyy HH:mm"));
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
