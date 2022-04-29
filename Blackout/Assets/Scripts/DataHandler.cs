using UnityEngine;
using System.IO;
using System;
using Newtonsoft.Json;

public static class DataHandler
{
    public static void SaveDataToFile(GameData gameData)
    {
        try
        {
            var dataUser = JsonConvert.SerializeObject(gameData, Formatting.Indented);
            System.IO.File.WriteAllText(Application.persistentDataPath + "GameData.json", dataUser);
        }
        catch (Exception e)
        {
            Debug.Log("Data failed to save!" + e);
            throw;
        }
    }

    public static UserData LoadUserData()
    {
        try
        {
            var jsonObject = (File.ReadAllText(Application.persistentDataPath + "UserData.json"));
            return JsonConvert.DeserializeObject<UserData>(jsonObject);
        }
        catch (Exception e)
        {
            Debug.Log("Error To Load Data" + e);
            throw;
        }
    }
    public static GameData LoadGameData()
    {
        try
        {
            var jsonObject = (File.ReadAllText(Application.persistentDataPath + "GameData.json"));
            return JsonConvert.DeserializeObject<GameData>(jsonObject);
        }
        catch (Exception e)
        {
            Debug.Log("Error To Load Data" + e);
            throw;
        }
    }

}
