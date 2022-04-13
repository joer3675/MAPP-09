using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public Button[] sceneOneButtons;

    private Button btnPressed;
    
    void Start(){   
        foreach (Button btn in sceneOneButtons)
        {
            btn.onClick.AddListener(TaskOnClick);
        }
        
    }

     void TaskOnClick(){
         Debug.Log("Clicked");

     }
}
