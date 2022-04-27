using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class AvatarAssigner : MonoBehaviour
{
    private VariableData _userData = new VariableData();
    
        [SerializeField] Sprite manAvatar;
        [SerializeField] Sprite womanAvatar;
        [SerializeField] Sprite nonbinaryAvatar;

        void Awake()
        {
       //_userData = gameObject.GetComponent<VariableData>();

        }
            
                    
        void Start()
        {

            string json = File.ReadAllText(Application.persistentDataPath + "UserData.json");
            VariableData data = JsonUtility.FromJson<VariableData>(json);

            _userData.sex = data.sex;
            _userData.age = data.age;
            _userData.weight = data.weight;
            _userData.currentIndex = data.currentIndex;
            _userData.History = data.History;


            Debug.Log(_userData.sex + " is the sex.");
            Debug.Log(_userData.age + " is the age.");

    }

}


[System.Serializable]
public class VariableData
{
    public string sex;
    public int age, weight;
    public int currentIndex = 0;
    public List<History> History = new List<History>();

}