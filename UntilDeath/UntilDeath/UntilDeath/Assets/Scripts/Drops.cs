using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drops : MonoBehaviour {

	public int killCounter;
	public List<GameObject> gunDropsList = new List<GameObject> ();
	public Transform dropLocation;

	
	// Update is called once per frame
	void Update () {
		//Debug.Log (killCounter);
		if (killCounter >= 20) {
			killCounter = 0;
			GameObject dropToSpawn = gunDropsList [Random.Range (0, gunDropsList.Count)]; 
			Instantiate (dropToSpawn,dropLocation.transform.position, dropToSpawn.transform.rotation); 
		}
	}
}
