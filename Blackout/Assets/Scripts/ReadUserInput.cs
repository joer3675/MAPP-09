using UnityEngine;
using UnityEngine.UI;
using System.Collections;
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
    [SerializeField] private InputField inputFieldAge, inputFieldWeight;
    [SerializeField] private Text slidebarAgeText;
    [SerializeField] private Text slidebarWeightText;


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
        //int.TryParse(inputFieldAge.text, out _userData.age);
        _userData.age = (int)sliderAge.value;
        _userData.weight = (int)sliderWeight.value;
        //int.TryParse(inputFieldWeight.text, out _userData.weight);
        //_userData.sex = dropDownSex.options[dropDownSex.value].text;

        if (hasInput())
        {
            string dataUser = JsonUtility.ToJson(_userData, true);
            System.IO.File.WriteAllText(Application.persistentDataPath + "UserData.json", dataUser);
            SwapScene.LoadScene("Menu");
        }
    }
    public bool hasInput() { return _userData.age > 0 && _userData.weight > 0 ? true : false; }

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
            btn.GetComponent<Image>().sprite = boyPressed;
            _userData.sex = "Male";
        }
        else
        {
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









