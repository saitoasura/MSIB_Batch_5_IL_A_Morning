using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CameraFollow : MonoBehaviour
{
    private Transform target;
    private float smoothSpeed = 0.12f;
    [SerializeField] private Vector3 offset;

    private void Start()
    {
        target = PlayerManager.Instance.transform;
    }

    private void LateUpdate()
    {
        if (target != null)
        {
            Vector3 newPosition = target.position + offset;
            Vector3 smoothPos = Vector3.Lerp(transform.position, newPosition, smoothSpeed);
            transform.position = new Vector3(smoothPos.x, smoothPos.y, transform.position.z);
        }
    }
}
