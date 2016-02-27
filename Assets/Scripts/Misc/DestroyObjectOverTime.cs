using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

//Author: [jonnoWaite]

public class DestroyObjectOverTime : MonoBehaviour {

    public float lifeTime;

	void Update () {

        lifeTime -= Time.deltaTime;

        if (lifeTime < 0) {
            Destroy(gameObject);
        }
	
	}

}