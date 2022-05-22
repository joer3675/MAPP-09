using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI

public class DateMenu : MonoBehaviour
{ 

    Resolution[] resolutions;

    [SerializeField]Transform menuPanel;
    [SerializeField] GameObject buttonPrefab;

    void Start()
    {
        resolutions = Screen.resolutions;
        for (int i = 0; i < resolutions.Length; i++)
        {

            GameObject button = (GameObject)Instantiate(buttonPrefab);
            button.GetComponentInChildren<Text>().text = ResToString(resolutions[i]);
            int index = i;
            button.GetComponent<Button>().onClick.AddListener(
                () => { SetResolution(index); }
                );
            button.transform.parent = menuPanel;
        }

    }

    void SetResolution(int index)
    {

        Screen.SetResolution(resolutions[index].width, resolutions[index].height, false);
    }

    string ResToString(Resolution res)
    {
        return res.width + " x " + res.height;
    }

  
}
