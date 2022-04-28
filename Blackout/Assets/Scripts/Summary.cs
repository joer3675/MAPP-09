using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;


public class DrinkCollector
{

    public List<History> drinkList;

}


public class Summary : MonoBehaviour
{
    private DrinkCollector drinkCollector = new DrinkCollector();


    // Start is called before the first frame update
    void Start()
    {
        getData();


        Text txtMy = GameObject.Find("Panel1/Text").GetComponent<Text>();
        txtMy.text = "Your Night Started!";

        Text txtMy1 = GameObject.Find("Panel2/Text").GetComponent<Text>();
        txtMy1.text = "Beer kl 20:30";

        Text txtMy2 = GameObject.Find("Panel3/Text").GetComponent<Text>();
        txtMy2.text = "Beer kl 20:58";

        Text txtMy3 = GameObject.Find("Panel4/Text").GetComponent<Text>();
        txtMy3.text = "Beer kl 21:30";

        Text txtMy4 = GameObject.Find("Panel5/Text").GetComponent<Text>();
        txtMy4.text = "Beer kl 21:45";

        Text txtMy5 = GameObject.Find("Panel6/Text").GetComponent<Text>();
        txtMy5.text = "Shot kl 21:59";
    }

    private void getData() {

        GameData myData = DataHandler.LoadGameData();
        drinkCollector.drinkList = myData.History;

        foreach (History h in drinkCollector.drinkList) {
            Debug.Log(h._Drinks);
        }
    }
    
}
