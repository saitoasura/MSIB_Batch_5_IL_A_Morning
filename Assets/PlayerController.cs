using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 1;
       private float xvalue;
       public Rigidbody2D rb;
       public float jumpPower;
       public bool isGrounded;
       public Respawn respawn;
       public Animator animator;
   
       //public int score;
       //public TextMeshProUGUI scoreText;
    
    
       private void Start()
       {
          rb = GetComponent<Rigidbody2D>();
          animator = GetComponent<Animator>();
       }
       
    
       private void Update()
       {
         Movement();
         Jump();
         GroudCheck();
         Respawn();
       }

       private void Respawn()
       {
          if (Input.GetKeyDown(KeyCode.Alpha0))
          {
             respawn = FindObjectOfType<Respawn>();
             respawn.RespawnPlayer();
          }
       }
    
       public KeyCode jumpInput;
    
       private void Jump()
       {
          if (Input.GetKeyDown(jumpInput) && isGrounded)
          {
             rb.velocity = new Vector2(0, jumpPower);
          }
       }
    
       private void Movement()
       {
          xvalue = Input.GetAxis("Horizontal");
          if (xvalue != 0 && isGrounded)
          {
             animator.SetBool("Run", true);
          }
          else
          {
             animator.SetBool("Run", false);
          }
          Vector2 direction = new Vector2(xvalue, 0);
          if (xvalue < 0)
          {
             //transform.rotation = new Quaternion(0, 180, 0, 0);
             transform.localScale = new Vector3(-2, 2, 2);
          }
          else
          {
             //transform.rotation = new Quaternion(0, 0, 0, 0);
             transform.localScale = new Vector3(2, 2, 2);
          }
          transform.Translate(direction * Time.deltaTime * speed);
       }
    
       private void OnTriggerEnter2D(Collider2D other)
       {
          if (other.CompareTag("Platform"))
          {
             isGrounded = true;
             //Debug.Log("IS GROUNDED");
          }
          // if (other.CompareTag("Coin"))
          // {
          //    Destroy(other.gameObject);
          //    score++;
          //    scoreText.text = "Score: " + score;
          // }
       }
    
       private void OnTriggerExit2D(Collider2D other)
       {
          if (other.CompareTag("Platform"))
          {
             isGrounded = false;
             Debug.Log("NOT GROUNDED");
          }
       }
    
       private void GroudCheck()
       {
          // if (transform.position.y > -2.38f)
          // {
          //    isGrounded = false;
          // }
          // else
          // {
          //    isGrounded = true;
          // }
       }
}
