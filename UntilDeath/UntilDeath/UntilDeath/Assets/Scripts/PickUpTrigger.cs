using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpTrigger : MonoBehaviour {

	public List<GameObject> gunList = new List<GameObject>();
	public int gunReference =0;


	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			if (gunList [gunReference])
				gunList [0].SetActive (false);
				gunList [1].SetActive (false);
				gunList [2].SetActive (false);
				gunList [gunReference].SetActive (true);
		}
	}
}
