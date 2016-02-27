using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

//Author: [jonnoWaite]

public class LevelLoader : MonoBehaviour {

    private bool playerInZone;

    public string levelToLoad;

	void Start () {

        playerInZone = false;
	}

	void Update () {
        
        if (Input.GetAxis("Vertical") > 0 && playerInZone) {
            Application.LoadLevel(levelToLoad);
        }
	}

    void OnTriggerEnter2D(Collider2D other) {

        if(other.tag == "Player"){
            playerInZone = true;
        }
    }

    void OnTriggerExit2D(Collider2D other) {

        if (other.tag == "Player") {
            playerInZone = false;
        }
    }

}