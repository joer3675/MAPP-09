using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class HistoryHandler : MonoBehaviour
{

    private GameData gameData;
    public Text TextBox;
    // Start is called before the first frame update
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

        var dropdown = gameObject.GetComponent<Dropdown>();
        List<string> items = new List<string>();
        List<History> list = new List<History>();
        dropdown.options.Clear();
        foreach (History h in list)
        {
            items.Add(h.dateCreated);
        }

        items.Add("2022-04-22");
        items.Add("2022-04-15");
        items.Add("2022-04-09");

        foreach (var item in items)
        {
            dropdown.options.Add(new Dropdown.OptionData() { text = item });
        }

        DropdownItemSelected(dropdown);


        dropdown.onValueChanged.AddListener(delegate { DropdownItemSelected(dropdown); });

    }


    void DropdownItemSelected(Dropdown dropdown)
    {

        Debug.Log("date");
        int index = dropdown.value;
        TextBox.text = dropdown.options[index].text;
    }


}