using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Regen : PowerUp
{
   [SerializeField] private int regenHealth;
   protected override void OnTriggerEnter2D(Collider2D other)
   {
      if (other.CompareTag("Player"))
      {
         var player = other.GetComponent<PlayerManager>();
         //player.Health += regenHealth;
         GetComponent<Collider2D>().enabled = false;
         GetComponent<Animator>().SetTrigger("PowerUp");
         //Invoke(nameof(DestroyObject), 1);
         StartCoroutine(DestroyObject());
      }
   }
}
