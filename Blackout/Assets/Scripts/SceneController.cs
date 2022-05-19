using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    [SerializeField] private Animator anim;
    //[SerializeField] private Canvas canvas;
    // private SwapScene swapScene;
    public Button[] sceneOneButtons;

    //private Animator animator;
    private float transitionDelayTime = 1.5f;

    //private GameObject gameObject;
    // void Awake()
    // {
    //     anim.SetTrigger("Out");
    // }

    // void Awake()
    // {
    //     swapScene = GameObject.FindObjectOfType<SwapScene>();
    // }

    //private void Awake()
    //{
    //animator = GetComponent<Animator>();
    //}

    void Start()
    {


        anim.SetTrigger("Out");


        foreach (Button btn in sceneOneButtons)
        {
            btn.onClick.AddListener(() => { LoadScene(getSceneName(btn.name)); });
        }
    }

    private void LoadScene(string sceneName)
    {

        if (sceneName != null)
        {

            StartCoroutine(DelayLoadLevel(sceneName));

        }
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

    IEnumerator DelayLoadLevel(string sceneName)
    {

        anim.SetTrigger("In");
        yield return new WaitForSeconds(transitionDelayTime);
        SwapScene.LoadScene(sceneName);

    }
}
