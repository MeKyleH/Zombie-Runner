using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject[] zombiePrefabArray;

	private bool isPlayerInRange = false; 

	void Update () {
		if (isPlayerInRange) {
			foreach (GameObject thisZombie in zombiePrefabArray) {
				if (IsTimeToSpawn (thisZombie)) {
					Spawn (thisZombie);
				}
			}
		}
	}

	bool IsTimeToSpawn(GameObject zombieGameObject) {
		Zombie zombie = zombieGameObject.GetComponent<Zombie> ();
		float meanSpawnDelay = zombie.seenEverySeconds;
		float spawnsPerSecond = 1 / meanSpawnDelay;

		//can't spawn faster than frame rate
		if (Time.deltaTime > meanSpawnDelay) {
			Debug.LogWarning ("Spawn rate capped by frame rate");
		}

		//normalizes spawn time
		float threshold = spawnsPerSecond * Time.deltaTime;
		return Random.value < threshold;
	}

	public void Spawn(GameObject myGameObject) {
		GameObject myZombie = Instantiate (myGameObject) as GameObject;
		myZombie.transform.parent = transform;
		myZombie.transform.position = transform.position;
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.tag == "Player") {
			Debug.Log ("Player In range");
			isPlayerInRange = true;
		}
	}

	void OnTriggerExit(Collider collider) {
		if (collider.tag == "Player") {
			Debug.Log ("Player out of range");
			isPlayerInRange = false;
		}
	}
}
