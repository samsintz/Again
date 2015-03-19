using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class gameOverScript : MonoBehaviour {

	public Text score;
	public Text hiScore;
	private int scoreVal;
	// Use this for initialization
	void Start () {
		scoreVal = PlayerPrefs.GetInt ("score");

		//make sure the score is positive due to collision bug
		if (scoreVal > -1) {
			score.text = "score: " + scoreVal.ToString ();
		}
		//check that highscore exists and initilize it if not, otherwise update. 
		if (PlayerPrefs.HasKey("hiScore") == false || scoreVal > PlayerPrefs.GetInt ("hiScore")) {
			PlayerPrefs.SetInt("hiScore", scoreVal);
		}

		hiScore.text = "high score: " + PlayerPrefs.GetInt ("hiScore").ToString ();
	}
	
	public void reStart() {
		Application.LoadLevel (1);
	}
}