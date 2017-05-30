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

	public float attackRange = 3;
	public GameObject player;
	public NavMeshAgent navAgent;
	public GameObject normalZombie;

	public Transform normZomSpawn;
	public Transform normZomSpawn2;

	public GameObject ZombieDeath;

	public float health;
	public int damage;

	// Use this for initialization
	void Start () {

//		myTransform = transform;
		player = GameObject.FindGameObjectWithTag("Player");
		navAgent = GetComponent<NavMeshAgent> ();

	}

	public void TakeDamage(float damage){
//		health = health - damage;
//		if (health <= 0) {
//			GameObject death = Instantiate (ZombieDeath, this.gameObject.transform.position, Quaternion.identity);
//			Destroy (this.gameObject);
//			Destroy (death, 2);
//			//UpdateCounter ();
//		}
		health = health - damage;
		if (health <= 0) {
			if(this.gameObject.tag==("LargeEnemy")){
				Instantiate (normalZombie, normZomSpawn.transform.position, Quaternion.identity);
				Instantiate (normalZombie, normZomSpawn2.transform.position, Quaternion.identity);
				GameObject death = Instantiate (ZombieDeath, this.gameObject.transform.position, Quaternion.identity);
				Destroy (this.gameObject);
				Destroy (death, 2);
			} else{
			GameObject death = Instantiate (ZombieDeath, this.gameObject.transform.position, Quaternion.identity);
			Destroy (this.gameObject);
			Destroy (death, 2);
			//UpdateCounter ();
			}
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
