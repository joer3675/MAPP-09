using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/*Detta script ser till att bytet mellan scener sker med en animation. Scriptet bestämmer även vilken scen som ska bytas till beroende på vilket knapp användaren klickar på*/
public class SceneController : MonoBehaviour
{
    [SerializeField] private Animator anim;
    public Button[] sceneOneButtons;
    private float transitionDelayTime = 1.0f;


    void Start()
    {
        anim.SetTrigger("Out");
        foreach (Button btn in sceneOneButtons)
        {
            btn.onClick.AddListener(() => { LoadScene(getSceneName(btn.name)); });
        }
    }

    public void LoadScene(string sceneName)
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
                //ändrade så att man kommer till timeline-menyn istället för direkt till timelinen
                return "TimelineMenu";
            case "Button_Scene_PromilleCalc":
                return "PromilleCalc";
            case "Button_Save":
                return "Menu";
            case "Button_Back":
                return "Menu";
            case "Button_Settings":
                return "Profile";
            //tanya: har lagt till här för min timeline meny
            case "Button Latest Night":
                return "LatestNight";
            case "Button Timeline":
                return "Timeline";
            case "Button_Close":
                return "TimelineMenu";
            case "Button_Camera":
                return "Camera";

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
