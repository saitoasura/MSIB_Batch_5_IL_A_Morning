using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private float health = 100;
    [SerializeField] private UIManager _uiManager;
    public PlayerController playerController;

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

    // Update is called once per frame
    void Update()
    {

    }
}
