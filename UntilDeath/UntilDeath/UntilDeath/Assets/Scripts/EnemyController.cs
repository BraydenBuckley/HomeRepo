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

	// Use this for initialization
	void Start () {

//		myTransform = transform;
		player = GameObject.FindGameObjectWithTag("Player");
		navAgent = GetComponent<NavMeshAgent> ();

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
