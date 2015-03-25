using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerScript : MonoBehaviour {
	private float degree;
	private bool gameOver;
	private GameObject spawnController; 
	private spawnScript spawnScript;
	private Animator anim;

	public float speed;
	public int score;
	public Text scoreRender;
	public float delayAmount;
	public float pulseDelay;
	public Sprite pulse;
	public Sprite normal;

	// Use this for initialization
	void Start () {
		speed = 30f;
		score = 0;
		degree = 0f;
		delayAmount = 0.05f;
		pulseDelay = 0.1f;
		gameOver = false;

		spawnController = GameObject.Find ("spawnController");
		spawnScript = spawnController.GetComponent<spawnScript>();
		anim = GameObject.Find ("fade").GetComponent<Animator> ();
	}
	
	void Update() 
	{
		if (!gameOver) {
			//rotation controls
			if (Input.GetKeyUp (KeyCode.RightArrow)) {
				degree -= 90f;
			}
			if (Input.GetKeyUp (KeyCode.LeftArrow)) {
				degree += 90f;
			}
			//use slerp for animation
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, degree), speed * Time.deltaTime);
		}

	}

	public void collide() {
		if (!gameOver) {
			score ++;

			if(spawnScript.spawnDelay > 1.01f) {
				spawnScript.spawnDelay -= Mathf.Log (spawnScript.spawnDelay, 10f);
			}
			else {
				if (spawnScript.spawnDelay > 0.5f) {
					spawnScript.spawnDelay -= delayAmount;
					Debug.Log (spawnScript.spawnDelay);
				}
			}
			//display score
			scoreRender.text = score.ToString();
			//pulse triangle
			transform.gameObject.GetComponent<SpriteRenderer> ().sprite = pulse;
			StartCoroutine (switchAnim(pulseDelay));
		}
	}

	public void setGameOver() {
		gameOver = true;

		//store score in PlayerPrefs to be accessed in game over scene;
		PlayerPrefs.SetInt ("score", score);

		//hide the score for fade out
		scoreRender.text = "";
		//start fade out animation
		anim.SetInteger ("AnimState", 1);
		//wait before exiting scene
		StartCoroutine (fadeOut ());
	}

	IEnumerator switchAnim(float seconds) {
		yield return new WaitForSeconds (seconds);
		transform.gameObject.GetComponent<SpriteRenderer> ().sprite = normal;
	}

	IEnumerator fadeOut() {
		yield return new WaitForSeconds(1.3f);
		Application.LoadLevel (2);
	}
}
