using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour {

	public GameObject doorTrigger;
	public GameObject player;
	public GameObject back1;
	public GameObject back2;
	public bool dresserTrigger;
	public bool deskTrigger;
	public bool hallwayTrigger;
	public bool finalTrigger;
	public float speed;

	public AudioSource sparks;

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			if (dresserTrigger == true) {
				//play flicker sound and light animation
				sparks.Play();
			} else if (deskTrigger == true) {
				doorTrigger.SetActive (true);
				//sparks.Pause ();
			} else if (hallwayTrigger == true) {
				player.GetComponent<PlayerController> ().walkSpeed = speed;
				player.GetComponent<PlayerController> ().runSpeed = speed;
				player.GetComponent<PlayerController> ().strafeSpeed = speed;
				if (finalTrigger == true) {
					back1.SetActive (false);
					back2.SetActive (true);
				}

			}
		}
	}
}
