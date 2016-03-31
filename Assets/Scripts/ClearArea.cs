using UnityEngine;
using System.Collections;

public class ClearArea : MonoBehaviour {

	public float timeSinceLastTrigger = 0f;

	private bool foundClearArea = false;
	
	void Update () {
		timeSinceLastTrigger += Time.deltaTime;

		if (timeSinceLastTrigger > 2f && Time.realtimeSinceStartup > 30f && !foundClearArea && !IsUnderWater()) {
			//finds method called OnFindClearArea in any ancestors
			foundClearArea = true;
			SendMessageUpwards ("OnFindClearArea");
		}
	}

	bool IsUnderWater() {
		return gameObject.transform.position.y < 44.6f;
	}

	void OnTriggerStay(Collider collider) {
		if (collider.tag != "Player") {
			timeSinceLastTrigger = 0f;
		}
	}
}
