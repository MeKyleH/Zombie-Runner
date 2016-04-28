using UnityEngine;
using System.Collections;

public class Swimmer : MonoBehaviour {

	void Start () {
		RenderSettings.fog = false;
		RenderSettings.fogColor = new Color (0.2f, 0.4f, 0.8f, 0.5f);
		RenderSettings.fogDensity = 0.04f;
	}

	void Update () {
		RenderSettings.fog = IsUnderWater ();
	}

	bool IsUnderWater() {
		return gameObject.transform.position.y < 44.6f;
	}
}
