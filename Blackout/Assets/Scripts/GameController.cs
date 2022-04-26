
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameController : MonoBehaviour
{
    private SwapScene swapScene;
    public Button[] sceneOneButtons;

    void Awake()
    {
        swapScene = GameObject.FindObjectOfType<SwapScene>();
    }

    void Start()
    {
        foreach (Button btn in sceneOneButtons)
        {
            btn.onClick.AddListener(() => { LoadScene(getSceneName(btn.name)); Debug.Log(btn.name + " button was pressed"); });
        }
    }


    private void LoadScene(string sceneName)
    {

        if (sceneName != null) swapScene.LoadScene(sceneName);
    }

    private string getSceneName(string buttonName)
    {
        switch (buttonName)
        {
            case "Button_Scene_StartGame":
                return "StartGame";
            case "Button_Scene_Timeline":
                return "Timeline";
            case "Button_Scene_PromilleCalc":
                return "PromilleCalc";
            case "Button_Save":
                return "Menu";
            case "Button_Back":
                return "Menu";
            default:
                return null;
        }
    }
}
