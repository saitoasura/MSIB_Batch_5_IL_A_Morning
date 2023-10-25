using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private AudioClip bgm;
    [SerializeField] private AudioClip hitSfx;
    public static AudioManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayMusic(bgm);
    }

    public void HitSfx()
    {
        PlayAudio(hitSfx);
    }

    public void PlayMusic(AudioClip audio)
    {
        audioSource.Pause();
        if (audio != null)
        {
            audioSource.clip = audio;   
        }
        else
        {
            audioSource.clip = bgm;
        }
        audioSource.Play();
    }

    public void PlayAudio(AudioClip audio)
    {
        audioSource.PlayOneShot(audio);
    }
}
