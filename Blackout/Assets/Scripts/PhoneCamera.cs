using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class PhoneCamera : MonoBehaviour
{
    private bool camAvailable;
    private WebCamTexture backCam = null;
    private Texture defaultBackground;
    private int index = 0;

    public RawImage background;
    public AspectRatioFitter fit;

    private void Start()
    {
        defaultBackground = background.texture;
        WebCamDevice[] devices = WebCamTexture.devices;

        if (devices.Length == 0)
        {
            Debug.Log("No camera detected");
            camAvailable = false;
            return;
        }

        for ( int i = 0; i < devices.Length; i++)
        {
            if (!devices[i].isFrontFacing)
            {
                backCam = new WebCamTexture(devices[i].name,Screen.width,Screen.height);
            }
        }

        if (backCam == null)
        {
            Debug.Log("Unable to find back camera");
            return;
        }

        backCam.Play();
        background.texture = backCam;

        camAvailable = true;
    }

    private void Update()
    {
        if (!camAvailable)
        {
            return;
        }

        float ratio = (float)backCam.width / (float)backCam.height;
        fit.aspectRatio = ratio;

        float scaleY = backCam.videoVerticallyMirrored ? -1f : 1f;
        background.rectTransform.localScale = new Vector3(1f, scaleY, 1f);

        int orient = -backCam.videoRotationAngle;
        background.rectTransform.localEulerAngles = new Vector3(0, 0, orient);

        if (Input.GetMouseButtonDown(0))
        {
            SaveImage();
            //backCam.Stop();
        }
    }

    public void SaveImage()
    {
        //Create a Texture2D with the size of the rendered image on the screen.
        Texture2D defaultBackground = new Texture2D(background.texture.width, background.texture.height, TextureFormat.ARGB32, false);

        //Save the image to the Texture2D
        defaultBackground.SetPixels(backCam.GetPixels());
        //GetComponent<Renderer>().material.mainTexture = defaultBackground;

        //for (int y = 0; y < defaultBackground.height; y++)
        //{
        //    for (int x = 0; x < defaultBackground.width; x++)
        //    {
        //        Color color = ((x & y) != 0 ? Color.white : Color.gray);
        //        defaultBackground.SetPixel(x, y, color);
        //    }
        //}
        defaultBackground.Apply();

        //Encode it as a PNG.
        byte[] bytes = defaultBackground.EncodeToPNG();

        //Save it in a file.
        File.WriteAllBytes(Application.persistentDataPath + "blackout_image.png", bytes);
        //index++;
    }

    //private Texture2D ManipulatePixels()
    //{
    //    Texture2D texture = new Texture2D(128, 128);
    //    GetComponent<Renderer>().material.mainTexture = texture;

    //    for (int y = 0; y < texture.height; y++)
    //    {
    //        for (int x = 0; x < texture.width; x++)
    //        {
    //            Color color = ((x & y) != 0 ? Color.white : Color.gray);
    //            texture.SetPixel(x, y, color);
    //        }
    //    }
    //    texture.Apply();
    //    return texture;
    //}
}