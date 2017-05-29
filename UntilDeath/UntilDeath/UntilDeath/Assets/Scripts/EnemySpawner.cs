using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public List<Transform> spawnPointsList = new List<Transform> ();
	public List<GameObject> zombieTypeList = new List<GameObject> ();
	public float timeBetweenSpawns = 5;
	public float spawningTimer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		SpawnEnemy ();
		SpawnWave ();

	}

	public void SpawnEnemy(){
		Transform spawnPointToUse = null;
		GameObject zombieToSpawn = null;
		//int randomSpawnPoint = Random.Range (0, spawnPoints);
		if (Time.time - spawningTimer > timeBetweenSpawns) {
			spawnPointToUse = spawnPointsList [Random.Range (0, spawnPointsList.Count)];
			zombieToSpawn = zombieTypeList [Random.Range (0, zombieTypeList.Count)];
			Instantiate (zombieToSpawn, spawnPointToUse.transform.position, Quaternion.identity);
			spawningTimer = Time.time;
		}
	}

	public void SpawnWave(){
		
	}
}
