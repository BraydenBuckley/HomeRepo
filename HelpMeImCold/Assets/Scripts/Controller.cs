using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour {

	public int playerHeat;
	public Slider heatBar;
	public bool isAtHeat;
	public float timeBetween;
	public float heatTimer;
	public GameObject deadText;


	// Use this for initialization
	void Start () {
		heatBar.value = playerHeat;
		isAtHeat = false;
	}
	
	// Update is called once per frame
	void Update () {

		//isAtHeat=FindObjectOfType<Trigger> ().atHeat;
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
