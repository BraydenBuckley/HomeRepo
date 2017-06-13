using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class GunScript : MonoBehaviour {

	//Holds the different gun stat variables
	public float fireRate;
	public float shootingTimer;
	//Holds the bullet prefab and spawn point
	public GameObject bulletPrefab;
	public Transform bulletSpawnPoint;

	//--------------------------------------------------------------------------------------
	//	Update()
	// Runs before each frame. Checks if player is alive, if so runs fire gun function
	//
	// Param:
	//		None
	// Return:
	//		Void
	//--------------------------------------------------------------------------------------
	void Update () {
		if (FindObjectOfType<PlayerController> ().health > 0) {
			FireGun ();
		}
	}
	//--------------------------------------------------------------------------------------
	//	FireGun()
	// Gets called every frame the player is alive. Gets right trigger input and creates a bullet
	// from the set points
	//
	// Param:
	//		None
	// Return:
	//		Void
	//--------------------------------------------------------------------------------------
	private void FireGun(){

		if (XCI.GetAxis (XboxAxis.RightTrigger) > 0.15f) {
			if (Time.time - shootingTimer > fireRate) {
				GameObject GO = Instantiate (bulletPrefab, bulletSpawnPoint.position, Quaternion.identity) as GameObject;
				GO.GetComponent<Rigidbody> ().AddForce (transform.forward * 30, ForceMode.Impulse);
				Destroy (GO, 3);
				shootingTimer = Time.time;
			}
		}

	}
}
