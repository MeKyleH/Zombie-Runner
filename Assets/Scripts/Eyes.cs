using UnityEngine;
using System.Collections;

public class Eyes : MonoBehaviour {

	private Camera eyes;
	private float defaultFOV;
	private float zoomFOV;
	private float currentZoom;

	void Start () {
		eyes = GetComponent<Camera> ();
		defaultFOV = eyes.fieldOfView;
		currentZoom = defaultFOV;
		zoomFOV = defaultFOV / 1.5f;
	}

	void Update () {
		//Zoom (v) pressed
		if (Input.GetButton("Zoom") && currentZoom >= zoomFOV) {
			//TODO REFACTOR WITH TIME.DELTATIME TO GET GRADUAL ZOOMING IN AND OUT
			eyes.fieldOfView = defaultFOV / 1.5f;
		} else {
			eyes.fieldOfView = defaultFOV;
		}
	}
}
