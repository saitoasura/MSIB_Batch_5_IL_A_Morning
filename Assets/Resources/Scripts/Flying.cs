using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flying : Enemy
{
    private bool isMoving = false;
    public GameObject vfxPrefabs;
    protected override void Movement()
    {
        if (isMoving)
        {
            transform.Translate(Vector2.down * movSpeed * Time.deltaTime);   
        }
    }

    private void OnDestroy()
    {
        Instantiate(vfxPrefabs, transform.position, transform.rotation);
    }

    protected override void Start()
    {
        GameManager.Instance.OnTrapsEnter += () => { isMoving = true;};
    }

    protected override void OnCollisionEnter2D(Collision2D other)
    {
        base.OnCollisionEnter2D(other);
        if (other.gameObject.CompareTag("Platform"))
        {
            Destroy(gameObject);
        }
    }
}
