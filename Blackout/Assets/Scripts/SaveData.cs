using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

[System.Serializable]
public class UserDataJson
{
    public int age, weight;
    public string sex;
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
    private int weight;
    private string sex;
    //private UserData jsonData;



    public void OnbuttonPressed()
    {
        UserDataJson ud = readJsonData();
        //string userInformation = readJsonData();
        Debug.Log(ud.age + " : age");
        Debug.Log(ud.sex + " : sex");
        Debug.Log(ud.weight + " : weight");       
    
        string dataUser = JsonUtility.ToJson(this);
        System.IO.File.WriteAllText(Application.persistentDataPath + "UserData.json", dataUser);
        //H�mta location
        // ta en bild?
        // kanpp 1,2,3 ?

        // if �l { g�r ber�kning}
    }


    void showPromilleOnSceen()
    {
        // visa promille p� sk�rm med max 2 decimaler
        // 
    }


    void calcPromille()
    {
        // r�kna ut promille
    }

    private UserDataJson readJsonData()
    {
        // string userDataJson = 
        //return File.ReadAllText(Application.persistentDataPath + "UserData.json");
        //Debug.Log(userDataJson);
        return JsonUtility.FromJson<UserDataJson>(File.ReadAllText(Application.persistentDataPath + "UserData.json"));
    }



}
