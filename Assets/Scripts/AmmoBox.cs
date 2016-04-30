using UnityEngine;
using System.Collections;

public class AmmoBox : MonoBehaviour {

	public int ammoValue;

	private AmmoDisplay ammoDisplay;
	private AudioSource audioSource;

	void Start() {
		ammoDisplay = GameObject.FindObjectOfType<AmmoDisplay>();
		audioSource = FindObjectOfType<AudioSource> ();
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.tag == "Player") {
			ammoDisplay.AddAmmo (ammoValue);
			audioSource.Play ();
			Destroy (gameObject);
		}
	}
}
