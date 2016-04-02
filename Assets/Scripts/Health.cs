using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public int maxHealth = 100;

	public int health;
	private HealthDisplay healthDisplay;
	private bool isPlayer = false;

	void Start() {
		health = maxHealth;

		if (gameObject.tag == "Player") {
			isPlayer = true;
			healthDisplay = GameObject.FindObjectOfType<HealthDisplay> ();
		}
	}

	public void Heal(int amount) {
		health += amount;
		if (health > maxHealth) {
			health = maxHealth;
		}
		UpdatePlayerHealthDisplay ();
	}

	public void DealDamage(int amount) {
		health -= amount;
		Debug.Log (name + " has " + health + " health and is being damaged by " + amount);
		if (health <= 0) {
			Destroy(gameObject);
		}
		UpdatePlayerHealthDisplay ();
	}

	void UpdatePlayerHealthDisplay() {
		if (isPlayer) {
			healthDisplay.UpdateDisplay (health);
		}
	}
}
