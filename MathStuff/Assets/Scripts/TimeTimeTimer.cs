using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTimeTimer : MonoBehaviour {

	public float timerBetweenShots = 0.2f;
	private float timer;

	// Use this for initialization
	void Start () {
		timer = Time.time;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.Space)) {
			if (Time.time - timer > timerBetweenShots) {
				timer = Time.time;
				Debug.Log ("Pew");
			}
		}
		
	}
}
