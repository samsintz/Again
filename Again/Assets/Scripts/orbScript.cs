using UnityEngine;
using System.Collections;

public class orbScript : MonoBehaviour {

	private GameObject player; //where the orb travels to
	private playerScript playerScript;
	private bool gameOver;

	public float speed = 5f;

	void Start() {
		player = GameObject.Find ("player");
		playerScript = player.GetComponent<playerScript> ();

		gameOver = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!gameOver) {
			transform.position = Vector3.MoveTowards (transform.position, player.transform.position, speed * Time.deltaTime);
		} else {
			Debug.Log ("recieved");
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.name != "bodyCollider") {
			playerScript.collide ();
		}
	}
}