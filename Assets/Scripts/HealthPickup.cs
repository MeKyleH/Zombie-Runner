using UnityEngine;
using System.Collections;

public class HealthPickup : MonoBehaviour {

	public int healthValue;

	private Health health;

	void Start() {
		health = GameObject.FindObjectOfType<Health>();
	}

	void OnTriggerEnter(Collider collider) {
		Debug.Log ("Collision Detected");
		if (collider.tag == "Player" && health.health < health.maxHealth) {
			health.Heal (healthValue);
			Destroy (gameObject);
		}
	}
}
