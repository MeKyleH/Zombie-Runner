using UnityEngine;
using System.Collections;

public class InnerVoice : MonoBehaviour {

	public AudioClip whatHappened;
	public AudioClip goodLandingArea;

	private AudioSource audioSource;

	void Start () {
		audioSource = GetComponent<AudioSource> ();
		audioSource.clip = whatHappened;
		audioSource.Play ();
	}
	
	void OnFindClearArea () {
		print (name + " OnFindClearArea");
		audioSource.clip = goodLandingArea;
		audioSource.Play ();

		Invoke ("CallHeli", goodLandingArea.length + 1f);
	}

	// sends message to radio System
	void CallHeli() {
		SendMessageUpwards ("OnMakeInitialHeliCall");
	}
}
