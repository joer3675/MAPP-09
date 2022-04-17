using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class WebCam : MonoBehaviour
// {
//     // [SerializedField] RawImage display;a
//     //                   WebCamTexture texture;
//         IEnumerator Start()
//     {
//         findWebCams();

//         yield return Application.RequestUserAuthorization(UserAuthorization.WebCam);
//         if (Application.HasUserAuthorization(UserAuthorization.WebCam))
//         {
//             Debug.Log("webcam found");
//         }
//         else
//         {
//             Debug.Log("webcam not found");
//         }

//         findMicrophones();

//         yield return Application.RequestUserAuthorization(UserAuthorization.Microphone);
//         if (Application.HasUserAuthorization(UserAuthorization.Microphone))
//         {
//             Debug.Log("Microphone found");
//         }
//         else
//         {
//             Debug.Log("Microphone not found");
//         }
//     }

//     public void StartStopCam(){

//     }

// }