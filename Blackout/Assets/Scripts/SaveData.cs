using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using UnityEngine.SceneManagement;

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
    public List<History> History = new List<History>();

}

[System.Serializable]
public class History
{
    public string dateCreated;
    public int GameTime;
    public int beer = 0;
    public int wine = 0;
    public int shot = 0;
    public double MaxPromille = 0;
}

[System.Serializable]
public class Location
{

}



public class SaveData : MonoBehaviour
{
    [SerializeField] private Text textPromille;

    private UserInfo ui;
    private GameData gameData;
    //private GameData gameData = new GameData();
    private History drinkData = new History();
    public Button[] sceneButtons;
    private CalcController calc;
    private double promille;
    private double currentPromille;
    private DateTime startTime;
    private DateTime currentTime;

    void Awake()
    {
        calc = gameObject.AddComponent<CalcController>();

    }

    void Start()
    {
        startTime = System.DateTime.Now;
        drinkData.dateCreated = System.DateTime.Now.ToLocalTime().ToString("dd-MM-yyyy HH:mm");
        ui = LoadUserInfo();
        gameData = LoadUserData();
        //gameData.

        foreach (Button btn in sceneButtons)
        {
            btn.onClick.AddListener(() => calcPromille(btn.name));
        }
    }

    void showPromilleOnSceen()
    {
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

        currentPromille = promille;
        double gram = getGram(nameButton);

        /*Räknar ut promillehalt i blodet först genom att ta tidigare promille - 0.15 * antal timmar som passerat. 
        Sedan addera nya promillehalt från ny dryck*/
        promille += -(0.15 * timeDiff / 60);
        promille += (calc.CalculatePromille(ui.sex, ui.weight, gram));
        double max = System.Math.Max(currentPromille, promille);
        max = System.Math.Round(max, 2);

        double tillNykter = System.Math.Ceiling(promille / 0.15);

        gameData.age = ui.age;
        gameData.weight = ui.weight;
        gameData.sex = ui.sex;
        drinkData.GameTime = timeDiff;
        Debug.Log("CurrentPromille = " + currentPromille + " Promille now = " + promille);
        //Gör funktion som adderar object till List<DrinkData> drinks   loopa igenom object i listan? skriv inte över!
        if (currentPromille < 0) currentPromille = 0;

        Debug.Log(currentPromille);

        drinkData.MaxPromille = max;
        AddDrinks(nameButton);





    }

    public void gameOver()
    {
        gameData.History.Add(drinkData);
        SaveDataToFile(gameData);
        drinkData = new History();
        promille = 0;
        SceneManager.LoadScene("Menu");

    }

    private void AddDrinks(string name)
    {
        if (name == "Button_Beer")
        {
            drinkData.beer++;
        }
        else if (name == "Button_Wine")
        {
            drinkData.wine++;
        }
        else if (name == "Button_Shot")
        {
            drinkData.shot++;
        }

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
        string dataUser = JsonUtility.ToJson(gameData, true);
        try
        {
            System.IO.File.WriteAllText(Application.persistentDataPath + "GameData.json", dataUser);
            Debug.Log("Data Saved");
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
            Debug.Log("Data Loaded");
            return JsonUtility.FromJson<UserInfo>(File.ReadAllText(Application.persistentDataPath + "UserData.json"));
        }
        catch (Exception e)
        {
            Debug.Log("Error To Load Data" + e);
            throw;
        }
    }
    private GameData LoadUserData()
    {
        Debug.Log("Data Loaded");
        try
        {
            return JsonUtility.FromJson<GameData>(File.ReadAllText(Application.persistentDataPath + "GameData.json"));
        }
        catch (Exception e)
        {
            Debug.Log("Error To Load Data" + e);
            throw;
        }
    }
}
