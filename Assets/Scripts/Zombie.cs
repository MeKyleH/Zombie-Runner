using UnityEngine;
using System.Collections;

public class Zombie : MonoBehaviour {

	public int seenEverySeconds;
	public int power;

	private Animator animator;
	private NavMeshAgent navMeshAgent;
	private bool attacking = false;

	void Start () {
		navMeshAgent = GetComponent<NavMeshAgent> ();
		animator = GetComponent<Animator> ();
	}
	
	void OnTriggerEnter(Collider collider) {
		if (collider.tag == "Player" && !attacking) {
			Debug.Log (collider.transform.name);
			AttackPlayer (collider);
		}
	}

	void OnTriggerStay(Collider collider) {
		if (collider.tag == "Player" && !attacking) {
			AttackPlayer (collider);
		}
	}

	void AttackPlayer (Collider collider)
	{
		print ("attacking");
		attacking = true;
		Health playerHealth = collider.transform.GetComponent<Health> ();
		if (playerHealth) {
			Debug.Log ("Found Player!");
			playerHealth.DealDamage (power);
		}
		animator.SetTrigger ("isAttacking");
		Invoke ("DoneAttacking", 0.8f);
		navMeshAgent.velocity = Vector3.zero;
	}

	void DoneAttacking() {
		attacking = false;
	}

}