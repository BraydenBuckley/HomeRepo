using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour {

	public GameObject doorTrigger;
	public GameObject player;
	public GameObject back1;
	public GameObject back2;

	public GameObject pLight;
	public GameObject sLight;
	public GameObject pSystem;
	public GameObject lockedDoor;
	public GameObject sirenAudio; 

	public bool dresserTrigger;
	public bool deskTrigger;
	public bool hallwayTrigger;
	public bool finalTrigger;
	public float speed;
	public bool sirenTrigger;

	public AudioSource sparks;

	public GameObject policeLights;
	public GameObject carNoise;

	public GameObject blackFade;

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			if (dresserTrigger == true) {
				//play flicker sound and light animation
				sparks.Play ();
				pLight.SetActive (true);
				sLight.SetActive (true);
				pSystem.SetActive (true);
			} else if (deskTrigger == true) {
				doorTrigger.SetActive (true);
			} else if (hallwayTrigger == true) {
				player.GetComponent<PlayerController> ().walkSpeed = speed;
				player.GetComponent<PlayerController> ().runSpeed = speed;
				player.GetComponent<PlayerController> ().strafeSpeed = speed;
				if (finalTrigger == true) {
					back1.SetActive (false);
					back2.SetActive (true);
				}
				if (sirenTrigger == true) {
					sirenAudio.GetComponent<AudioSource> ().Play ();
				}

			} else if (finalTrigger==true) {
				policeLights.SetActive (true);
				carNoise.GetComponent<AudioSource> ().Play ();
				sirenAudio.GetComponent <AudioSource> ().Pause ();
				Invoke ("EndGame", 1);
			}
		}
	}

	void OnTriggerStay(Collider other){
		if (other.tag == "Player") {
			if (finalTrigger == true) {
				if (Input.GetKey (KeyCode.E)) {
					lockedDoor.GetComponent<AudioSource> ().Play ();
				}
			}
		}
	}

	public void EndGame(){
		blackFade.GetComponent<Animator> ().Play ("FadeToBlack");
	}
}
