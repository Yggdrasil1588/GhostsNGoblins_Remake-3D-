﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

//Author: [jonnoWaite]

public class ScoreManager : MonoBehaviour {

    public static int score;

    Text text;

    void Start() {

        text = GetComponent<Text>();
        score = PlayerPrefs.GetInt("CurrentScore");
    }

    void Update() {

        if (score < 0) {
            score = 0;
        }

        text.text = "" + score;
    }

    public static void AddPoints(int pointsToAdd) {

        score += pointsToAdd;
        PlayerPrefs.SetInt("CurrentScore", score);
    }

}