using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalcController : MonoBehaviour
{
    private int int_weight;
    private float alcoholResult;
    private float wine = 12.8f; //12,5cl, 13%
    private float beer = 15.0f; //33cl, 5,2%
    private float shot = 12.6f; //4cl
    


    [SerializeField] private Text result;


    [SerializeField] private Dropdown dropDownSex;

    [SerializeField] private InputField inputFieldWeight;

    

    private int GetInputWeight()
    {
        int.TryParse(inputFieldWeight.text, out int_weight);
        return int_weight;
    }

    public void CalculatePromille()
    {

        int CurrentWeight = GetInputWeight();
        Debug.Log(CurrentWeight);

        result.text = "" + CurrentWeight;
        result.gameObject.SetActive(true);

    }

    //anv?nd CurrentWeight f?r utr?kning
    //en funktion som heter printResult med result.text = "" + CurrentWeight;

    //hur m?nga cl och hur mycket % 


    //en burk stark ?l ?r 50 cl, 5,2% och 20,5g
    //ett glas vin ?r 12,5 cl, 13%, 13g
    //Shot/snaps ?r 4cl, 40%, 13g













    //private double inputAlchohol = 0;
    //private double isWoman = 4.7;
    //private double isMan = 3.75;
    //private bool Woman = true;
    //private double ouncesOfAlchohol;
    //private double a;
    //private double b;

    //public void GetInputAlchohol(double alchohol)
    //{
    //    inputAlchohol = alchohol;
    //    Debug.Log(inputAlchohol);
    //}

    //public void GetBACLevelMan()
    //{

    //    a = inputAlchohol * 3.75;
    //    double BACMan = a / weight;
    //    Debug.Log(BACMan);

    //}

    //public void GetBACLevelWoman()
    //{

    //    b = inputAlchohol * 4.7;
    //    double BACWoman = b / weight;
    //    Debug.Log(BACWoman);

    //}

    //public void GetBACLevel()
    //{
    //    if (Woman == true)
    //    {
    //        GetBACLevelWoman();
    //    }

    //    else
    //    {
    //        GetBACLevelMan();
    //    }
    //}

}
