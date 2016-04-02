using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthDisplay : MonoBehaviour {

	private Text healthText;

	void Awake () {
		healthText = gameObject.GetComponent<Text> ();
	}

	public void UpdateDisplay(int health){
		if (healthText) {
			healthText.text = health.ToString ();
		} else {
			healthText = GameObject.FindObjectOfType<Text> ();
			if (healthText) {
				healthText.text = health.ToString ();
			} else {
				Debug.Log ("Error finding healthText");
			}
		}
	}
}