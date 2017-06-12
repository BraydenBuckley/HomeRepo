using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour {

	//--------------------------------------------------------------------------------------
	//	OnTriggerEnter()
	// Trigger detection, Detects when the player passes through the trigger box and sets isAtHeat varible to true
	//
	// Param:
	//		Collider other - The collider of any objects that pass into this trigger
	// Return:
	//		Void
	//--------------------------------------------------------------------------------------
	void OnTriggerEnter(Collider player){
		if (player.tag == "Player") {
			FindObjectOfType<Controller> ().isAtHeat = true;
		}
	}
	//--------------------------------------------------------------------------------------
	//	OnTriggerExit()
	// Trigger detection, Detects when the player leaves the trigger box and sets isAtHeat varible to false
	//
	// Param:
	//		Collider other - The collider of any objects that pass into this trigger
	// Return:
	//		Void
	//--------------------------------------------------------------------------------------
	void OnTriggerExit(Collider player){
		if (player.tag == "Player") {
			FindObjectOfType<Controller> ().isAtHeat = false;
		}
	}
}
