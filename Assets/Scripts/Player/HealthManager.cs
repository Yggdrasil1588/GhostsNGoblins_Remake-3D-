using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

//Author: [jonnoWaite]

public class HealthManager : MonoBehaviour {

    public int maxPlayerHealth;
    public static int playerHealth;
    public bool isDead;

    Text text;

    private LevelManager levelManager;

	void Start () {

        text = GetComponent<Text>();
        playerHealth = maxPlayerHealth;
        levelManager = FindObjectOfType<LevelManager>();
        isDead = false;
	}

	void Update () {

        if (playerHealth < 0 && !isDead){

            playerHealth = 0;
            levelManager.RespawnPlayer();
            isDead = true;
        }

        text.text = "x " + playerHealth;
	}

    public static void HurtPlayer(int damageToGive) {

        playerHealth -= damageToGive;
    }

    public void FullHealth() {

        playerHealth = maxPlayerHealth;
    }

}