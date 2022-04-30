using UnityEngine;
using UnityEngine.UI;
public class ReadUserInput : MonoBehaviour
{
    private UserData _userData = new UserData();
    //[SerializeField] private SwapScene swapScene;
    [SerializeField] private Dropdown dropDownSex;
    [SerializeField] private InputField inputFieldAge, inputFieldWeight;


    public void SaveToJson()
    {
        int.TryParse(inputFieldAge.text, out _userData.age);
        int.TryParse(inputFieldWeight.text, out _userData.weight);
        _userData.sex = dropDownSex.options[dropDownSex.value].text;

        if (hasInput())
        {
            string dataUser = JsonUtility.ToJson(_userData, true);
            System.IO.File.WriteAllText(Application.persistentDataPath + "UserData.json", dataUser);
            SwapScene.LoadScene("Menu");
        }
    }
    public bool hasInput() { return _userData.age > 0 && _userData.weight > 0 ? true : false; }

}









