using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	//The target in which the camera will be following
	public Transform target;
	//the slight delay that makes the camera have to catch up
	public float smoothing = 5;
	//A vector3 that hold the offset amoount
	Vector3 offset;

	//--------------------------------------------------------------------------------------
	//	Start()
	// Runs during initialisation, and sets the offset amount 
	//
	// Param:
	//		None
	// Return:
	//		Void
	//--------------------------------------------------------------------------------------
	void Start(){

		offset = transform.position - target.position;

	}

	//--------------------------------------------------------------------------------------
	//	FixedUpdate()
	// Runs before any physics calculations. Makes the camare follow the target with a predetermined offset
	//
	// Param:
	//		None
	// Return:
	//		Void
	//--------------------------------------------------------------------------------------
	void FixedUpdate(){
		Vector3 targetCamPos = target.position + offset;
		transform.position = Vector3.Lerp (transform.position, targetCamPos, smoothing * Time.deltaTime);
	}

}
