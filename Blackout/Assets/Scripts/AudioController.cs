using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    public GameObject audioOnIcon;
    public GameObject audioOffIcon;
    

    // Start is called before the first frame update
    void Start()
    {
        //vid start kollar metoden användarens info kring vad den klickat
        // om man mutad innan fortsätter den vara mutad, och tvärtom
        SetSoundState();

        
    }

    // för att spara användarens info gällande om muteknappen är på eller av
    // hämtar muteknappens state
    public void ToggleSound()
    {
        // if it's not muted then... 
        if (PlayerPrefs.GetInt("Muted", 0) == 0)
        {
            PlayerPrefs.SetInt("Muted", 1);
        }
        else
        {
            PlayerPrefs.SetInt("Muted", 0);
        }

        SetSoundState();
    }

    //metod som stänger av och sätter på ljud
    public void SetSoundState()
    {
        if (PlayerPrefs.GetInt("Muted", 0) == 0)
        {
            //calling the listener on the class will give you the main listener in scene/game
            AudioListener.volume = 1;
            audioOnIcon.SetActive(true);
            audioOffIcon.SetActive(false);
        }
        else
        {
            AudioListener.volume = 0;
            audioOnIcon.SetActive(false);
            audioOffIcon.SetActive(true);
        }
    }

    
}
