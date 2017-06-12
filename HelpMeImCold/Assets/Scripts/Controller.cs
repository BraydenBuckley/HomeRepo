using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour {

	//int for players heat
	public int playerHeat;
	//UI elements
	public Slider heatBar;
	public GameObject deadText;
	//Bool to determine if player is at heat source
	public bool isAtHeat;
	//Timer variables
	public float timeBetween;
	public float heatTimer;



	//--------------------------------------------------------------------------------------
	//	Start()
	// Runs on inistialisation 
	//
	// Param:
	//		Collider other - The collider of any objects that pass into this trigger
	// Return:
	//		Void
	//--------------------------------------------------------------------------------------
	void Start () {
		heatBar.value = playerHeat;
		isAtHeat = false;
	}
	//--------------------------------------------------------------------------------------
	//	Update()
	// Runs every frame
	//
	// Param:
	//		none
	// Return:
	//		Void
	//--------------------------------------------------------------------------------------
	void Update () {
		if (playerHeat <= 0) {
			return;
		}
		if (isAtHeat) {
			if (Time.time - heatTimer > timeBetween) {
				playerHeat+=5;
				heatTimer = Time.time;
			}
		} else {
			if (Time.time - heatTimer > timeBetween) {
				playerHeat-=5;
				heatTimer = Time.time;
			}
		}
		heatBar.value = playerHeat;
		if (playerHeat <= 0) {
			deadText.SetActive (true);
		}
	}
}
