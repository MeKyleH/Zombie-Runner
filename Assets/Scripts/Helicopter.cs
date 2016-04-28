using UnityEngine;
using System.Collections;

public class Helicopter : MonoBehaviour {

	private bool called = false;
	private Transform targetLocation;
	private GameObject targetObject;
	private float speed = 30f;

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
		called = true;
	}
}
