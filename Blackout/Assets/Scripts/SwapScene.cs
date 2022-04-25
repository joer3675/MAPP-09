using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwapScene : MonoBehaviour
{
    //[SerializeField] public string nameOfScene;
    
    // public GameObject gameObject;

   
    // void Awake()
    // {
    //     //ReadUserInput readUserInput = gameObject.GetCompontent<ReadUserInput>;
    //     //DontDestroyOnLoad(this.gameObject);
    // }


    // void Start(){
    //     ReadUserInput readUserInput = gameObject.GetCompontent<ReadUserInput>;
    //     Debug.Log("Here");
    //     if(readUserInput.hasInput()){
    //         LoadScene("Menu");
    //     }
    //     Debug.Log(readJsonData.hasInput());

    // }


    public void LoadScene(string nameOfScene )
    {     
        SceneManager.LoadScene(nameOfScene);

    }
}
