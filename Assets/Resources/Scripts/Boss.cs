using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private AudioClip audio;
    [SerializeField] private Transform[] attackPoint;
    [SerializeField] private GameObject attackPrefabs;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private float attackRange;
    [SerializeField] private float attackCooldown;
    private float nextAttack;
    private bool canAttack = true;
    private void OnEnable()
    {
        animator = GetComponent<Animator>();
        GameManager.Instance.SwitchCamera(GameManager.Instance.bossCamera.gameObject, 3);
        AudioManager.Instance.PlayMusic(audio);
        animator.SetTrigger("Show");
        Invoke(nameof(StopAudio), 3);
    }

    private void Attack()
    {
        if (Time.time >= nextAttack)
        {
            nextAttack = Time.time + attackCooldown;
            Vector2 direction;
            if (transform.localScale.x < 0)
            {
                direction = Vector2.right;
            }
            else
            {
                direction = Vector2.left;
            }

            RaycastHit2D hit = Physics2D.Raycast(attackPoint[1].position, direction, attackRange, playerLayer);
            if (hit.collider != null)
            {
                PlayerManager.Instance.Health--;
            }
        }
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
