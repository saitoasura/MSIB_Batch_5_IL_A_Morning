using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        
    }

    protected IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
    }
}
