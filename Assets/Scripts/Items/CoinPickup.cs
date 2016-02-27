using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

//Author: [jonnoWaite]

public class CoinPickup : MonoBehaviour {

    public int pointsToAdd;
	public GameObject pickupParticle;

    void OnTriggerEnter(Collider other) {

        if (other.GetComponent<PlayerController>() == null) {
            return;
        }

        ScoreManager.AddPoints(pointsToAdd);

		Instantiate(pickupParticle, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(gameObject);
    }

}