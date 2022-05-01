using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using System.Linq;


public class SortButtonScript : MonoBehaviour
{
    private GameData gameData;
    private bool isNull;
    [SerializeField] private Text historyText;
    // private List<History> _history = new List<History>();
    // private List<Drinks> _drinks = new List<Drinks>();
    // private Dictionary<int, string> _beer = new Dictionary<int, string>();
    // private Dictionary<int, string> _wine = new Dictionary<int, string>();               //Används inte ännu men kan tänkas att göra om vi vill visa något specifikt
    // private Dictionary<int, string> _shot = new Dictionary<int, string>();


    void Start()
    {
        try
        {
            gameData = DataHandler.LoadGameData();



        }
        catch (Exception e)
        {
            Debug.Log("Could not Load data" + e);
            throw;
        }
        if (gameData == null)
        {
            isNull = true;
            historyText.text = "No History";
            //
        }
        else
        {
            isNull = false;
            displayOnScreen(gameData.History);
        }



    }

    public void sortButtonPressed()
    {
        if (!isNull)
        {
            List<History> hList = gameData.History;
            hList = QuickSortScript.QuickSort(hList, 0, hList.Count - 1, "double");

            foreach (History h in hList)
            {
                Debug.Log(h.MaxPromille);
                Debug.Log(h.dateCreated);

            }
            displayOnScreen(hList);
        }
    }
    public void sortButtonDate()
    {
        if (!isNull)
        {
            List<History> hList = gameData.History;
            List<Drinks> dList = new List<Drinks>();
            List<string> dateList = new List<string>();
            hList = QuickSortScript.QuickSort(hList, 0, hList.Count - 1, "date");

            foreach (History h in hList)
            {
                foreach (Drinks d in h._Drinks)
                {
                    dateList = d.drinks.Values.ToList();

                }
                foreach (string s in dateList)
                {
                    Debug.Log(s + " This is s");
                }
                // Debug.Log(h._Drinks[0].beer);
                // Debug.Log(h._Drinks[0].wine);
                // Debug.Log(h._Drinks[0].shot);
                // Debug.Log(h.dateCreated);
                // Debug.Log(h.MaxPromille);
            }
            displayOnScreen(hList);
        }
    }


    private void displayOnScreen(List<History> list)
    {
        String tempText = "";
        foreach (History history in list)
        {
            foreach (Drinks drink in history._Drinks)
            {
                tempText += history.dateCreated + " and you had a max per mille at " + history.MaxPromille + " \n\n";
                foreach (KeyValuePair<string, string> kvp in drink.drinks)
                {
                    tempText += kvp.Key + "  " + kvp.Value + " \n\n";
                }
                // foreach (string s in drink.wine.Values)
                // {
                //     tempText += "Wine " + s + " \n\n";
                // }
                // foreach (string s in drink.shot.Values)
                // {
                //     tempText += "Shot " + s + " \n\n";
                // }
            }
            // tempText += "Promille = " + history.MaxPromille + " at " + history.dateCreated + " \n\n";
        }

        historyText.text = tempText;
        // hej
    }
}

