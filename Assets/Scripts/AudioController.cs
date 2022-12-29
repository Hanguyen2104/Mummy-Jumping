using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController Instance;
    public AudioSource musicAus;
    public AudioSource sfxAus;

    public AudioClip jump;
    public AudioClip getCollectable;
    public AudioClip gameover;


    private void Awake()
    {
        if (Instance)
        {
            Destroy(Instance);
        }
        else
        {
            Instance = this;

        }
    }

    public void PlaySound(AudioClip sound)
    {
        musicAus.PlayOneShot(sound);
    }
    public void PlayBackGroundMusic()
    {
        sfxAus.Play();
    }
}
