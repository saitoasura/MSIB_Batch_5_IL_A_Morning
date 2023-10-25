using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public int checkpointID;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Save();
        }
    }

    private void Save()
    {
        PlayerPrefs.SetInt("CurrentCheckpoint", checkpointID);
    }
}
