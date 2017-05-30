using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public GameObject bloodSplatter;
	public float damage;

	public bool isSniperBullet;

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
