using UnityEngine;
using UnityEngine.Audio;

public class PitchSlidebar : MonoBehaviour
{
    public AudioMixer mixer;
    public AudioSource audioSource;

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
        audioSource.Stop();
    }
}
