using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour {

	//Two list to hold the different spawn points and zombie types
	public List<Transform> spawnPointsList = new List<Transform> ();
	public List<GameObject> zombieTypeList = new List<GameObject> ();
	//Floats to time and control the spawns of the enemies
	public float timeBetweenSpawns;
	public float spawningTimer;
	//Ints that hold the max amount of zombies per wave and the wave number
	public int waveZombieAmount;
	public int waveCounter;
	//A counter to detected when the max zombies has been reached
	public int totalEnemies;
	//Floats to time and control the time between waves
	public float timeBetweenWaves;
	public float waveTimer;
	//A bool that holds the state of player's life
	public bool isDead=false;
	//A text variable to hold the wave number
	public Text waveText;
	public Text finalText;

	//--------------------------------------------------------------------------------------
	//	Start()
	// Runs during initialisation. Assigns the wave counter value to the UI text object
	//
	// Param:
	//		None
	// Return:
	//		Void
	//--------------------------------------------------------------------------------------
	void Start () {
		waveText.text = waveCounter.ToString();
		finalText.text = waveCounter.ToString ();
	}
	
	//--------------------------------------------------------------------------------------
	//	Update()
	// Runs every frame. Constantly checks if player's health is 0 and runs the start wave function
	//
	// Param:
	//		None
	// Return:
	//		Void
	//--------------------------------------------------------------------------------------
	void Update () {
		StartWave ();
		if(FindObjectOfType<PlayerController>().health==0){
				isDead = true;
			}


	}

	//--------------------------------------------------------------------------------------
	//	StartWave()
	// Is called every frame. Spawns enemies until max amount is reached, waits set time and 
	// resets counter and spawns next wave
	//
	// Param:
	//		None
	// Return:
	//		Void
	//--------------------------------------------------------------------------------------
	public void StartWave(){
		Transform spawnPointToUse = null;
		GameObject zombieToSpawn = null;
		if (isDead) {
			return;
		}
		if (Time.time - spawningTimer > timeBetweenSpawns && totalEnemies < waveZombieAmount) {
			spawnPointToUse = spawnPointsList [Random.Range (0, spawnPointsList.Count)]; 
			zombieToSpawn = zombieTypeList [Random.Range (0, zombieTypeList.Count)]; 
			Instantiate (zombieToSpawn, spawnPointToUse.transform.position, Quaternion.identity); 
			spawningTimer = Time.time; 
			waveTimer = Time.time;
			totalEnemies++;
		} 

		if (totalEnemies == waveZombieAmount) {
			if (Time.time - waveTimer > timeBetweenWaves){
				totalEnemies = 0;
				waveZombieAmount += 5;
				waveCounter++;
				waveTimer = Time.time;
				//timeBetweenWaves += 2;
				waveText.text = waveCounter.ToString();
				finalText.text = waveCounter.ToString ();
				Debug.Log (waveCounter + "Finished");

			}
		}
	}
}
