using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwapScene : MonoBehaviour
{
    [SerializeField] public string nameOfScene;
    void awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    public void LoadScene()
    {
        
        SceneManager.LoadScene(nameOfScene);

    }
}
