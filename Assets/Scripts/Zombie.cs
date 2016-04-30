using UnityEngine;
using System.Collections;

public class Zombie : MonoBehaviour {

	public int seenEverySeconds;
	public int power;
	public float maxPlayerDistance;

	private GameObject player;
	private Animator animator;
	private NavMeshAgent navMeshAgent;
	private bool attacking = false;
	public float playerDistance;

	void Start () {
		navMeshAgent = GetComponent<NavMeshAgent> ();
		animator = GetComponent<Animator> ();
		player = GameObject.FindGameObjectWithTag ("Player");

		if (!player) {
			Debug.Log ("Zombie couldn't find player");
		}
	}

	void Update() {
		playerDistance = (transform.position - player.transform.position).sqrMagnitude;
		if (playerDistance >= maxPlayerDistance) {
			Destroy (gameObject);
		}
	}
	
	void OnTriggerEnter(Collider collider) {
		if (collider.tag == "Player" && !attacking) {
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
		attacking = true;
		Health playerHealth = collider.transform.GetComponent<Health> ();
		if (playerHealth) {
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