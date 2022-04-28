using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class DisplayButtonBack : MonoBehaviour
{
    [SerializeField] private Button _buttonBack;
    //private ReadUserInput userData;
    // Start is called before the first frame update
    void Awake()
    {
        //userData = gameObject.AddComponent<ReadUserInput>();
        if (File.Exists(Application.persistentDataPath + "UserData.json"))
        {
            Debug.Log("here");
            _buttonBack.gameObject.SetActive(true);
        }
        else
        {
            Debug.Log("BUUUU!!");
            _buttonBack.gameObject.SetActive(false);
        }

    }
}