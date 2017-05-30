using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class GunScript : MonoBehaviour {

	public int maxAmmo;
	public float fireRate;
	public int currentAmmo;
	public float reloadTime;
	public float shootingTimer;
	public int clipSize;
	public int damage;
	public int health;

	public GameObject bulletPrefab;
	public Transform bulletSpawnPoint;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (FindObjectOfType<PlayerController> ().health != 0) {
			FireGun ();
		}
	}
	private void FireGun(){

		if (XCI.GetAxis (XboxAxis.RightTrigger) > 0.15f) {
			if (Time.time - shootingTimer > fireRate) {
				//if (ammoAmount > 0) {
				GameObject GO = Instantiate (bulletPrefab, bulletSpawnPoint.position, Quaternion.identity) as GameObject;
				GO.GetComponent<Rigidbody> ().AddForce (transform.forward * 20, ForceMode.Impulse);
				Destroy (GO, 3);
				shootingTimer = Time.time;
				//ammoAmount = ammoAmount - 1;
				//}
			}
		}

	}
}
