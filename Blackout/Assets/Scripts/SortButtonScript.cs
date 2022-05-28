
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

/*Sorterar listor från filer nedsparade i .json format. Sorterar historiken utifrån datum eller promille.
 Kan även sortera efter senaste/nyast eller lägsta/högst promillehalt */

public class SortButtonScript : MonoBehaviour
{
    private GameData gameData;
    private bool isNull;
    [SerializeField] private Text historyText;
    [SerializeField] GameObject buttonPrefab;
    [SerializeField] Transform menuPanel;
    private List<History> hList;
    private List<History> currentHistoryList = new List<History>();
    private List<GameObject> buttonPrefabList = new List<GameObject>();
    private History currentHistory;
    private int index;
    private List<int> indexList = new List<int>();
    private Boolean isSortedDate;
    private Boolean isSortedPerMille;


    void Start()
    {

        try
        {
            gameData = DataHandler.LoadGameData();
            index = 0;
            hList = gameData.History;
            isSortedDate = false;
            isSortedPerMille = false;
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
                    loadSceneWithHistory(buttonPrefabList.IndexOf(button));
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
        }
        else
        {
            isNull = false;
        }

    }

    private void loadSceneWithHistory(int indexOfButton)
    {

        foreach (int i in indexList)
        {
            if (i == indexOfButton)
            {

                currentHistory = currentHistoryList[indexList.IndexOf(i)];
                HistoryTLScript.setCurrentHistory(currentHistory);
            }
        }
        SwapScene.LoadScene("HistoryTL");
    }


    public void sortButtonPressed()
    {
        if (!isNull)
        {
            if (!isSortedPerMille)
            {
                hList = QuickSortScript.QuickSort(hList, 0, hList.Count - 1, "double");
                isSortedPerMille = true;
            }
            else
            {
                hList.Reverse();
            }

            displayOnScreen(hList, "PerMille");
        }
    }
    public void sortButtonDate()
    {
        if (!isNull)
        {
            if (!isSortedDate)
            {
                hList = QuickSortScript.QuickSort(hList, 0, hList.Count - 1, "date");
                isSortedDate = true;
            }
            else
            {
                hList.Reverse();
            }
            displayOnScreen(hList, "Date");
        }
    }



    private void displayOnScreen(List<History> list, string typOfSort)
    {
        int i = 0;
        currentHistoryList.Clear();
        foreach (History history in list)
        {
            if (typOfSort.Equals("Date"))
            {
                currentHistoryList.Add(history);
                buttonPrefabList[i++].GetComponentInChildren<Text>().text = history.dateCreated;
            }
            else
            {
                currentHistoryList.Add(history);
                buttonPrefabList[i++].GetComponentInChildren<Text>().text = history.MaxPromille.ToString() + " %";
            }

        }
    }

}