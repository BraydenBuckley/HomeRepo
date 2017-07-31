using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampScript : MonoBehaviour {

	public bool lightOff = false;
	public GameObject pLight;
	public GameObject sLight;
	public GameObject pSystem;
	public GameObject lampText;
	public GameObject sparkAudio;

	public GameObject cryingAudio;

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerStay (Collider other){
		if (other.tag == "Player") {
			if (lightOff == false) {
				lampText.SetActive (true);
				if (Input.GetKeyDown (KeyCode.E)) {
					pLight.SetActive (false);
					sLight.SetActive (false);
					pSystem.SetActive (false);
					lampText.SetActive (false);
					sparkAudio.GetComponent<AudioSource> ().Pause ();
					lightOff = true;
					Invoke ("CryingDaughter", 1.5f);
				}
			}
		}
	}

	void OnTriggerExit( Collider other){
		if (other.tag == "Player") {
			lampText.SetActive (false);

		}
	}

	public void CryingDaughter(){
		cryingAudio.GetComponent<AudioSource> ().Play ();
	}
}
