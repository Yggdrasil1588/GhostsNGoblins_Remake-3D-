using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

//Author: [jonnoWaite]

public class LifeManager : MonoBehaviour {

    private int lifeCounter;

    private Text theText;

    public GameObject gameOverScreen;
    public PlayerController player;

    public string mainMenu;
    public float waitAfterGameOver;

	void Start () {

        theText = GetComponent<Text>();
        lifeCounter = PlayerPrefs.GetInt("PlayerCurrentLives");

        player = FindObjectOfType<PlayerController>();
	}

	void Update () {

        if(lifeCounter < 0){
            gameOverScreen.SetActive(true);
            player.gameObject.SetActive(false);
            PlayerPrefs.SetInt("PlayerCurrentLives", 0);
        }

        theText.text = "x " + lifeCounter;

        if (gameOverScreen.activeSelf) {
            waitAfterGameOver -= Time.deltaTime;
        }

        if (waitAfterGameOver < 0) {
            Application.LoadLevel(mainMenu);
        }
	}

    public void AddLife() {

        lifeCounter++;
        PlayerPrefs.SetInt("PlayerCurrentLives", lifeCounter);
    }

    public void SubtractLife(){

        lifeCounter--;
        PlayerPrefs.SetInt("PlayerCurrentLives", lifeCounter);
    }
}