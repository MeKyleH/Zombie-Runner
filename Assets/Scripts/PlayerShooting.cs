using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour {

	public ParticleSystem muzzleFlash;
	Animator animator;
	public ParticleSystem impactFlash;

	void Start () {
		animator = GetComponentInChildren<Animator> ();
	}
	
	void Update () {
		if (Input.GetButtonDown ("Fire1")) {
			muzzleFlash.Play ();
			animator.SetTrigger ("firingTrigger");
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
