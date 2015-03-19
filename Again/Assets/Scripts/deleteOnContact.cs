using UnityEngine;
using System.Collections;

public class deleteOnContact : MonoBehaviour {

	private GameObject spawnController;
	private GameObject player;
	private playerScript playerScript;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("player");
		playerScript = player.GetComponent<playerScript> ();
	}

	void OnTriggerEnter2D(Collider2D other) {
		//make sure we dont collide with ourselves
		if (other.gameObject.name != gameObject.name) {
			Destroy (gameObject);

			//if we collide with the body send gameOver
			if(other.gameObject.name == "bodyCollider") {
				playerScript.setGameOver();
			}
		}

	}
}
