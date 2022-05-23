
/*Detta script används för att tvinga användaren att skapa en profil första gången vid användning utav appen */

using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
public class LoadingSceneScript : MonoBehaviour
{
    private ReadUserInput userData;

    void Awake()
    {
        userData = gameObject.AddComponent<ReadUserInput>();
        if (File.Exists(Application.persistentDataPath + "UserData.json"))
        {
            SceneManager.LoadScene("Menu");
        }
        else
        {
            SceneManager.LoadScene("Profile");
        }

    }

}
