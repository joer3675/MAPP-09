using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
 
public class DisplayImage : MonoBehaviour
{
    Texture2D thisTexture;
    byte[] bytes;
    string fileName;
    public GameObject[] ImageHolder = new GameObject[1];
 
    // Start is called before the first frame update
    void Start()
    {
        var imagesToLoad = Directory.GetFiles(Application.persistentDataPath + "/screenshots", "*.png"); //insert locatin of file storage
        for (int i = 0; i < imagesToLoad.Length; i++)
        {
            thisTexture = new Texture2D(100, 100);
            fileName = imagesToLoad[i];
            bytes = File.ReadAllBytes(fileName);
            thisTexture.LoadImage(bytes);
            thisTexture.name = fileName;
            ImageHolder[i].GetComponent<RawImage>().texture = thisTexture;
        }
    }
}