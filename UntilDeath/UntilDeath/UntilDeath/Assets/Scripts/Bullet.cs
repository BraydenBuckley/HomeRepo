using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public GameObject bloodSplatter;
	public float damage = 1;

	void OnTriggerEnter(Collider other){
		if (other.tag == "Enemy" || other.tag=="LargeEnemy") {
			GameObject blood = Instantiate (bloodSplatter, this.gameObject.transform.position, Quaternion.identity);
			other.GetComponent<EnemyController>().TakeDamage(damage);
			Destroy (this.gameObject);
			Destroy (blood, 1);
		}
	}
}
