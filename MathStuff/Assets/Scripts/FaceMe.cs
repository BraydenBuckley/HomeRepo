using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceMe : MonoBehaviour {

	public Transform objectToFace;
	
	// Update is called once per frame
	void Update () {
		transform.LookAt (objectToFace);
	}
}
