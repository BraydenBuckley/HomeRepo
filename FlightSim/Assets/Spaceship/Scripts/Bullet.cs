
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public int damage = 20;

	// Use this for initialization
	void Start () {
		Destroy (this.gameObject, 4f);
	}

	//When the ball hits something, the function will activate.
	void OnTriggerEnter(Collider other){
//		Debug.Log("Ow");
//
//		if (other.tag == "Player") {
//			other.GetComponent<TankController> ().TakeDamage (damage);
//		}

		//Destroy (this.gameObject);
	}
}