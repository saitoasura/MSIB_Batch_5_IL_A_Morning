using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Slider sliderHealth;
    [SerializeField] private TextMeshProUGUI healthText;
    public static UIManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void UpdateHealth(float value)
    {
        sliderHealth.value = value/100;
        healthText.text = value.ToString();
    }
}
