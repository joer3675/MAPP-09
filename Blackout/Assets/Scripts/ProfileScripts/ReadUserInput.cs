using UnityEngine;
using UnityEngine.UI;
public class ReadUserInput : MonoBehaviour
{
    private UserData _userData = new UserData();
    public ButtonParticleEffect buttonEffectMale;
    public ButtonParticleEffect buttonEffectFemale;
    [SerializeField] private Button buttonSave;
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
    [SerializeField] private AudioSource saveSound;
    [SerializeField] private AudioSource saveSoundFail;

    /*Detta script används då användaren ska skapa en "profil". Läser in all information som användaren väljer, samt sparar ned det till en Json fil.
    Spelar även lite ljud när användaren väljer att klicka på valet av kille eller tjej, samt visar vilket val som gjorts*/

    void Start()
    {
        if (!hasInput())
        {
            buttonSave.GetComponent<Image>().color = new Color32(128, 128, 128, 255);
            buttonSave.GetComponentInChildren<Text>().color = new Color32(211, 211, 211, 255);
        }
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
            buttonSave.GetComponent<Animator>().SetTrigger("Click");
            buttonEffectMale.playEffect();
            buttonEffectFemale.playEffect();
            saveSound.Play();
            DataHandler.SaveUserDataToFile(_userData);
            // string dataUser = JsonUtility.ToJson(_userData, true);
            // System.IO.File.WriteAllText(Application.persistentDataPath + "UserData.json", dataUser);

            sceneController.LoadScene("Menu");

        }
        else
        {
            saveSoundFail.Play();
        }

    }
    public bool hasInput() { return _userData.age > 0 && _userData.weight > 0 && _userData.sex != null ? true : false; }

    private void SetGender(Button btn)
    {

        foreach (Button b in buttonSex)
        {
            if (b.name == "Button_Female")
            {
                //b.GetComponent<Image>().sprite = girl;
                b.transform.parent.GetChild(0).gameObject.GetComponent<Image>().sprite = girl;
            }
            else
            {
                b.transform.parent.GetChild(0).gameObject.GetComponent<Image>().sprite = boy;
                //b.GetComponentInParent<Image>().sprite = boy;
            }
        }
        if (btn.name == "Button_Male")
        {
            soundBoyHello.Play();
            //btn.GetComponent<Image>().sprite = boyPressed;
            btn.transform.parent.GetChild(0).gameObject.GetComponent<Image>().sprite = boyPressed;
            _userData.sex = "Male";
        }
        else
        {
            soundGirlHello.Play();
            btn.transform.parent.GetChild(0).gameObject.GetComponent<Image>().sprite = girlPressed;
            // btn.GetComponent<Image>().sprite = girlPressed;
            _userData.sex = "Female";
        }
        buttonSave.GetComponent<Image>().color = new Color32(0, 171, 102, 255);
        buttonSave.GetComponentInChildren<Text>().color = Color.white;
    }

    public void OnSildeBarTextChange()
    {
        slidebarAgeText.text = sliderAge.value.ToString();
        slidebarWeightText.text = sliderWeight.value.ToString();
    }
}









