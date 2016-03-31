using UnityEngine;
using System.Collections;

public class Zombie : MonoBehaviour {

	public int seenEverySeconds;
	private Animator animator;
	private NavMeshAgent navMeshAgent;

	void Start () {
		navMeshAgent = GetComponent<NavMeshAgent> ();
		animator = GetComponent<Animator> ();
	}
	
	void OnTriggerEnter(Collider collider) {
		if (collider.tag == "Player") {
			print ("attacking");
			animator.SetTrigger ("isAttacking");
			navMeshAgent.velocity = Vector3.zero;
		}
	}

	void OnTriggerStay(Collider collider) {
		if (collider.tag == "Player") {
			print ("attacking");
			animator.SetTrigger ("isAttacking");
			navMeshAgent.velocity = Vector3.zero;
		}
	}
}
