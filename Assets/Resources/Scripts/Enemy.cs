using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
   [SerializeField] protected float movSpeed = 3;
   private bool isMovingRight;
   private Rigidbody2D rb;
   private bool isDeath = false;

   protected virtual void Start()
   {
      rb = GetComponent<Rigidbody2D>();
      Invoke(nameof(ChangeDirection), 3);
   }

   protected virtual void Update()
   {
      Movement();
   }

   protected virtual void Movement()
   {
      if (!isDeath)
      {
         if (isMovingRight)
         {
            transform.Translate(Vector2.right * movSpeed * Time.deltaTime);
            transform.localScale = new Vector3(3, 3, 3);
         }
         else
         {
            transform.Translate(Vector2.left * movSpeed * Time.deltaTime);
            transform.localScale = new Vector3(-3, 3, 3);
         }  
      }
   }

   protected virtual void OnCollisionEnter2D(Collision2D other)
   {
      if (other.gameObject.CompareTag("Player"))
      {
         PlayerManager.Instance.Health--;
         Debug.Log(PlayerManager.Instance.Health);
      }
   }

   private void ChangeDirection()
   {
      isMovingRight = !isMovingRight;
      Invoke(nameof(ChangeDirection), 3);
   }

   public void Death()
   {
      if (!isDeath)
      {
         AudioManager.Instance.HitSfx();
         isDeath = true;
         rb.AddForce(Vector2.up * 50, ForceMode2D.Impulse);
         Invoke(nameof(DestroyEnemy), 2);  
      }
   }
   
   void DestroyEnemy()
   {
      Destroy(gameObject);
   }
}
