using UnityEngine;
using System.Collections;

public class Helicopter : MonoBehaviour {

	private bool called = false;
	private Rigidbody rigidBody;

	void Start () {
		rigidBody = GetComponent<Rigidbody> ();
	}

	void OnDispatchHelicopter() {
		print ("heli called");
		rigidBody.velocity = new Vector3 (0, 0, 50f);
		called = true;
	}
}
