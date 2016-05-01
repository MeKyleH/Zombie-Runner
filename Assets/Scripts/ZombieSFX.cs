using UnityEngine;
using System.Collections;

public class ZombieSFX : MonoBehaviour {

	public AudioClip[] audioClips;

	private bool justPlayedSFX = false;
	private float lastSFXTime;
	private AudioSource audioSource;
	private int soundDelay = 0;

	void Start () {
		audioSource = FindObjectOfType<AudioSource> ();
		if (!audioSource) {
			Debug.Log (name + " did not find audioSource at start");
		}
		soundDelay = getSoundDelay ();
	}
	
	void Update () {
		if (soundDelay == 0) {
			soundDelay = getSoundDelay ();
		}
		//allows a sound to be played every 5 seconds
		if (justPlayedSFX && Time.timeSinceLevelLoad - lastSFXTime >= soundDelay) {
			justPlayedSFX = false;
		}

		//playsound if ready
		if (!justPlayedSFX) {
			justPlayedSFX = true;
			soundDelay = 0;
			lastSFXTime = Time.timeSinceLevelLoad;
			int clipInt = getRandomSound ();
			audioSource.clip = audioClips [clipInt];
			audioSource.Play ();
		}
	}

	private int getRandomSound() {
		return Random.Range (0, audioClips.Length-1);
	}

	private int getSoundDelay() {
		return Random.Range (5, 20);
	}

}

