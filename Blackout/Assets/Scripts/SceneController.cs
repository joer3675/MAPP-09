using UnityEngine;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{

    // private SwapScene swapScene;
    public Button[] sceneOneButtons;


    // void Awake()
    // {
    //     swapScene = GameObject.FindObjectOfType<SwapScene>();
    // }

    void Start()
    {

        foreach (Button btn in sceneOneButtons)
        {
            btn.onClick.AddListener(() => { LoadScene(getSceneName(btn.name)); });
        }
    }

    private void LoadScene(string sceneName)
    {

        if (sceneName != null ) SwapScene.LoadScene(sceneName);
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
            case "Button_Settings":
                return "StartMenu";
            default:
                return null;
        }
    }
}
