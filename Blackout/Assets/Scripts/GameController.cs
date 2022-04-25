
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameController : MonoBehaviour
{
    [SerializeField] private SwapScene swapScene;


    [SerializeField] private string loadSceneSaved;
    public Button[] sceneOneButtons;
    //private string s;

    private Button btnPressed;

    void Start()
    {
        foreach (Button btn in sceneOneButtons)
        {
            btn.onClick.AddListener( () => LoadScene(getScene(btn.name)) );
        }

    }
    public void LoadScene(string sceneName){
        if(sceneName!= null)
        swapScene.LoadScene(sceneName);
    }

    public string getScene(string buttonName){
        switch(buttonName)
        {
            case "Button_Scene_StartGame":
                return "StartGame";
            case "Button_Scene_Timeline": 
                return "Timeline";
            case "Button_Scene_PromilleCalc":
                return "PromilleCalc";
            case "Button_Save":
                return "Menu";
            default:
                return null;
        }

    }

    // public void SceneStartGame(){
    //     swapScene.LoadScene("StartGame");
    // }
    // public void SceneTimeline(){
    //     swapScene.LoadScene("Timeline");
    // }
    // public void ScenePromilleCalc(){
    //     swapScene.LoadScene("PromilleCalc");
    // }
    // public void SceneOption(){
    //     swapScene.LoadScene("StartMenu");
    // }
    // public void ButtonSavedPressed()
    // {
    //     swapScene.LoadScene("Menu");
    // }

}
