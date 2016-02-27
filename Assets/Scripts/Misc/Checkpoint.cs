using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

//Author: [jonnoWaite]

public class Checkpoint : MonoBehaviour {

    public LevelManager levelManager;

    void Start() {

        levelManager = FindObjectOfType<LevelManager>();
    }

    void OnTriggerEnter(Collider other) {

        if (other.tag == "Player") {
            levelManager.currentCheckpoint = gameObject;
        }
    }

}