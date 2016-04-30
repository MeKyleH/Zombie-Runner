using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public int maxHealth = 100;
	public LevelManager levelManager;

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
		if (health <= 0 && gameObject.tag == "Player") {
			levelManager.LoadLevel ("01a Start");
		} else if (health <= 0) {
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
