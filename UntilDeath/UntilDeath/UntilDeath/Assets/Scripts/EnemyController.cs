using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour {

	//A float to hold the attack range of the enemies
	public float attackRange = 3;
	//A Gameobject to hold the playe prefab
	public GameObject player;
	//Holds the nav mesh agent component
	public NavMeshAgent navAgent;
	//Holds the normal zombie prefab
	public GameObject normalZombie;
	//The two spawn points for normal zombies after large zombies death
	public Transform normZomSpawn;
	public Transform normZomSpawn2;
	//Hods the death particle prefab
	public GameObject ZombieDeath;
	//Variables for the health and damage of the different zombie types
	public float health;
	public float damage;

	//--------------------------------------------------------------------------------------
	//	Start()
	// Runs during initialisation. Finds the player gameobject, and allocate the enemies NavMeshAgent
	//
	// Param:
	//		None
	// Return:
	//		Void
	//--------------------------------------------------------------------------------------
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		navAgent = GetComponent<NavMeshAgent> ();

	}

	//--------------------------------------------------------------------------------------
	//	TakeDamage()
	// Takes the bullet damage from the health of the enemy and checks if they have 0 health,
	// if so killing/destroying the enemy will playing the death particle effect
	//
	// Param:
	//		float damage - A float thet holds the varrying bullet damage values
	// Return:
	//		Void
	//--------------------------------------------------------------------------------------
	public void TakeDamage(float damage){
		health = health - damage;
		if (health <= 0) {
			if(this.gameObject.tag==("LargeEnemy")){
				Instantiate (normalZombie, normZomSpawn.transform.position, Quaternion.identity);
				Instantiate (normalZombie, normZomSpawn2.transform.position, Quaternion.identity);
				GameObject death = Instantiate (ZombieDeath, this.gameObject.transform.position, Quaternion.identity);
				Debug.Log (FindObjectOfType<Drops> ().killCounter);
				FindObjectOfType<Drops> ().killCounter++;
				Destroy (this.gameObject);
				Destroy (death, 2);
			} else{
			GameObject death = Instantiate (ZombieDeath, this.gameObject.transform.position, Quaternion.identity);
				Debug.Log (FindObjectOfType<Drops> ().killCounter);
				FindObjectOfType<Drops> ().killCounter++;
				Destroy (this.gameObject);
				Destroy (death, 2);
				Debug.Log (FindObjectOfType<Drops> ().killCounter);
			}
		}
	}
	
	//--------------------------------------------------------------------------------------
	//	Update()
	// Runs before each frame. And moves the enemy towards the current player position while 
	// constantly looking at the player
	//
	// Param:
	//		None
	// Return:
	//		Void
	//--------------------------------------------------------------------------------------
	void Update () {

		if (Vector3.Distance (transform.position, player.transform.position) > attackRange) {
			navAgent.destination = player.transform.position;
			transform.LookAt (player.transform.position);
		}
	}
}
