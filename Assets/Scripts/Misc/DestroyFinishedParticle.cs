using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

//Author: [jonnoWaite]

public class DestroyFinishedParticle : MonoBehaviour {

    private ParticleSystem thisParticleSystem;

	void Start () {

        thisParticleSystem = GetComponent<ParticleSystem>();
	}

	void Update () {
	
        if(thisParticleSystem.isPlaying){
            return;
        }
        Destroy(gameObject);
	}

}