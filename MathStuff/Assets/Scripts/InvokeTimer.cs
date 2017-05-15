using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvokeTimer : MonoBehaviour {

	private bool canShoot = true;
	public float timeBetweenShots = 0.2f;

	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.Space)) {
			if (canShoot == true) {
				Debug.Log ("Pew");
				canShoot = false;
				Invoke ("ResetShootBool", timeBetweenShots);
			}
		}

	}

	private void ResetShootBool(){
		canShoot = true;
	}
}
