using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public class PitchSlidebar : MonoBehaviour
{
    public AudioMixer mixer;
    public AudioSource audioSource;
    private float duration = 0.5f;
    private float targetVolume = 0;

    public void SetPitchLevel(float sliderValue)
    {
        mixer.SetFloat("MusicPitch", sliderValue / 100);
    }
    public void playAudio()
    {
        if (!audioSource.isPlaying)
            audioSource.Play();
    }

    public void stopAudio()
    {
        StartCoroutine(stopDelay());
        audioSource.Stop();
    }

    IEnumerator stopDelay()
    {
        float currentTime = 0;
        float start = audioSource.volume;
        while (currentTime < duration)
        {
            audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
        }
        yield return null;
    }
}
