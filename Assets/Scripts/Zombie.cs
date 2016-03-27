using UnityEngine;
using System.Collections;

public class Zombie : MonoBehaviour {

	private Transform player;
	private Animator animator;
	private Rigidbody rigidBody;
	private Vector3 startSpeed; 
	private NavMeshAgent navMeshAgent;

	void Start () {
		navMeshAgent = GetComponent<NavMeshAgent> ();
		startSpeed = navMeshAgent.velocity;
		rigidBody = GetComponent<Rigidbody> ();
		animator = GetComponent<Animator> ();
		player = GameObject.FindGameObjectWithTag ("Player").transform;

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

	/*
	 void OnTriggerExit(Collider collider) {
		if (collider.tag == "Player") {
			animator.SetBool ("isAttacking", false);
			print ("not attacking");
			//navMeshAgent.velocity = startSpeed;
		}
	}*/
}
