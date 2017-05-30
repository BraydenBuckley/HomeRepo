﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XboxCtrlrInput;

public class PlayerController : MonoBehaviour {

	public List<GameObject> g = new List<GameObject> ();
	public float movementSpeed = 60;
	public float maxSpeed = 5;

	public Rigidbody rigidbody;
	public XboxController controller;

	public GameObject bulletPrefab;
	public Transform bulletSpawnPoint;
	public float shootingTimer;
	public float timeBetweenShots = 0.02f;
	public int ammoAmount = 20;

	public float flashSpeed = 5f;
	public Image damageImage;
	public Color flashColour = new Color(1f,0f,0f,0.1f);

	public Slider healthSlider;

	public Vector3 previousRotationDirection = Vector3.forward;
	public int health = 10;

	// Use this for initialization
	void Start () {

		rigidbody = GetComponent<Rigidbody> ();
		healthSlider.value = health;

	}
	
	// Update is called once per frame
	void Update () {

		RotatePlayer ();
		FireGun ();
//		UseWeapon();
	}

	private void RotatePlayer (){
	
		float rotateAxisX = XCI.GetAxis (XboxAxis.RightStickX, controller);
		float rotateAxisZ = XCI.GetAxis (XboxAxis.RightStickY, controller);
		Vector3 directionVector = new Vector3 (rotateAxisX, 0, rotateAxisZ);

		//Check to see if the rigth thumbstick is not being used.

		if (directionVector.magnitude < 0.1f) {
			directionVector = previousRotationDirection;
		}
		directionVector = directionVector.normalized;
		previousRotationDirection = directionVector;
		transform.rotation = Quaternion.LookRotation (directionVector);

	}

	void FixedUpdate(){
	
		MovePlayer ();

	}

	private void FireGun(){
	
		if (XCI.GetAxis (XboxAxis.RightTrigger) > 0.15f) {
			if (Time.time - shootingTimer > timeBetweenShots) {
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

	private void MovePlayer(){
	
		float axisX = XCI.GetAxis (XboxAxis.LeftStickX, controller);
		float axisZ = XCI.GetAxis (XboxAxis.LeftStickY, controller);
		Vector3 movement = new Vector3 (axisX, 0, axisZ);
		rigidbody.AddForce (movement * movementSpeed);
		if (rigidbody.velocity.magnitude > maxSpeed) {
			rigidbody.velocity = rigidbody.velocity.normalized * maxSpeed;
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Enemy" || other.tag == "LargeEnemy") {
			health = health - other.GetComponent<EnemyController> ().damage;
			healthSlider.value = health;
			Debug.Log (health);
			damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
		}
	}	
}
