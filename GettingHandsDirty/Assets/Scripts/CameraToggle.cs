using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraToggle : MonoBehaviour {

	public bool topDown;
	public GameObject topDownCamera;

	void Start(){
	
	}
	// Update is called once per frame
	void Update () {

		if (topDown == true) {
			topDownCamera.SetActive (true);
		} else {
			topDownCamera.SetActive (false);
		}
			
	}
}
