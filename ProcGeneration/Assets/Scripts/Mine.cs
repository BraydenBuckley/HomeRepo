using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour {

	public Transform marker;
	public GameObject dirtCube;

	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;

		Ray ray = Camera.main.ScreenPointToRay (new Vector3(Screen.width / 2, Screen.height / 2,0));

		float distanceOfRay = 10;

		if(Physics.Raycast(ray,out hit, distanceOfRay)){
			marker.transform.position = hit.transform.position + (hit.normal / 2);

			if (Input.GetMouseButtonDown (1)) {
				Instantiate (dirtCube, hit.transform.position + hit.normal, Quaternion.identity);
			}

			if (Input.GetMouseButtonDown (0)) {
				Destroy (hit.transform.gameObject);
			}
		}
	}
}
