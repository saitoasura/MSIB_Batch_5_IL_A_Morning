using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private AudioClip audio;
    private void OnEnable()
    {
        animator = GetComponent<Animator>();
        GameManager.Instance.SwitchCamera(GameManager.Instance.bossCamera.gameObject, 3);
        AudioManager.Instance.PlayMusic(audio);
        animator.SetTrigger("Show");
        Invoke(nameof(StopAudio), 3);
    }

    private void StopAudio()
    {
        AudioManager.Instance.PlayMusic(null);
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerManager.Instance.Health--;
            Debug.Log(PlayerManager.Instance.Health);
        }
    }
}
