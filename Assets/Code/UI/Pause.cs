﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{

    public GameObject Background;

    public void Toggle()
    {
        if(Background.activeSelf == false)
        {
            // Pause
            Time.timeScale = 0f;
            Background.SetActive(true);
        }
        else
        {
            // unpause
            Time.timeScale = 1f;
            Background.SetActive(false);
        }
    }

    public void QuitToMain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
