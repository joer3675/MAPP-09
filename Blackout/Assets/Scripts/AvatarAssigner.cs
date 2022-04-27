using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvatarAssigner : MonoBehaviour
{
    // lite osäker kring hur man ska hämta informationen från det andra scriptet,
    // har nu bara följt en tutorial på yt så vet ej om detta funkar att använda haha...

    ReadUserInput readUserInput;
    UserData userData;
    GameObject playerAvatar;
    [SerializeField] GameObject manAvatar;
    [SerializeField] GameObject womanAvatar;
    [SerializeField] GameObject nonbinaryAvatar;
    


    
    void Awake()
    {
        userData = playerAvatar.GetComponent<UserData>();
    }

    void Start()
    {
        {
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
