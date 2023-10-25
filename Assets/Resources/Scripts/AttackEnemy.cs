using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemy : Enemy
{
    private Animator _animator;
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private float attackRange;
    private float nextAttack;
    private bool canAttack = true;

    protected override void Start()
    {
        base.Start();
        nextAttack = Time.time + attackCooldown;
        _animator = GetComponent<Animator>();
    }

    protected override void Update()
    {
        base.Update();
        Attack();
    }

    protected override void Movement()
    {
        base.Movement();
    }

    private void Attack()
    {
        if (canAttack)
        {
            if (Time.time >= nextAttack)
            {
                _animator.SetTrigger("Attack");
                nextAttack = Time.time + attackCooldown;
                Vector2 direction;
                if (transform.localScale.x < 0)
                {
                    direction = Vector2.right;
                }
                else
                {
                    direction = Vector2.left;
                    ;
                }
                RaycastHit2D hit = Physics2D.Raycast(attackPoint.position, direction,  attackRange, playerLayer);
                if (hit.collider != null)
                {
                    PlayerManager.Instance.Health--;
                }
            }
        }
    }
}
