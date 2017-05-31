using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpTrigger : MonoBehaviour {

	//A list to hold the different gun types
	public List<GameObject> gunList = new List<GameObject>();
	//A int to reference the gun being picked up
	public int gunReference =0;

	//--------------------------------------------------------------------------------------
	//	Start()
	// Runs during initialisation. Fills the list with weapons
	//
	// Param:
	//		none
	// Return:
	//		Void
	//--------------------------------------------------------------------------------------
	void Start(){
		gunList [0] = FindObjectOfType<PlayerController> ().pistol;
		gunList [1] = FindObjectOfType<PlayerController> ().machineGun;
		gunList [2] = FindObjectOfType<PlayerController> ().sniper;
	}

	//--------------------------------------------------------------------------------------
	//	OnTriggerEnter()
	// Trigger detection. Detects the collision on the pickup item
	//
	// Param:
	//		Collider other - checks to see if what collides with the pickup is the player
	// Return:
	//		Void
	//--------------------------------------------------------------------------------------
	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			if (gunList [gunReference]) {
				gunList [0].SetActive (false);
				gunList [1].SetActive (false);
				gunList [2].SetActive (false);
				gunList [gunReference].SetActive (true);
				Destroy (this.gameObject);
			}
		}
	}
}
