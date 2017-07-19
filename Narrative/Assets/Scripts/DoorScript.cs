using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour {

	public bool doorOpen = false;
	public GameObject door;
	public GameObject doorText;
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay (Collider other){
		if (other.tag == "Player") {

			doorText.SetActive (true);

			if (Input.GetKeyDown (KeyCode.E)) {
				door.GetComponent<Animator> ().Play ("DoorOpen");
			}
		}
	}

	void OnTriggerExit( Collider other){
		if (other.tag == "Player") {
			doorText.SetActive (false);
		}
	}
}
