using UnityEngine;
using System.Collections;
using UnityEditor;


//Author: [jonnoWaite]

public class PlatformerAutoScene : EditorWindow {

    GameObject levelManager, hud, player;
    bool isPressed;

    [MenuItem("jPltfrm/Auto Scene Setup")]
    public static void AutoSetup() {

        EditorWindow.GetWindow(typeof(PlatformerAutoScene));
    }

    void OnGUI() {

        levelManager = (GameObject)Resources.Load("LevelManager");
        hud = (GameObject)Resources.Load("arthurHUD");
        player = (GameObject)Resources.Load("arthurPlayer");

        isPressed = (GUI.Button(new Rect (10, 10, 100, 30), "Setup Scene"));

        if (isPressed) {

            Instantiate(levelManager);
            Instantiate(hud);
            Instantiate(player);
            
        }

    }
}
