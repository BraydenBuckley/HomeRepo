using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public GameObject movementMarker;
	public GameObject Player;

	public LayerMask raycastLayerMask;
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		float distanceOfRay = 100;
		if (Physics.Raycast (ray, out hit, distanceOfRay, raycastLayerMask)) {
			
			if (Input.GetMouseButton (0)) {
				if (hit.transform.tag == "Ground") {
					movementMarker.transform.position = hit.point;

					Player.GetComponent<Playa> ().MovePlayer (hit.point);
				}
			} else if (Input.GetMouseButton (1)) {
				if (hit.transform.tag == "Enemy") {
					Debug.DrawLine (Player.transform.position, hit.transform.position, Color.yellow, 0.1f);
					Player.GetComponent<Playa> ().Attack (hit.transform.position); 
				}
			}
		}
	}
}
