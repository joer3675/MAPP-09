using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class HistortTextScript : MonoBehaviour
{
    [SerializeField] private Text textOnScreen;
    private History myHistoryObject;

    void Awake()
    {
        setHistoryObject();
        displayOnInformationPanel();
    }

    private void setHistoryObject()
    {
        myHistoryObject = HistoryTLScript.getCurrentHistory();
    }
    private void displayOnInformationPanel()
    {
        String tempText = "";
        if (myHistoryObject != null)
        {
            foreach (Drinks drink in myHistoryObject._Drinks)
            {
                tempText += myHistoryObject.dateCreated + " and you had a max per mille at " + myHistoryObject.MaxPromille + " \n\n";
                foreach (KeyValuePair<string, string> kvp in drink.drinks)
                {
                    tempText += kvp.Key + "  " + kvp.Value + " \n\n";

                }
            }
        }
        else
        {
            tempText = "No History";
        }
        textOnScreen.text = tempText;
    }

}
