using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
public class LoadingSceneScript : MonoBehaviour
{
    private ReadUserInput userData;
    // Start is called before the first frame update
    void Awake()
    {
        userData = gameObject.AddComponent<ReadUserInput>();
        if (File.Exists(Application.persistentDataPath + "UserData.json"))
        {
            SceneManager.LoadScene("Menu");
        }
        else
        {
            SceneManager.LoadScene("StartMenu");
        }

    }

}
