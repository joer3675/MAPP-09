using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class PhoneCamera : MonoBehaviour
{
    private bool camAvailable;
    private WebCamTexture frontCam = null;
    private Texture defaultBackground;
    private int index = 0;
    [SerializeField] private Animator animator;

    public RawImage background;
    public AspectRatioFitter fit;
    public int imageIdentifier = 0;

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
            if (devices[i].isFrontFacing)
            {
                frontCam = new WebCamTexture(devices[i].name,Screen.width,Screen.height);
            }
        }

        if (frontCam == null)
        {
            Debug.Log("Unable to find front camera");
            return;
        }

        frontCam.Play();
        background.texture = frontCam;

        camAvailable = true;
    }

    private void Update()
    {
        if (!camAvailable)
        {
            return;
        }

        float ratio = (float)frontCam.width / (float)frontCam.height;
        fit.aspectRatio = ratio;

        float scaleY = frontCam.videoVerticallyMirrored ? -1f : 1f;
        background.rectTransform.localScale = new Vector3(1f, scaleY, 1f);

        int orient = -frontCam.videoRotationAngle;
        background.rectTransform.localEulerAngles = new Vector3(0, 0, orient);
    }

    public void SaveImage()
    {
        animator.SetTrigger("TakePic");

        //Create a Texture2D with the size of the rendered image on the screen.
        Texture2D defaultBackground = new Texture2D(background.texture.width, background.texture.height, TextureFormat.ARGB32, false);

        //Save the image to the Texture2D
        defaultBackground.SetPixels(frontCam.GetPixels());
        defaultBackground.Apply();

        //Encode it as a PNG.
        byte[] bytes = defaultBackground.EncodeToPNG();

        //Save it in a file.
        File.WriteAllBytes(Application.persistentDataPath + ".png", bytes);
        index++;
        index = imageIdentifier; 
    }
}