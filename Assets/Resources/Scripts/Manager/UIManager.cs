using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject[] health;
    [SerializeField] private TextMeshProUGUI scoreText;
    public static UIManager Instance;
    public GameObject pauseUI;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause(true);
        }
    }

    public void UpdateScore(int value)
    {
        scoreText.text = "Score : " + value;
    }

    public void Pause(bool value)
    {
        if (value)
        {
            Time.timeScale = 0;
            pauseUI.SetActive(true);   
        }
        else
        {
            Time.timeScale = 1;
            pauseUI.SetActive(false);
        }
    }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UpdateHealth(PlayerManager.Instance.Health);
    }

    public void UpdateHealth(int value)
    {
        if (value == 0)
        {
            health[0].SetActive(false);
            health[1].SetActive(false);
            health[2].SetActive(false);
        }
        if (value == 1)
        {
            health[0].SetActive(true);
            health[1].SetActive(false);
            health[2].SetActive(false);
        }
        if (value == 2)
        {
            health[0].SetActive(true);
            health[1].SetActive(true);
            health[2].SetActive(false);
        }
        if (value == 3)
        {
            health[0].SetActive(true);
            health[1].SetActive(true);
            health[2].SetActive(true);
        }
    }
}
