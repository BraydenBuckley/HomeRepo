using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class Vehicle : MonoBehaviour {

	public XboxController controller;
	public List<WheelCollider> wheelList;
	public float enginePower = 150.0f;
	public float steer = 0.0f;
	public float maxSteer = 25.0f;

	public int currentCheckPoint = 0;

	public Vector3 centerOfMass = new Vector3 (0, -0.5f, 0.3f);

	public void HitCheckPoint(int checkPointNumber){
		if (checkPointNumber == currentCheckPoint + 1) {
			currentCheckPoint = checkPointNumber;
		} else {
			Debug.Log("Wrong Checkpoint for" + transform.name);
		}
	}

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody> ().centerOfMass = centerOfMass;
	}
	
	// Update is called once per frame
	void Update () {

		//First section is delcaring a counter variable, i = 0.
		//Second section is the condition that has to be true to make the loop happen, i < wheelList.Count
		//Thirs section the counter will go up by one, i++.
		for (int i = 0; i < wheelList.Count; i++) {
			wheelList [i].motorTorque = enginePower * Time.deltaTime * 250.0f * XCI.GetAxis (XboxAxis.RightTrigger, controller);
		}

		wheelList [0].steerAngle = XCI.GetAxis (XboxAxis.LeftStickX,controller)*maxSteer;
		wheelList [1].steerAngle = XCI.GetAxis (XboxAxis.LeftStickX,controller)*maxSteer;

	}
}
