using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalcController : MonoBehaviour
{
    [SerializeField] private Text result;
    [SerializeField] private Dropdown dropDownSex;
    [SerializeField] private InputField inputFieldWeight;
    [SerializeField] private InputField inputFieldBeer;
    [SerializeField] private InputField inputFieldWine;
    [SerializeField] private InputField inputFieldShot;

    private int int_weight;
    private int int_beer;
    private int int_wine;
    private int int_shot;

    private double beer = 13.2; //33cl, 5%  https://alkompassen.se/promilleraknare
    private double wine = 16.2; //15cl, 13.5% https://alkompassen.se/promilleraknare
    private double shot = 12.8; //4cl https://alkompassen.se/promilleraknare

    // private double currentPromillehalt;
    // private double beerGram;
    // private double wineGram;
    // private double shotGram;

    public void ManualPromilleCalc()
    {
        string dropDown = dropDownSex.options[dropDownSex.value].text;
        InputParseToInt();
        double gram = TotalSumOfGram(int_beer, int_wine, int_shot);
        double promille = CalculatePromille(dropDown, int_weight, gram);
        displayPromille(promille);
    }

    private void InputParseToInt()
    {
        int.TryParse(inputFieldWeight.text, out int_weight);
        int.TryParse(inputFieldBeer.text, out int_beer);
        int.TryParse(inputFieldWine.text, out int_wine);
        int.TryParse(inputFieldShot.text, out int_shot);

    }

    public double TotalSumOfGram(int b, int w, int s)
    {
        // double beerGram = (int_beer * beer);
        // double wineGram = (int_wine * wine);
        // double shotGram = (int_shot * shot);

        double beerGram = (b * beer);
        double wineGram = (w * wine);
        double shotGram = (s * shot);

        return (beerGram + wineGram + shotGram);

    }

    /*    För kvinnor:
        Alkohol i g/(kroppsvikten i kg x 60 %) - (0,15 x timmar från intagets början) = promille
        För män:
        Alkohol i g/(kroppsvikten i kg x 70 %) - (0,15 x timmar från intagets början) = promille
    */
    public double CalculatePromille(string _sex, int weight, double gram)
    {
        double currentPromillehalt = 0;

        if (_sex == "Kvinna")
        {
            currentPromillehalt = gram / (weight * 0.62); //alkoholförbränning.se vart 0.62 och 0.71 kommer från
        }
        else
        {
            currentPromillehalt = gram / (weight * 0.71);
        }

        /* En cirka ekvation för att beräkna x h till 0 promille i blodet */

        // double tillNykter = System.Math.Ceiling(currentPromillehalt / 0.15);
        // Debug.Log(currentPromillehalt);
        // Debug.Log(tillNykter + " h till nykter");

        return currentPromillehalt;



    }

    private void displayPromille(double promille)
    {
        result.text = "" + int_weight;
        result.gameObject.SetActive(true);
        result.text = "Din promille halt = " + System.Math.Round(promille, 2);
    }


    //hur m?nga cl och hur mycket % 


    //en burk stark ?l ?r 50 cl, 5,2% och 20,5g
    //ett glas vin ?r 12,5 cl, 13%, 13g
    //Shot/snaps ?r 4cl, 40%, 13g


}
