using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupPerMille : MonoBehaviour
{
    public Canvas popupCanvas;
    public bool pressed = false;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void popup()
    {
        if (pressed == false)
        {
            pressed = true;
            popupCanvas.enabled = true;
        }
        else if (pressed == true)
        {
            pressed = false;
            popupCanvas.enabled = false;
        }
    }
}
