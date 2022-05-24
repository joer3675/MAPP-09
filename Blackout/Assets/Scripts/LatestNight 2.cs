using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LatestNight : MonoBehaviour
{
    private GameData gameData;
    private History lastHistory;
    [SerializeField] private Text historyText;


    // Start is called before the first frame update
    void Start()
    {
        gameData = DataHandler.LoadGameData();
        List<History> historyList = gameData.History;
        //hämtar sista objektet i listan
        lastHistory = historyList[historyList.Count - 1];
        Debug.Log(lastHistory.MaxPromille);

        string tempText = "";

        foreach (Drinks drink in lastHistory._Drinks)
        {

            



            tempText += lastHistory.dateCreated + " and you had a max per mille at " + lastHistory.MaxPromille + " \n\n";
            foreach (KeyValuePair<string, string> kvp in drink.drinks)
            {
                tempText += kvp.Key + "  " + kvp.Value + " \n\n";

            }

        }

        historyText.text = tempText;

    }

        
}
