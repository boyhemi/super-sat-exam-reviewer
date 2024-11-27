using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

enum musicType{
    einstein = 0,
    sabrina = 1
}
public class AudioController : MonoBehaviour
{
    [SerializeField] AudioSource audio;
    [SerializeField] AudioClip[] audioClips;
    // Start is called before the first frame update

    public static AudioController Instance {get; private set;}

    public void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void PlaySabrinaWinBGM()
    {
        audio.clip = audioClips[(int)musicType.sabrina];
        audio.Play();
    }

    public void PlayEinsteinWinBGM()
    {
        audio.clip = audioClips[(int)musicType.einstein];
        audio.Play();
    }

    public void StopMusic()
    {
        audio.Stop();
    }

}
