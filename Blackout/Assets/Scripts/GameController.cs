using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameController : MonoBehaviour
{
    private SwapScene swapScene;

    [SerializeField] private string loadSceneSaved;
    public Button[] sceneOneButtons;

    private Button btnPressed;

    // // void Start()
    // // {
    // //     foreach (Button btn in sceneOneButtons)
    // //     {
    // //         btn.onClick.AddListener(TaskOnClick);
    // //     }

    // // }

    // // void TaskOnClick()
    // // {

    // // }


    // public void ButtonSavedPressed()
    // {
    //     swapScene.LoadScene(loadSceneSaved);
    // }

}
