using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinTrigger : MonoBehaviour
{
    [SerializeField] private AudioClip sfx;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Action();
        }
    }

    protected virtual void Action()
    {
        GameManager.Instance.Score++;
        if (sfx != null)
        {
            AudioManager.Instance.PlayAudio(sfx);
        }
        Destroy(gameObject);
    }
}
