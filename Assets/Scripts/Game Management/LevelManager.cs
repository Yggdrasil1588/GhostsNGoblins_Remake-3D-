using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

//Author: [jonnoWaite]

//for handling player death/respawn
public class LevelManager : MonoBehaviour {

    public GameObject currentCheckpoint;
    private PlayerController player;
    //private HeadStomp headStomp;
    private LifeManager lifeManager;

	private Rigidbody playerRigidbody;
	private Renderer playerRenderer;
	private CapsuleCollider playerCapsualCollider;
	//private BoxCollider2D headstompCollider;
    private FlyingEnemySpawner[] flyEnemySpawn;

    public GameObject deathParticle, respawnParticle;
    public HealthManager healthManager;

    public float respawnDelay;
    //private float gravityStore;

	void Start () {

        player = FindObjectOfType<PlayerController>();
		//headStomp = FindObjectOfType<HeadStomp>();
        healthManager = FindObjectOfType<HealthManager>();
        flyEnemySpawn = FindObjectsOfType<FlyingEnemySpawner>();

		playerRigidbody = player.GetComponent<Rigidbody>();
		playerRenderer = player.GetComponent<Renderer>();
        playerCapsualCollider = player.GetComponent<CapsuleCollider>();
		//headstompCollider = headStomp.GetComponent<BoxCollider2D>();
        
        //gravityStore = playerRigidbody.gravityScale;
        lifeManager = FindObjectOfType<LifeManager>();
	}

    public void RespawnPlayer() {

        for (int i = 0; i < flyEnemySpawn.Length; i++) {
	        flyEnemySpawn[i].playerInZone = false;
	    }

        StartCoroutine("RespawnPlayerCo");
    }

    public IEnumerator RespawnPlayerCo() {

        player.transform.parent = null;

        Instantiate(deathParticle, player.transform.position, player.transform.rotation);

        playerRigidbody.useGravity = false;
        playerRigidbody.velocity = new Vector2(0, 0);

        player.enabled = false;
        playerRenderer.enabled = false;
        //headstompCollider.enabled = false;
        playerCapsualCollider.enabled = false;

        yield return new WaitForSeconds(respawnDelay);

        playerRigidbody.useGravity = true;
        player.transform.position = currentCheckpoint.transform.position;

        player.enabled = true;
        playerRenderer.enabled = true;
        //headstompCollider.enabled = true;
        playerCapsualCollider.enabled = true;
        
        player.knockBackCount = 0;
        
        lifeManager.SubtractLife();
        healthManager.FullHealth();
        healthManager.isDead = false;

        Instantiate(respawnParticle, currentCheckpoint.transform.position, currentCheckpoint.transform.rotation);
    }

}