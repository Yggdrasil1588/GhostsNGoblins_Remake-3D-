using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

//Author: [jonnoWaite]

public class MainMenu : MonoBehaviour {

    public string startLevel;
    public int playerLives;

    private GameObject buttons, startText;
    private bool startTextUp, buttonsUp;

    void Start() {

        buttons = GameObject.Find("Buttons");
        startText = GameObject.Find("StartText");
    }

    void Update() {


        if(Input.GetButtonDown("Pause")){
            buttonsUp = !buttonsUp;
        }

        if(buttonsUp){
            buttons.SetActive(true);
            startTextUp = false;
        } else {
            startTextUp = true;
            buttons.SetActive(false);
        }

        if (startTextUp) {
            startText.SetActive(true);
            buttonsUp = false;
        } else {
            startText.SetActive(false);
        }


    }

    public void NewGame() {

        PlayerPrefs.SetInt("PlayerCurrentLives", playerLives);
        PlayerPrefs.SetInt("CurrentScore", 0);
		PlayerPrefs.SetString("CurrentTime", "");

        Application.LoadLevel(startLevel);
    }

    public void QuitGame() {

        Application.Quit();
    }

}