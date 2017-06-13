using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XboxCtrlrInput;

public class PlayerController : MonoBehaviour {

	//Controls movement speed of player
	public float movementSpeed = 60;
	public float maxSpeed = 5;
	//Get the player rigidbody
	public Rigidbody rb;
	//Gets controller input
	public XboxController controller;

	//Get UI health slider
	public Slider healthSlider;
	public GameObject uiCanvas;
	public GameObject deathCanvas;
	//Sets the previous rotation to vector forward
	public Vector3 previousRotationDirection = Vector3.forward;
	//Sets player health amount
	public float health = 10;
	//Players weapon types
	public GameObject pistol;
	public GameObject machineGun;
	public GameObject sniper;

	public Transform partSpawn;
	public bool isDead = false;

	//--------------------------------------------------------------------------------------
	//	Start()
	// Runs during initialisation. Gets player rigidbody and set the UI slider to link with health
	//
	// Param:
	//		None
	// Return:
	//		Void
	//--------------------------------------------------------------------------------------
	void Start () {

		rb = GetComponent<Rigidbody> ();
		healthSlider.value = health;

	}
	
	//--------------------------------------------------------------------------------------
	//	Update()
	// Runs every frame. Checks if player is alive, if so runs RotatePlayer function
	//
	// Param:
	//		None
	// Return:
	//		Void
	//--------------------------------------------------------------------------------------
	void Update () {
		if (health > 0) {
			RotatePlayer ();
		}

		if (health <= 0) {
			uiCanvas.SetActive (false);
			deathCanvas.SetActive (true);
		}
	}

	//--------------------------------------------------------------------------------------
	//	RotatePlayer()
	// Gets right stick input and rotates the player accordingly
	//
	// Param:
	//		None
	// Return:
	//		Void
	//--------------------------------------------------------------------------------------
	private void RotatePlayer (){
	
		float rotateAxisX = XCI.GetAxis (XboxAxis.RightStickX, controller);
		float rotateAxisZ = XCI.GetAxis (XboxAxis.RightStickY, controller);
		Vector3 directionVector = new Vector3 (rotateAxisX, 0, rotateAxisZ);

		if (directionVector.magnitude < 0.1f) {
			directionVector = previousRotationDirection;
		}
		directionVector = directionVector.normalized;
		previousRotationDirection = directionVector;
		transform.rotation = Quaternion.LookRotation (directionVector);

	}

	//--------------------------------------------------------------------------------------
	//	FixedUpdate()
	// Runs before physics caluculations. Checks is player is alive, if yes runs MovePlayer
	//
	// Param:
	//		None
	// Return:
	//		Void
	//--------------------------------------------------------------------------------------
	void FixedUpdate(){
		if (health > 0) {
			MovePlayer ();
		}

	}

	//--------------------------------------------------------------------------------------
	//	MovePlayer()
	// Gets left stick input and moves the player in the direction of the stick at the 
	// movement speed set
	//
	// Param:
	//		None
	// Return:
	//		Void
	//--------------------------------------------------------------------------------------
	private void MovePlayer(){		
		float axisX = XCI.GetAxis (XboxAxis.LeftStickX, controller);
		float axisZ = XCI.GetAxis (XboxAxis.LeftStickY, controller);
		Vector3 movement = new Vector3 (axisX, 0, axisZ);
		rb.AddForce (movement * movementSpeed);
			if (rb.velocity.magnitude > maxSpeed) {
				rb.velocity = rb.velocity.normalized * maxSpeed;

		}
	}

	//--------------------------------------------------------------------------------------
	//	OnTriggerEnter()
	// Trigger detection. If the player collides with an enemy they take damage accordingly, 
	// and if health equals 0 kill the player
	//
	// Param:
	//		None
	// Return:
	//		Void
	//--------------------------------------------------------------------------------------
	void OnTriggerEnter(Collider other){
		if (other.tag == "Enemy" || other.tag == "LargeEnemy") {
			if (isDead) {
				return;
			}
			if (health < 1) {
				maxSpeed = 0;
				movementSpeed = 0;
				isDead = true;
				return;
			} else {
				health = health - other.GetComponent<EnemyController> ().damage;
				healthSlider.value = health;
			}

		}
	}	
}
