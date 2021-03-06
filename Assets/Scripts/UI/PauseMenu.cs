﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

//Author: [jonnoWaite]

public class PauseMenu : MonoBehaviour {

    public string mainMenu;

    public bool isPaused;

    public GameObject pauseMenuCanvas;

	void Update () {

        if (isPaused) {
            pauseMenuCanvas.SetActive(true);
            Time.timeScale = 0f;
        } else {
            pauseMenuCanvas.SetActive(false);
            Time.timeScale = 1f;
        }

        if (Input.GetButtonDown("Pause")) {
            isPaused = !isPaused;
        }
	}

    public void Resume() {

        isPaused = false;
    }

    public void Quit() {

        Application.LoadLevel(mainMenu);
    }

}