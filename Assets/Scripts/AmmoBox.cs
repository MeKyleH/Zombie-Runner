using UnityEngine;
using System.Collections;

public class AmmoBox : MonoBehaviour {

	public int ammoValue;

	private AmmoDisplay ammoDisplay;

	void Start() {
		ammoDisplay = GameObject.FindObjectOfType<AmmoDisplay>();
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.tag == "Player") {
			ammoDisplay.AddAmmo (ammoValue);
			Destroy (gameObject);
		}
	}
}
