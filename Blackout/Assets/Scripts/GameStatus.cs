using UnityEngine;
using UnityEngine.UI;


public class GameStatus : MonoBehaviour
{
    [SerializeField] private Button startButton;
    void Start()
    {
        if (PlayerPrefs.GetInt("hasStarted") == 1)
        {
            Debug.Log("Continue");
            startButton.GetComponentInChildren<Text>().text = "Continue";
            startButton.GetComponent<Image>().color = Color.green;
        }
        else
        {
            Debug.Log("StartNight");
            startButton.GetComponentInChildren<Text>().text = "Start Night";
            startButton.GetComponent<Image>().color = Color.white;
        }
    }
}
