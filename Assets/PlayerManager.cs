//#define OLD_CODE

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private int health;
    private Animator animator;
    public static PlayerManager Instance;
    [SerializeField] private float attackRange;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private Transform attackPoint;

    #region Unity Region
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    
    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0)) 
        {
            Attack();
        }
    }

    #endregion

    public int Health
    {
        get
        {
            return health;
        }
        set
        {
            health = value;
            UIManager.Instance.UpdateHealth(health);
            if (isDeath())
            {
                Death();
            }
        }
    }

    public bool isDeath()
    {
        if (Health <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Death()
    {
        animator.SetTrigger("Death");
    }

    private void Attack()
    {
        animator.SetTrigger("Attack");
        Vector2 direction;
        Debug.Log((transform.localScale.x));
        if (transform.localScale.x < 0)
        {
           direction = Vector2.right;
        }
        else
        {
            direction = Vector2.left;
            ;
        }
        RaycastHit2D hit = Physics2D.Raycast(attackPoint.position, direction,  attackRange, enemyLayer);
        if (hit.collider != null)
        {
            hit.collider.GetComponent<Enemy>().Death();
        }
        
    }

    #region OLD CODE

#if OLD_CODE
    [SerializeField] private float health = 3;
    [SerializeField] private UIManager _uiManager;
    public static PlayerManager Instance;
    public PlayerController playerController;

    private void Awake()
    {
        Instance = this;
    }

    public float Health
    {
        get
        {
            return health;
        }

        set
        {
            health = value;
            UIManager.Instance.UpdateHealth(health);
        }
    }
    void Start()
    {
        _uiManager = UIManager.Instance;
        _uiManager.UpdateHealth(health);
        playerController = GetComponent<PlayerController>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Health--;
            if (CheckDeath())
            {
                Death();
            }
        }
    }

    private void Death()
    {
        SceneManager.LoadScene("Base");
    }

    private bool CheckDeath()
    {
        if (Health <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
#endif

    #endregion
}
