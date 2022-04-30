using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SortTimeline : MonoBehaviour
{
    private History history = new History();
    private List<Drinks> myDrinks = new List<Drinks>();

    // Start is called before the first frame update
    void Start()
    {


        var dropdown = gameObject.GetComponent<Dropdown>();

        dropdown.options.Clear();

        List<string> items = new List<string>();
        items.Add("");
        items.Add("");


        foreach (var item in items)
        {
            dropdown.options.Add(new Dropdown.OptionData() { text = item });
        }

        DropdownItemSelected(dropdown);


        dropdown.onValueChanged.AddListener(delegate { DropdownItemSelected(dropdown); });

    }

    void DropdownItemSelected(Dropdown dropdown)
    {
        Debug.Log("i'm here");

        GameData myData = DataHandler.LoadGameData();



        myDrinks = history._Drinks;
        Debug.Log(myDrinks.Count);

        //Dictionary<int, string> myBeer;

        foreach (Drinks drinks in myDrinks)
        {
            Debug.Log(drinks.beer);
            Debug.Log("here");
        }
    }
}
