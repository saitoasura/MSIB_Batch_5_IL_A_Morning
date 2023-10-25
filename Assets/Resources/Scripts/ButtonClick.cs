using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour
{
    [SerializeField] private AudioClip audio;
    [SerializeField] private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    public void Start()
    {
        _button.onClick.AddListener(()=>AudioManager.Instance.PlayAudio(audio));
    }
}
