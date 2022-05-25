using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//public class HistoryTLScript : MonoBehaviour
//{
//    private GameData gameData;
//    private History ChosenHistory;
//    [SerializeField] private Text historyText;


//    // Start is called before the first frame update
//    void Start()
//    {
//        gameData = DataHandler.LoadGameData();
//        List<History> historyList = gameData.History;
//        //hämtar valda obijektet i listan, ifrån sidan Timeline
//        ChosenHistory = // historyList[historyList.Count - 1];
//        Debug.Log(ChosenHistory.MaxPromille);

//        string tempText = "";

//        foreach (Drinks drink in ChosenHistory._Drinks)
//        {





//            tempText += ChosenHistory.dateCreated + " and you had a max per mille at " + ChosenHistory.MaxPromille + " \n\n";
//            foreach (KeyValuePair<string, string> kvp in drink.drinks)
//            {
//                tempText += kvp.Key + "  " + kvp.Value + " \n\n";

//            }

//        }

//        historyText.text = tempText;

//    }


//}
