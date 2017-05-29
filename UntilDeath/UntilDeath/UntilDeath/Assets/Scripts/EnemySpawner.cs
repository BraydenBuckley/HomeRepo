using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public List<Transform> spawnPointsList = new List<Transform> ();
	public List<GameObject> zombieTypeList = new List<GameObject> ();
	public float timeBetweenSpawns = 5;
	public float spawningTimer;

	public int waveZombieAmount=1;
	public int waveCounter=1;
	public int totalEnemies;

	public float timeBetweenWaves=5f;
	public float waveTimer;
	// Use this for initialization
	void Start () {

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
				timeBetweenWaves += 5;
				Debug.Log (waveCounter + "Finished");
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
