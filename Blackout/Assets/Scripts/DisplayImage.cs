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
    public void displayImage()
    {
        var imagesToLoad = Directory.GetFiles(Application.persistentDataPath + "/com.DefaultCompany.Blackout", "blackout_image.png"); //insert locatin of file storage
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