using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour {

	public AudioClip ringSound;

	void OnTriggerEnter2D(){
		AudioSource.PlayClipAtPoint (ringSound,transform.position);
		Destroy (this.gameObject);
	}
}
