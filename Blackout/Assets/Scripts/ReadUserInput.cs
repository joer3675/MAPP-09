using UnityEngine;
using UnityEngine.UI;
public class ReadUserInput : MonoBehaviour
{
    private UserData _userData = new UserData();
    [SerializeField] private Sprite boy;
    [SerializeField] private Sprite boyPressed;
    [SerializeField] private Sprite girl;
    [SerializeField] private Sprite girlPressed;
    [SerializeField] private Button[] buttonSex;
    [SerializeField] private Slider sliderAge;
    [SerializeField] private Slider sliderWeight;
    [SerializeField] private Text slidebarAgeText;
    [SerializeField] private Text slidebarWeightText;
    [SerializeField] private AudioSource soundGirlHello;
    [SerializeField] private AudioSource soundBoyHello;
    [SerializeField] private SceneController sceneController;

    /*Detta script används då användaren ska skapa en "profil". Läser in all information som användaren väljer, samt sparar ned det till en Json fil.
    Spelar även lite ljud när användaren väljer att klicka på valet av kille eller tjej, samt visar vilket val som gjorts*/

    void Start()
    {

        slidebarAgeText.text = sliderAge.value.ToString();
        slidebarWeightText.text = sliderWeight.value.ToString();
        foreach (Button button in buttonSex)
        {
            button.onClick.AddListener(() => SetGender(button));
        }
    }
    public void SaveToJson()
    {
        _userData.age = (int)sliderAge.value;
        _userData.weight = (int)sliderWeight.value;

        if (hasInput())
        {
            DataHandler.SaveUserDataToFile(_userData);
            // string dataUser = JsonUtility.ToJson(_userData, true);
            // System.IO.File.WriteAllText(Application.persistentDataPath + "UserData.json", dataUser);

            sceneController.LoadScene("Menu");

        }
    }
    public bool hasInput() { return _userData.age > 0 && _userData.weight > 0 && _userData.sex != null ? true : false; }

    private void SetGender(Button btn)
    {

        foreach (Button b in buttonSex)
        {
            if (b.name == "Button_Female")
            {
                b.GetComponent<Image>().sprite = girl;
            }
            else
            {

                b.GetComponent<Image>().sprite = boy;
            }
        }
        if (btn.name == "Button_Male")
        {
            soundBoyHello.Play();
            btn.GetComponent<Image>().sprite = boyPressed;
            _userData.sex = "Male";
        }
        else
        {
            soundGirlHello.Play();
            btn.GetComponent<Image>().sprite = girlPressed;
            _userData.sex = "Female";
        }
    }

    public void OnSildeBarTextChange()
    {
        slidebarAgeText.text = sliderAge.value.ToString();
        slidebarWeightText.text = sliderWeight.value.ToString();
    }
}









