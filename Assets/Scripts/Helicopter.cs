using UnityEngine;
using System.Collections;

public class Helicopter : MonoBehaviour {

	private bool called = false;
	private Rigidbody rigidBody;
	private Transform targetLocation;
	private GameObject targetObject;
	private float speed = 30f;

	void Start () {
		rigidBody = GetComponent<Rigidbody> ();
	}

	void Update() {
		if (called) {
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards (transform.position, targetLocation.position, step);
		}
	}

	void OnDispatchHelicopter() {
		print ("heli called");
		targetObject = GameObject.FindGameObjectWithTag ("Finish");
		targetLocation = targetObject.transform;
		//rigidBody.velocity = new Vector3 (0, 0, 50f);
		called = true;
	}
}
