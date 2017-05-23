using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpTrigger : MonoBehaviour {

//	public GameObject weaponToPickup;
//	public GameObject weaponPrefab;
//	public Transform weaoponSpawnPoint;
//	public Transform weaponParent;
	public int weaponNumber;
	public List<GameObject> weapons = new List<GameObject> ();

	void OnTriggerEnter(Collider other){
//		Debug.Log (weaponToPickup);
//		Destroy(this.gameObject);
//		Destroy (weaponToPickup.gameObject);
//		GameObject GO = Instantiate (weaponPrefab, weaoponSpawnPoint.position, weaoponSpawnPoint.transform.rotation) as GameObject;

		ChangeWeapons ();
	}

	public void ChangeWeapons (){
		foreach (var weaponNumber in weapons) {
			
		}
	}
}
