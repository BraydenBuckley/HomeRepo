using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSprites : MonoBehaviour {


	public List<GameObject> gunSprites = new List<GameObject>();

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		//FindObjectOfType<WeaponSprites> ().pistol.SetActive(false);
		if (gunSprites [FindObjectOfType<PickUpTrigger> ().gunReference]) {
			gunSprites [0].SetActive (false);
			gunSprites [1].SetActive (false);
			gunSprites [2].SetActive (false);
			gunSprites [FindObjectOfType<PickUpTrigger> ().gunReference].SetActive (true);
		}
	}
}
