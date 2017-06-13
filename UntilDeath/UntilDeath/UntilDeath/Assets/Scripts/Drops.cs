using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drops : MonoBehaviour {

	public int killCounter;
	public List<GameObject> gunDropsList = new List<GameObject> ();
	public Transform dropLocation;

	
	//--------------------------------------------------------------------------------------
	//	Update()
	// Runs every frame. Constantly checks if the kill counter is 20 if so spawn a random gun and reset counter.
	//
	// Param:
	//		None
	// Return:
	//		Void
	//--------------------------------------------------------------------------------------
	void Update () {
		if (killCounter >= 20) {
			killCounter = 0;
			GameObject dropToSpawn = gunDropsList [Random.Range (0, gunDropsList.Count)]; 
			Instantiate (dropToSpawn,dropLocation.transform.position, dropToSpawn.transform.rotation); 
		}
	}
}
