using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	//A game object to hold a blood splatter particle prefb
	public GameObject bloodSplatter;
	//A float to hold the damage of the bullet
	public float damage;
	//A bool to determine if the bullet is a sniper bullet
	public bool isSniperBullet;

	//--------------------------------------------------------------------------------------
	//	OnTriggerEnter()
	// Trigger detection, Detects when the bullet hits an enemy and applies damage
	//
	// Param:
	//		Collider other - The collider of any objects that pass into this trigger
	// Return:
	//		Void
	//--------------------------------------------------------------------------------------
	void OnTriggerEnter(Collider other){
		if (other.tag == "Enemy" || other.tag == "LargeEnemy") {
			if (isSniperBullet) {
				GameObject blood = Instantiate (bloodSplatter, this.gameObject.transform.position, Quaternion.identity);
				other.GetComponent<EnemyController> ().TakeDamage (damage);
				Destroy (blood, 1);
			} else {
				GameObject blood = Instantiate (bloodSplatter, this.gameObject.transform.position, Quaternion.identity);
				other.GetComponent<EnemyController> ().TakeDamage (damage);
				Destroy (this.gameObject);
				Destroy (blood, 1);
			}
		}

	}
}
