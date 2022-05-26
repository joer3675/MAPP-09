using UnityEngine;
using UnityEngine.UI;

public class AvatarScript : MonoBehaviour
{
    [SerializeField] private GameHandler gameHandler;
    [SerializeField] private Sprite boy1;
    [SerializeField] private Sprite boy2;
    [SerializeField] private Sprite boy3;
    [SerializeField] private Sprite boy4;
    [SerializeField] private Sprite girl1;
    [SerializeField] private Sprite girl2;
    [SerializeField] private Sprite girl3;
    [SerializeField] private Sprite girl4;
    private float currentTime;
    private float timeDelay = 2.0f;
    private float timer = 0.0f;
    private string gender;
    private Sprite currentGender;

    void Start()
    {
        gender = gameHandler.getGender();
        if (gender.Equals("Male"))
        {
            currentGender = boy1;
            gameObject.GetComponent<Image>().sprite = boy1;
        }
        else
        {
            currentGender = girl1;
            gameObject.GetComponent<Image>().sprite = girl1;
        }
        currentTime = Time.deltaTime;
    }

    void Update()
    {
        currentTime += Time.deltaTime;
        if (timer < currentTime)
        {
            updateImageOnScreen();
            timer = currentTime + timeDelay;

        }
    }

    public void updateImageOnScreen()
    {

        double perMille = gameHandler.getPerMille();
        perMille = System.Math.Round(perMille, 2);


        // Updatera avatar beroende på vad promillehalten är
        Sprite currentSprite = getCorrectSpritePerMilleAndGender(perMille);
        updateImagePerMille(currentSprite);

    }


    private void updateImagePerMille(Sprite spriteToShow)
    {
        gameObject.GetComponent<Image>().sprite = spriteToShow;

    }

    private Sprite getCorrectSpritePerMilleAndGender(double perMille)
    {

        switch (gender)
        {
            case "Male":
                {
                    if (perMille > 4)
                    {
                        return boy4;

                    }
                    else if (perMille > 3)
                    {
                        return boy3;
                        //Gör något
                    }
                    else if (perMille > 2)
                    {
                        return boy2;
                        // Gör något
                    }
                    else if (perMille > 1)
                    {
                        return boy1;
                        // Gör något
                    }
                    else if (perMille >= 0)
                    {
                        return boy1;
                        // Bild...
                    }
                    else
                    {
                        return null;
                    }
                }

            case "Female":
                {
                    if (perMille > 4)
                    {
                        return girl4;

                    }
                    else if (perMille > 3)
                    {
                        return girl3;
                        //Gör något
                    }
                    else if (perMille > 2)
                    {
                        return girl2;
                        // Gör något
                    }
                    else if (perMille > 1)
                    {
                        return girl1;
                        // Gör något
                    }
                    else if (perMille > 0)
                    {
                        return girl1;
                        // Bild...
                    }
                    else
                    {
                        return null;
                    }
                }
            default:
                return null;
        }
    }

}
