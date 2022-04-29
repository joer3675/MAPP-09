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
        //Debug.Log("i'm here");



        GameData myData = DataHandler.LoadGameData();

        List<History> myHistory = myData.History;
        
        
        

        //myDrinks = myData.History[0]._Drinks;

        //Debug.Log(myDrinks.Count);

        foreach (History history in myHistory)
        {
            

            foreach (Drinks drinks in history._Drinks)
            {
                myDrinks.Add(drinks);

                /* foreach (var i in drinks.beer)
                {
                    Debug.Log(i+" beer");
                }
                foreach (var i in drinks.wine)
                {
                    Debug.Log(i + " wine");
                }
                foreach (var i in drinks.shot)
                {
                    Debug.Log(i + " shot");
                } */

                //Debug.Log(drinks.beer[2]);
                /*Debug.Log(drinks.wine[0]);
                Debug.Log(drinks.shot[0]); */
            }
        }

        /* Dictionary<int, string> myBeer;


        foreach (Drinks drinks in myDrinks)
        {
            Debug.Log(drinks.beer);
            Debug.Log("here");
        }
        */

        foreach (Drinks drinks in myDrinks)
        {
            
        }

    }

}
