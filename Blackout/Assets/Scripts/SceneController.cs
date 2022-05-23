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
                //har ändrat här också (från Timeline till TimelineMenu), skriver så att jag minns om det skulle bli fel någonstans!
                return "TimelineMenu";
            case "Button_Scene_PromilleCalc":
                return "PromilleCalc";
            case "Button_Save":
                return "Menu";
            case "Button_Back":
                return "Menu";
            case "Button_Settings":
                return "Profile";
            //tanya: har lagt till lite här under för timeline-menyn jag gjort! :)
            case "Button_Scene_Date":
                return "DateTimeline";
            case "Button_Scene_PerMille":
                return "PerMilleTimeline";
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
