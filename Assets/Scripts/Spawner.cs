using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject[] zombiePrefabArray = new GameObject[1];
	public float maxPlayerDistance, minPlayerDistance;
	public float playerDistance;

	private bool justSpawned = false;
	private float lastSpawnTime;
	private int spawnCount = 0;

	private GameObject player;

	void Start() {
		player = GameObject.FindGameObjectWithTag ("Player");
		if (!player) {
			Debug.Log (name+ " did not find Player at start");
		}
	}

	void Update () {
		//spawns one per second to simulate a hoard
		if (justSpawned && Time.timeSinceLevelLoad - lastSpawnTime >= 1) {
			justSpawned = false;
		}

		if (IsPlayerInRange() && !justSpawned && spawnCount < 5) {
			foreach (GameObject thisZombie in zombiePrefabArray) {
				spawnCount++;
				justSpawned = true;
				lastSpawnTime = Time.timeSinceLevelLoad;
				Spawn (thisZombie);
			}
		}

		if (spawnCount >= 5 && transform.childCount == 0) {
			Destroy (gameObject);
		}
	}

	//checks whether the player is within the minimum and maximum distance from the spawner
	private bool IsPlayerInRange() {
		playerDistance = (transform.position - player.transform.position).sqrMagnitude;
		return playerDistance <= maxPlayerDistance && playerDistance >= minPlayerDistance;
	}

	//spawns a zombie
	public void Spawn(GameObject myGameObject) {
		GameObject newZombie = Instantiate (myGameObject) as GameObject;
		newZombie.transform.parent = transform;
		newZombie.transform.position = transform.position;
		newZombie.GetComponent <NavMeshAgent>().enabled = true;
	}
}
