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
    [SerializeField] GameObject buttonPrefab;
    [SerializeField] Transform menuPanel;
    public GameObject panel;
    private List<History> hList;
    private List<History> currentHistoryList = new List<History>();
    private List<GameObject> buttonPrefabList = new List<GameObject>();
    private History currentHistory;
    private int index;
    private List<int> indexList = new List<int>();

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
            index = 0;
            hList = gameData.History;
            foreach (History h in hList)
            {
                GameObject button = (GameObject)Instantiate(buttonPrefab);
                button.transform.SetParent(menuPanel.transform, false);
                button.GetComponentInChildren<Text>().text = h.dateCreated;
                buttonPrefabList.Add(button);
                currentHistoryList.Add(h);
                indexList.Add(index++);
                button.GetComponent<Button>().onClick.AddListener(() =>
                {
                    Debug.Log("Pressed");
                    showDateInformation(buttonPrefabList.IndexOf(button));
                });

            }

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
            //displayOnScreen(gameData.History, "Date");
        }

    }

    private void showDateInformation(int indexOfButton)
    {
        Debug.Log(indexOfButton);
        foreach (int i in indexList)
        {
            if (i == indexOfButton)
            {

                currentHistory = currentHistoryList[indexList.IndexOf(i)];

            }
        }
        displayOnInformationPanel();
        panel.SetActive(true);
        Debug.Log("here");
    }
    public void closePanel()
    {
        panel.SetActive(false);
    }

    public void sortButtonPressed()
    {
        if (!isNull)
        {
            //List<History> hList = gameData.History;
            hList = QuickSortScript.QuickSort(hList, 0, hList.Count - 1, "double");


            displayOnScreen(hList, "PerMille");
        }
    }
    public void sortButtonDate()
    {
        if (!isNull)
        {
            //List<History> hList = gameData.History;
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
            displayOnScreen(hList, "Date");
        }
    }



    private void displayOnScreen(List<History> list, string typOfSort)
    {
        int i = 0;
        currentHistoryList.Clear();
        String tempText = "";
        foreach (History history in list)
        {

            foreach (Drinks drink in history._Drinks)
            {
                // foreach (Drinks drink in currentHistory._Drinks)
                // {

                //     if (typOfSort.Equals("Date"))
                //     {
                //         buttonPrefabList[i++].GetComponentInChildren<Text>().text = currentHistory.dateCreated;
                //     }
                //     else
                //     {
                //         buttonPrefabList[i++].GetComponentInChildren<Text>().text = currentHistory.MaxPromille.ToString();
                //     }


                //     tempText += currentHistory.dateCreated + " and you had a max per mille at " + currentHistory.MaxPromille + " \n\n";
                //     foreach (KeyValuePair<string, string> kvp in drink.drinks)
                //     {
                //         tempText += kvp.Key + "  " + kvp.Value + " \n\n";

                //     }

                // }
                {

                    if (typOfSort.Equals("Date"))
                    {
                        currentHistoryList.Add(history);
                        buttonPrefabList[i++].GetComponentInChildren<Text>().text = history.dateCreated;
                    }
                    else
                    {
                        currentHistoryList.Add(history);
                        buttonPrefabList[i++].GetComponentInChildren<Text>().text = history.MaxPromille.ToString();
                    }


                    tempText += history.dateCreated + " and you had a max per mille at " + history.MaxPromille + " \n\n";
                    foreach (KeyValuePair<string, string> kvp in drink.drinks)
                    {
                        tempText += kvp.Key + "  " + kvp.Value + " \n\n";

                    }

                }

            }

            //historyText.text = tempText;

        }
    }

    private void displayOnInformationPanel()
    {
        String tempText = "";
        foreach (Drinks drink in currentHistory._Drinks)
        {
            tempText += currentHistory.dateCreated + " and you had a max per mille at " + currentHistory.MaxPromille + " \n\n";
            foreach (KeyValuePair<string, string> kvp in drink.drinks)
            {
                tempText += kvp.Key + "  " + kvp.Value + " \n\n";

            }
        }
        historyText.text = tempText;
    }
}