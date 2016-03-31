using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour {

	public ParticleSystem muzzleFlash;
	Animator animator;
	public ParticleSystem impactFlash;
	public AudioClip gunshot;

	private AudioSource audioSource;

	void Start () {
		audioSource = GetComponent<AudioSource> ();
		animator = GetComponentInChildren<Animator> ();
	}
	
	void Update () {
		if (Input.GetButtonDown ("Fire1")) {
			muzzleFlash.Play ();
			audioSource.clip = gunshot;
			audioSource.Play ();
			animator.SetTrigger ("firingTrigger");

			// shooting
			RaycastHit hit;
			if (Physics.Raycast (transform.position, transform.forward, out hit, 50f)) {
				
				if (hit.transform.tag == "Enemy") {
					Destroy (hit.transform.gameObject);
				}
				impactFlash.transform.position = hit.point;
				impactFlash.Play ();
			}
		}

	}
}
