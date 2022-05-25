using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.Networking;

public class ShowImage : MonoBehaviour
{
    public GameObject BlackoutImage;
    private Sprite last_screenshot_save;

    private void Start()
    {
        string path = Application.persistentDataPath + "//blackout_image.png";
        ScreenCapture.CaptureScreenshot(path);
        last_screenshot_save = LoadSprite(path);
        BlackoutImage.GetComponent<SpriteRenderer>().sprite = last_screenshot_save;
    }

    private Sprite LoadSprite(string path)
    {
        if (string.IsNullOrEmpty(path)) return null;
        if (System.IO.File.Exists(path))
        {
            byte[] bytes = System.IO.File.ReadAllBytes(path);
            Texture2D texture = new Texture2D(1, 1);
            texture.LoadImage(bytes);
            Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            return sprite;
        }
        return null;
    }
}