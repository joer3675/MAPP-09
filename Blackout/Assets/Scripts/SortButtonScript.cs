using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using System.Linq;


public class SortButtonScript : MonoBehaviour
{
    private GameData gameData;
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

        displayOnScreen(gameData.History);
    }

    public void sortButtonPressed()
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
    public void sortButtonDate()
    {
        List<History> hList = gameData.History;
        hList = QuickSortScript.QuickSort(hList, 0, hList.Count - 1, "date");

        foreach (History h in hList)
        {
            Debug.Log(h.dateCreated);
            Debug.Log(h.MaxPromille);
        }
        displayOnScreen(hList);
    }


    private void displayOnScreen(List<History> list)
    {
        String tempText = "";
        foreach (History hist in list)
        {
            tempText += "Promille = " + hist.MaxPromille + " at " + hist.dateCreated + " \n\n";
        }

        historyText.text = tempText;
        // hej
    }
}

