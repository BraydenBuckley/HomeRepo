using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstScript : MonoBehaviour {

	public float upwardsThrust = 40;
	public float rotationalThrust = 5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
//		// While W is held down the onject will move constantly
//		if (Input.GetKey (KeyCode.W)) {
//			//transform.position = transform.position + new Vector3 (0, 0, 0.1f);
//			//transform.position=transform.position+(transform.forward*0.1f);
//			//transform.Rotate(new Vector3(0,1,0));
//			//transform.localScale= transform.localScale+(Vector3.one*0.1f);
//			//gameObject.SetActive(false);
//
//			//------Rigidbody/Physics manipulation
//
//			//gameObject.GetComponent<Rigidbody> ().AddForce(Vector3.up*20);
//			//gameObject.GetComponent<Rigidbody> ().AddForce (transform.up * 20);
//			//gameObject.GetComponent<Rigidbody> ().AddTorque (Vector3.down * 20);
//			//gameObject.GetComponent<Rigidbody> ().useGravity = false;
//		}

		//------Rocket controller


		// Object moves once when E is pressed
//		if (Input.GetKeyDown (KeyCode.E)) {
//			//transform.position = transform.position + new Vector3 (0, 0, -0.1f);
//		}
//		if (Input.GetKey(KeyCode.Space)){
//			gameObject.GetComponent<Rigidbody> ().AddForce (transform.up * 20);
//		}
//		if (Input.GetKey(KeyCode.W)){
//			gameObject.GetComponent<Rigidbody> ().AddForce (transform.forward * 5);
//		}
//		if (Input.GetKey(KeyCode.S)){
//			gameObject.GetComponent<Rigidbody> ().AddForce (transform.forward * -5);
//		}
//		if (Input.GetKey(KeyCode.A)){
//			gameObject.GetComponent<Rigidbody> ().AddForce (transform.right * 5);
//		}
//		if (Input.GetKey(KeyCode.D)){
//			gameObject.GetComponent<Rigidbody> ().AddForce (transform.right * -5);
//		}

		//------Better rocket controller

		if (Input.GetKey(KeyCode.Space)){
			gameObject.GetComponent<Rigidbody> ().AddForce (transform.up * upwardsThrust);
		}
		if (Input.GetKey(KeyCode.W)){
			gameObject.GetComponent<Rigidbody> ().AddTorque (Vector3.left*-rotationalThrust);
		}
		if (Input.GetKey(KeyCode.S)){
			gameObject.GetComponent<Rigidbody> ().AddTorque (Vector3.left*rotationalThrust);
		}
		if (Input.GetKey(KeyCode.A)){
			gameObject.GetComponent<Rigidbody> ().AddTorque (Vector3.forward*rotationalThrust);
		}
		if (Input.GetKey(KeyCode.D)){
			gameObject.GetComponent<Rigidbody> ().AddTorque (Vector3.forward*-rotationalThrust);
		}
	}
}
