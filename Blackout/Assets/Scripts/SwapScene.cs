using UnityEngine;
using UnityEngine.SceneManagement;

public static class SwapScene
{

    // private static SwapScene swapScene;

    // void Awake()
    // {

    //     DontDestroyOnLoad(this.gameObject);
    //     if (swapScene == null)
    //     {
    //         swapScene = this;
    //     }
    //     else
    //     {
    //         Destroy(gameObject);
    //     }
    // }
    public static void LoadScene(string nameOfScene)
    {
        SceneManager.LoadScene(nameOfScene);

    }
}
