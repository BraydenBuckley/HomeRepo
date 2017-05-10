using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed = 20;
	public float rollWeight = 2;
	public float pitchWeight = 2;

	public float thrust = 5;

	public float maxThrust = 100;
	public float minThrust = 5;

	public Quaternion startingRotation;
	public Vector3 startingPostion;

	//Bullet variables
	public GameObject bulletPrefab;
	public float bulletSpeed = 20;
	public Transform bulletSpawnPoint;
	public Transform bulletSpawnPoint1;
	public GameObject ship;

	// Use this for initialization
	void Start () {

		startingRotation = transform.rotation;
		startingPostion = transform.position;

	}
	
	// Update is called once per frame
	void Update () {

		MovePlayer ();

		CheckPlayerPosition (transform.position.y, -50f, 500f);
		CheckPlayerPosition (transform.position.x, -500f, 500f);
		CheckPlayerPosition (transform.position.z, -500f, 500f);

		if (Input.GetKeyDown (KeyCode.Mouse0) && Input.GetKey (KeyCode.LeftShift)) {

			GameObject GO = Instantiate (bulletPrefab, bulletSpawnPoint.position, ship.transform.rotation) as GameObject;
			GO.GetComponent<Rigidbody> ().AddForce (ship.transform.forward * bulletSpeed, ForceMode.Impulse);
		
		}else{
			
			GameObject GO = Instantiate (bulletPrefab, bulletSpawnPoint.position, ship.transform.rotation) as GameObject;
			GO.GetComponent<Rigidbody> ().AddForce (ship.transform.forward * bulletSpeed, ForceMode.Impulse);

			GameObject GO1 = Instantiate (bulletPrefab, bulletSpawnPoint1.position, ship.transform.rotation) as GameObject;
			GO1.GetComponent<Rigidbody> ().AddForce (ship.transform.forward * bulletSpeed, ForceMode.Impulse);
		
		}

	}

	private void MovePlayer (){
		
		float roll = -rollWeight * Input.GetAxis ("Horizontal");
		float pitch = pitchWeight * Input.GetAxis ("Vertical");
		Vector3 Rotation = new Vector3 (pitch, 0, roll);

		transform.Rotate (Rotation);

		if (Input.GetButton ("Jump")) {
			speed = speed + thrust;

			if (speed > maxThrust) {
				speed = maxThrust;
			}
		} else {
			speed = speed - thrust;

			if (speed < minThrust) {
				speed = minThrust;
			}
		}

		transform.position += transform.forward * speed * Time.deltaTime;
	}
		
	private void ResetPlayer(){
	
		transform.position = startingPostion;
		transform.rotation = startingRotation;

	}

	private void CheckPlayerPosition(float posotionToCheck, float minValue, float MaxValue){

		if (posotionToCheck < minValue || posotionToCheck > MaxValue) {
			ResetPlayer ();
		}
	
//		if (transform.position.y < -50 || transform.position.y > 300){
//			ResetPlayer ();
//		}
//		if (transform.position.x < -300 || transform.position.x > 300){
//			ResetPlayer ();
//		}
//		if (transform.position.z < -300 || transform.position.z > 300){
//			ResetPlayer ();
//
//		}
	}
	void OnCollisionEnter(){
		ResetPlayer ();

		//This code reseys the players speed and angular speed
		GetComponent<Rigidbody> ().angularVelocity = Vector3.zero;
		GetComponent<Rigidbody> ().velocity = Vector3.zero;
	}
}
