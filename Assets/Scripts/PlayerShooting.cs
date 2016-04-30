using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour {

	public ParticleSystem muzzleFlash;
	Animator animator;
	public ParticleSystem impactFlash;
	public AudioClip gunshot;
	public int power;

	private AmmoDisplay ammoDisplay;
	private AudioSource audioSource;

	void Start () {
		audioSource = GetComponent<AudioSource> ();
		animator = GetComponentInChildren<Animator> ();
		ammoDisplay = GameObject.FindObjectOfType<AmmoDisplay>();
	}
	
	void Update () {
		if (Input.GetButtonDown ("Fire1") && ammoDisplay.UseAmmo(1) == AmmoDisplay.Status.SUCCESS) {
			Shoot();
		}
	}

	void Shoot() {
		muzzleFlash.Play ();
		audioSource.clip = gunshot;
		audioSource.Play ();
		animator.SetTrigger ("firingTrigger");

		RaycastHit hit;
		if (Physics.Raycast (transform.position, transform.forward, out hit, 50f)) {
			
			if (hit.transform.tag == "Enemy") {
				Health enemyHealth = hit.transform.gameObject.GetComponent<Health> ();
				enemyHealth.DealDamage(power);
			}
			impactFlash.transform.position = hit.point;
			impactFlash.Play ();
		}
	}
}
