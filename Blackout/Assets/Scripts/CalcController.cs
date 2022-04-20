using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalcController : MonoBehaviour
{
    private string inputA;
    private float inputAlchohol = 0;
    private double isWoman = 4.7;
    private double isMan = 3.75;
    private bool Woman = true;
    private double ouncesOfAlchohol;
    private string a;
    private string b;

    public void GetInputWeight(string weight)
    {
        inputA = weight;
        Debug.Log(inputA);
    }

    public void GetBACLevelMan()
    {

        a = ouncesOfAlchohol * 3.75;
        double BACMan = a / inputA;
        Debug.Log(BACMan);

    }

    public void GetBACLevelWoman()
    {

        b = ouncesOfAlchohol * 4.7;
        double BACWoman = b / inputA;
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
