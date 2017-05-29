using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public List<Transform> spawnPointsList = new List<Transform> ();
	public List<GameObject> zombieTypeList = new List<GameObject> ();
	public float timeBetweenSpawns = 5;
	public float spawningTimer;

	public int waveZombieAmount;
	public int waveCounter;
	public int zombiesToKill=5;
	public int totalEnemies;

	public float timeBetweenWaves;
	public float waveTimer;
	// Use this for initialization
	void Start () {
		waveCounter = 1;
		timeBetweenWaves = 5f;
		waveZombieAmount = 1;
		//EnemyController.UpdateZombieCounter (zombiesToKill);
		//EnemyController.UpdateZombieCounter(zombiesToKill);
	}
	
	// Update is called once per frame
	void Update () {
		StartWave ();
	}

	public void StartWave(){
		Transform spawnPointToUse = null;
		GameObject zombieToSpawn = null;
		if (Time.time - spawningTimer > timeBetweenSpawns && totalEnemies < waveZombieAmount) {
			spawnPointToUse = spawnPointsList [Random.Range (0, spawnPointsList.Count)]; 
			zombieToSpawn = zombieTypeList [Random.Range (0, zombieTypeList.Count)]; 
			Instantiate (zombieToSpawn, spawnPointToUse.transform.position, Quaternion.identity); 
			spawningTimer = Time.time; 
			totalEnemies++;
		} 

		if (totalEnemies == waveZombieAmount) {
			if (Time.time - waveTimer > timeBetweenWaves){
				totalEnemies = 0;
				waveZombieAmount += 5;
				waveCounter++;
				waveTimer = Time.time;
			}
		}
//		for (int i = 0; i < waveZombieAmount; i++) {
//			//SpawnEnemy ();
//			Transform spawnPointToUse = null;
//			GameObject zombieToSpawn = null;
//			if (Time.time - spawningTimer > timeBetweenSpawns) {
//				spawnPointToUse = spawnPointsList [Random.Range (0, spawnPointsList.Count)];
//				zombieToSpawn = zombieTypeList [Random.Range (0, zombieTypeList.Count)];
//				Instantiate (zombieToSpawn, spawnPointToUse.transform.position, Quaternion.identity);
//				spawningTimer = Time.time;
//			
//		}


//	public void SpawnEnemy(){
//		Transform spawnPointToUse = null;
//		GameObject zombieToSpawn = null;
//		//int randomSpawnPoint = Random.Range (0, spawnPoints);
//		if (Time.time - spawningTimer > timeBetweenSpawns) {
//			spawnPointToUse = spawnPointsList [Random.Range (0, spawnPointsList.Count)];
//			zombieToSpawn = zombieTypeList [Random.Range (0, zombieTypeList.Count)];
//			Instantiate (zombieToSpawn, spawnPointToUse.transform.position, Quaternion.identity);
//			spawningTimer = Time.time;
//		}



	}
}
