using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalcController : MonoBehaviour
{
    private string inputA;

    public void GetInputWeight(string weight)
    {
        inputA = weight;
        Debug.Log(inputA);
    }
   
}
