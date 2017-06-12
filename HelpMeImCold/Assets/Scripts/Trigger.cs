using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour {

	//public bool atHeat;

	// Use this for initialization
	void Start () {
	}
	
	void OnTriggerEnter(Collider player){
		if (player.tag == "Player") {
			FindObjectOfType<Controller> ().isAtHeat = true;
		}
	}
	void OnTriggerExit(Collider player){
		if (player.tag == "Player") {
			FindObjectOfType<Controller> ().isAtHeat = false;
		}
	}
}
