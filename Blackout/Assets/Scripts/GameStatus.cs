using UnityEngine;
using UnityEngine.UI;


public class GameStatus : MonoBehaviour
{
    [SerializeField] private Button startButton;
    void Start()
    {
        if (PlayerPrefs.GetInt("hasStarted") == 1)
        {

            startButton.GetComponentInChildren<Text>().text = "Continue";
            startButton.GetComponent<Image>().color = Color.green;
        }
        else
        {

            startButton.GetComponentInChildren<Text>().text = "Start Night";
            startButton.GetComponent<Image>().color = Color.white;
        }
    }
}
