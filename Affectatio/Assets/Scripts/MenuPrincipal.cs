﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour {

    public void Game()
    {
        SceneManager.LoadScene("Scene3");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
