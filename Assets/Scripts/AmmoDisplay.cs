using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent (typeof(Text))]
public class AmmoDisplay : MonoBehaviour {

	private Text ammoText;
	private int ammo = 10;
	public enum Status {SUCCESS, FAILURE};

	void Start () {
		ammoText = gameObject.GetComponent<Text> ();
		UpdateDisplay ();
	}

	public void AddAmmo(int amount) {
		ammo += amount;
		UpdateDisplay ();
	}

	public Status UseAmmo(int amount) {
		if (ammo >= amount) {
			ammo -= amount;
			UpdateDisplay ();
			return Status.SUCCESS;
		}
		return Status.FAILURE;
	}

	private void UpdateDisplay(){
		if (ammoText) {
			ammoText.text = ammo.ToString ();
		} else {
			ammoText = GameObject.FindObjectOfType<Text> ();
			if (ammoText) {
				ammoText.text = ammo.ToString ();
			} else {
				Debug.Log ("Error finding ammoText");
			}
		}
	}
}