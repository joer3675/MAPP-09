using UnityEngine;
using UnityEngine.Audio;

public class PitchSlidebar : MonoBehaviour
{
    public AudioMixer mixer;
    public AudioSource audioSource;

    public void SetPitchLevel(float sliderValue)
    {
        if (Application.platform == RuntimePlatform.WebGLPlayer)
        {
            audioSource.pitch = sliderValue / 100;
        }
        else
        {
            mixer.SetFloat("MusicPitch", sliderValue / 100);
        }

    }
    public void playAudio()
    {
        if (!audioSource.isPlaying)
            audioSource.Play();
    }

    public void stopAudio()
    {
        audioSource.Stop();
    }
}
