using System.Collections.Generic;
using System;


[System.Serializable]
public class UserData
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

    public DateTime timeLastDrink;
    public string dateCreated;
    public int GameTime, previousTimeDiff;
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
    public Dictionary<string, string> drinks = new Dictionary<string, string>();
    //public Dictionary<int, string> beer = new Dictionary<int, string>();
    // public Dictionary<int, string> wine = new Dictionary<int, string>();
    // public Dictionary<int, string> shot = new Dictionary<int, string>();
    // public int beer = 0;
    // public int wine = 0;
    // public int shot = 0;

}
[System.Serializable]
public class Location
{

}

