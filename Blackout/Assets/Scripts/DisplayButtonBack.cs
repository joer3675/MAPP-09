using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class DisplayButtonBack : MonoBehaviour
{
    [SerializeField] private Button _buttonBack;

    void Awake()
    {
        if (File.Exists(Application.persistentDataPath + "UserData.json"))
        {

            _buttonBack.gameObject.SetActive(true);
        }
        else
        {

            _buttonBack.gameObject.SetActive(false);
        }

    }
}
