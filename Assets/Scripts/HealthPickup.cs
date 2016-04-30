using UnityEngine;
using System.Collections;

public class HealthPickup : MonoBehaviour {

	public int healthValue;

	private Health health;
	private AudioSource audioSource;


	void Start() {
		health = GameObject.FindObjectOfType<Health>();
		audioSource = FindObjectOfType<AudioSource> ();
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.tag == "Player" && health.health < health.maxHealth) {
			health.Heal (healthValue);
			audioSource.Play ();
			Destroy (gameObject);
		}
	}
}
