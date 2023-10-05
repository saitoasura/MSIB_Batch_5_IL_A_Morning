using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishTrigger : MonoBehaviour
{
    private bool isLoaded;
    public string currentLevel;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (!isLoaded)
            {
                LoadLevel("Level 2");
            }
            //Debug.Log("PLAYER SAMPAI FINISH");
        }
        
    }

    private void UnloadLevel()
    {

    }

    private void LoadLevel(string level)
    {
        isLoaded = true;
        //SceneManager.UnloadSceneAsync(currentLevel);
        SceneManager.LoadScene(level);
    }
}
