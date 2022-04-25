using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwapScene : MonoBehaviour
{

    private static SwapScene swapScene;
   
    void Awake()
    {
 
        DontDestroyOnLoad(this.gameObject);
        if(swapScene == null){
            swapScene = this;
        }else{
            DestroyObject(gameObject);
        }
    }



    public void LoadScene(string nameOfScene )
    {     
        SceneManager.LoadScene(nameOfScene);

    }
}
