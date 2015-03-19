using UnityEngine;
using System.Collections;

public class startScript : MonoBehaviour {
	private Animator anim;
	private Animator textAnim;

	void Start() {
		anim = GetComponent<Animator>();
		textAnim = GameObject.Find ("fade").GetComponent<Animator>();
	}
	void Update() {
		if (Input.GetMouseButtonDown (0)) {
			anim.SetInteger("AnimState", 1);
			textAnim.SetInteger("AnimState", 1);
			StartCoroutine(wait (2.0f));
		}
	}

	IEnumerator wait(float seconds) {
		yield return new WaitForSeconds (seconds);
		Application.LoadLevel(1);
	}
}
