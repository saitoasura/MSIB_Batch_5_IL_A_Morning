//#define ANDI

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
#if ANDI
#else
    private int nama;
#endif
    [SerializeField] private Button playButton;

    [SerializeField] private Button exitButton;
    // Start is called before the first frame update
    void Start()
    {
        playButton.onClick.AddListener(LoadLevel);
        exitButton.onClick.AddListener(ExitGame);
    }

    private void OnDestroy()
    {
        playButton.onClick.RemoveAllListeners();
        exitButton.onClick.RemoveAllListeners();
    }

    private void LoadLevel()
    {
        SceneManager.LoadScene("Base");
    }

    private void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
Application.Quit();
#endif
    }
}
