using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalcController : MonoBehaviour
{
    private string inputA;
    private double inputAlchohol = 0;
    private double isWoman = 4.7;
    private double isMan = 3.75;
    private bool Woman = true;
    private double ouncesOfAlchohol;
    private double a;
    private double b;

    public void GetInputWeight(string weight)
    {
        inputA = weight;
        Debug.Log(inputA);
    }

    public void GetInputAlchohol(double alchohol)
    {
        inputAlchohol = alchohol;
        Debug.Log(inputAlchohol);
    }

    public void GetBACLevelMan()
    {

        a = inputAlchohol * 3.75;
        double BACMan = a / weight;
        Debug.Log(BACMan);

    }

    public void GetBACLevelWoman()
    {

        b = inputAlchohol * 4.7;
        double BACWoman = b / weight;
        Debug.Log(BACWoman);

    }

    public void GetBACLevel()
    {
        if (Woman == true)
        {
            GetBACLevelWoman();
        }

        else
        {
            GetBACLevelMan();
        }
    }

}
