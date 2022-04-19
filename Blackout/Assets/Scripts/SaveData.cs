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
    private UserData jsonData;

    void start()
    {

    }



    public void OnbuttonPressed()
    {
        UserDataJson ud = readJsonData();
        //string userInformation = readJsonData();
        Debug.Log(ud.age + " age");
        Debug.Log(ud.sex + " sex");
        Debug.Log(ud.weight + " weight");
        

        //Hämta location
        // ta en bild?
        // kanpp 1,2,3 ?

        // if öl { gör beräkning}
    }


    void showPromilleOnSceen()
    {
        // visa promille på skärm med max 2 decimaler
        // 
    }


    void calcPromille()
    {
        // räkna ut promille
    }

    private UserDataJson readJsonData()
    {
        // string userDataJson = 
        //return File.ReadAllText(Application.persistentDataPath + "UserData.json");
        //Debug.Log(userDataJson);
        return JsonUtility.FromJson<UserDataJson>(File.ReadAllText(Application.persistentDataPath + "UserData.json"));
    }



}
