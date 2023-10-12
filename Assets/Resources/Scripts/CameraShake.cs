using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private Vector3 originalPosition;
    [SerializeField] private float shakeDuration = 3f;
    [SerializeField] private float shakeMagnitude = 0.5f;
    [SerializeField] private float shakeSpeed = 1f;
    private float duration;
    public bool shake = true;

    private void OnEnable()
    {
        originalPosition = transform.position;
    }

    private void Update()
    {
        if (shake)
        {
            CameraShakes();
        }
    }

    public void CameraShakes()
    {
        if (duration > 0)
        {
            transform.position = originalPosition + Random.insideUnitSphere * shakeMagnitude;
            duration -= Time.deltaTime * shakeSpeed;
        }
        else
        {
            duration = shakeDuration;
            transform.position = originalPosition;
            //shake = false;
        }
    }
}
