using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public Transform player;
	private Transform myTransform;
	public float speed = 3f;
	public float attackRange = 1f;
	public int attackDamage = 1;
	public float timeBetweenAttacks;

	// Use this for initialization
	void Start () {

		myTransform = transform;

	}
	
	// Update is called once per frame
	void Update () {



		if (Vector3.Distance (player.position, myTransform.position) > attackRange) {
			//transform.Translate (new Vector3 (speed * Time.deltaTime, 0, 0));
			transform.LookAt (player.position);
			myTransform.position += myTransform.forward * speed * Time.deltaTime;
		}
		
	}
}
