using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PerMilleButton : MonoBehaviour
{

    private GameData gameData;
   
    //private History history;
    
    

    Resolution[] resolutions;
    [SerializeField] GameObject buttonPrefab;
    Transform timelinePanel;


    // Start is called before the first frame update
    void Start()
    {
        gameData = DataHandler.LoadGameData();
        List<History> list = new List<History>();



        // resolutions = Screen.resolutions;
        //for (int i = 0; i < History. ; i++)
        {
            //GameObject button = (GameObject)Instantiate(buttonPrefab);
            //button.GetComponent<Text>().text = ResToString(resolutions[i]);
            //int index = i;
            //button.GetComponent<Button>().onClick.AddListener(
               // () => { SetResolution(index); }
            //);
            //button.transform.parent = timelinePanel;
           
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
