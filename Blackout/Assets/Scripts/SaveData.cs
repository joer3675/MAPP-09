using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

[System.Serializable]
public class UserInfo
{
    public int age, weight;
    public string sex;
}


[System.Serializable]
public class GameData
{
    public int age, weight;
    public string sex;
    List<DrinkData> drinks = new List<DrinkData>();

}

[System.Serializable]
public class DrinkData
{
    public int beer;
    public int wine;
    public int spirits;
    public float promille;
}

[System.Serializable]
public class Location
{

}



public class SaveData : MonoBehaviour
{
    [SerializeField] private Text textPromille;
    private UserInfo ui;
    public Button[] sceneButtons;
    private CalcController calc;


    void Awake()
    {
        calc = gameObject.AddComponent<CalcController>();

    }

    void Start()
    {
        ui = readJsonData();
        foreach (Button btn in sceneButtons)
        {
            btn.onClick.AddListener(() => calcPromille(btn.name));
        }
    }



    // public void OnbuttonPressed()
    // {
    //     UserInfo ud = readJsonData();
    //     //string userInformation = readJsonData();
    //     Debug.Log(ud.age + " : age");
    //     Debug.Log(ud.sex + " : sex");
    //     Debug.Log(ud.weight + " : weight");       

    //     string dataUser = JsonUtility.ToJson(this);
    //     System.IO.File.WriteAllText(Application.persistentDataPath + "UserData.json", dataUser);
    //     //H�mta location
    //     // ta en bild?
    //     // kanpp 1,2,3 ?

    //     // if �l { g�r ber�kning}
    // }


    void showPromilleOnSceen()
    {
        // visa promille p� sk�rm med max 2 decimaler
        // 
    }


    void calcPromille(string nameButton)
    {
        double gram = getGram(nameButton);
        Debug.Log("Gram :" + gram);
        Debug.Log("Sex: " + ui.sex);
        Debug.Log("Weight: " + ui.weight);
        double promille = (calc.CalculatePromille(ui.sex, ui.weight, gram));
        Debug.Log("This is your promille now:" + System.Math.Round(promille, 2));
        double tillNykter = System.Math.Ceiling(promille / 0.15);
        Debug.Log("Antal timmar till nykter : " + tillNykter);
    }


    private double getGram(string name)
    {
        double gram = 0;
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
        }

        return gram;
    }

    // r�kna ut promille

    private UserInfo readJsonData()
    {
        return JsonUtility.FromJson<UserInfo>(File.ReadAllText(Application.persistentDataPath + "UserData.json"));
    }
}

