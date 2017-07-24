using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleCollision : MonoBehaviour {

	public AudioSource bottleSound;

	void Start(){
		bottleSound = GetComponent<AudioSource> ();
	}

	void OnCollisionEnter(Collision other){
		if (other.collider.tag == "Player") {
			bottleSound.Play();
		}
	}
}
