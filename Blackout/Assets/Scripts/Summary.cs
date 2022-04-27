using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Summary : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Text txtMy = GameObject.Find("Panel/Start").GetComponent<Text>();
        txtMy.text = "Kvällens dricka";

        Text txtMy1 = GameObject.Find("Panel(1)/FirstDrink").GetComponent<Text>();
        txtMy1.text = "Beer kl 20:30";

        Text txtMy2 = GameObject.Find("Panel(2)/SecondDrink").GetComponent<Text>();
        txtMy2.text = "Beer kl 20:30";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
