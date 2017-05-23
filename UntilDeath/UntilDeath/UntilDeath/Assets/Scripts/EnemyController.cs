using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour {

//	public Transform player;
//	private Transform myTransform;
//	public float speed = 3f;
//	public float attackRange = 1f;
//	public int attackDamage = 1;
//	public float timeBetweenAttacks;

	public float attackRange = 1;
	public GameObject player;
	public NavMeshAgent navAgent;

	public GameObject ZombieDeath;

	public float health;

	// Use this for initialization
	void Start () {

//		myTransform = transform;
		player = GameObject.FindGameObjectWithTag("Player");
		navAgent = GetComponent<NavMeshAgent> ();

	}

	public void TakeDamage(float damage){
		health = health - damage;
		if (health <= 0) {
			GameObject death = Instantiate (ZombieDeath, this.gameObject.transform.position, Quaternion.identity);
			Destroy (this.gameObject);
			Destroy (death, 2);
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (Vector3.Distance (transform.position, player.transform.position) > attackRange) {
			navAgent.destination = player.transform.position;
			transform.LookAt (player.transform.position);
		}

//		if (Vector3.Distance (player.position, myTransform.position) > attackRange) {
//			transform.LookAt (player.position);
//			myTransform.position += myTransform.forward * speed * Time.deltaTime;
//		}
		
	}
}
