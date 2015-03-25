using UnityEngine;
using System.Collections;

public class spawnScript : MonoBehaviour {

	public GameObject orb;
	public float spawnDelay = 1.5f;
	private Transform spawn1;
	private Transform spawn2;
	private Transform spawn3;
	private Transform spawn4;

	// Use this for initialization
	void Start () {
		//connect to the spawners 
		spawn1 = this.transform.GetChild (0);
		spawn2 = this.transform.GetChild (1);
		spawn3 = this.transform.GetChild (2);
		spawn4 = this.transform.GetChild (3);
		StartCoroutine ("SpawnHandler");
	}

	private IEnumerator SpawnHandler(){
		float randomSpawn;

		while (true) {
			randomSpawn = Random.Range (1, 5); //returns values 1-4 inclusive

			yield return new WaitForSeconds(spawnDelay); //wait that time
			if(randomSpawn == 1) {
				Instantiate(orb, spawn1.transform.position, Quaternion.identity);
			}
			else if(randomSpawn == 2) {
				Instantiate(orb, spawn2.transform.position, Quaternion.identity);
			}
			else if(randomSpawn == 3) {
				Instantiate(orb, spawn3.transform.position, Quaternion.identity);
			}
			else {
				Instantiate(orb, spawn4.transform.position, Quaternion.identity);
			}
		}
	}


}