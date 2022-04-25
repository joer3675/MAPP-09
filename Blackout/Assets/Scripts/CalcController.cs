using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalcController : MonoBehaviour
{
    private int int_weight;
    private int int_beer;
    private int int_wine;
    private int int_shot;
    
    private double wine = 12.8f; //12,5cl, 13%
    private double beer = 15.0f; //33cl, 5,2%
    private double shot = 12.6f; //4cl
    private double currentPromillehalt;

    private double beerGram;
    private double wineGram;
    private double shotGram;
    



    [SerializeField] private Text result;


    [SerializeField] private Dropdown dropDownSex;

    [SerializeField] private InputField inputFieldWeight;
    [SerializeField] private InputField inputFieldBeer;
    [SerializeField] private InputField inputFieldWine;
    [SerializeField] private InputField inputFieldShot;

    private void InputParseToInt()
    {
        int.TryParse(inputFieldWeight.text, out int_weight);
        int.TryParse(inputFieldBeer.text, out int_beer);
        int.TryParse(inputFieldWine.text, out int_wine);
        int.TryParse(inputFieldShot.text, out int_shot);
        Debug.Log(inputFieldWeight.text + " text" + int_weight + " weight");
       

    }

    private double TotalSumOfGram()
    {
        beerGram = (int_beer * beer);

        Debug.Log(int_weight + "weight");


        wineGram = (int_wine * wine);

        Debug.Log(int_shot + " int_shot " + shot + " shotGram"); 

        shotGram = (int_shot * shot);

        Debug.Log(shotGram);

         return (beerGram + wineGram + shotGram);

    }
   

    public void CalculatePromille()
    {

        //int currentWeight = GetInputWeight();
        //Debug.Log(currentWeight);
        InputParseToInt();
        result.text = "" + int_weight;
        result.gameObject.SetActive(true);

        if (dropDownSex.options[dropDownSex.value].text == "Kvinna")
        {
            currentPromillehalt = TotalSumOfGram() / (int_weight * 0.6);
        }
        else
        {
            currentPromillehalt = TotalSumOfGram() / (int_weight * 0.7);
        }
        result.text = "Din promille halt = " + System.Math.Round(currentPromillehalt, 2);


    }

    
    //hur m?nga cl och hur mycket % 


    //en burk stark ?l ?r 50 cl, 5,2% och 20,5g
    //ett glas vin ?r 12,5 cl, 13%, 13g
    //Shot/snaps ?r 4cl, 40%, 13g


}
