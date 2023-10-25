using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UIEffect : MonoBehaviour
{
    private enum UI_EFFECT
    {
        SCALE,
        FADE
    }
    [SerializeField] private UI_EFFECT effectType;
    [SerializeField] private Ease effect;
    [SerializeField] private float duration;

    void OnEnable()
    {
        switch (effectType)
        {
            case UI_EFFECT.SCALE:
                transform.localScale = Vector3.zero;
                transform.DOScale(Vector3.one, duration).SetEase(effect);
                break;
            case UI_EFFECT.FADE:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
