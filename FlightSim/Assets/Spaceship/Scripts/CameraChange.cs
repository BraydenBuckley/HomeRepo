using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange: MonoBehaviour {

	public GameObject mainCamera;
	public Transform frontCameraPos;
	public Transform backCameraPos;

	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.LeftShift)) {
			mainCamera.transform.position = frontCameraPos.transform.position;
			mainCamera.transform.rotation = frontCameraPos.transform.rotation;
		} else {
			mainCamera.transform.position = backCameraPos.transform.position;
			mainCamera.transform.rotation = backCameraPos.transform.rotation;
		}
	}
}
