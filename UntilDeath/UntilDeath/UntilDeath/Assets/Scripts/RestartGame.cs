using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using XboxCtrlrInput;

public class RestartGame : MonoBehaviour {

	public bool isDead;

	//--------------------------------------------------------------------------------------
	//	Update()
	// Runs every frame. Constantly checks if player's health is 0, if so set isDead to True.
	//
	// Param:
	//		None
	// Return:
	//		Void
	//--------------------------------------------------------------------------------------
	void Update(){
		if (FindObjectOfType<PlayerController> ().health <= 0) {
			isDead = true;
		} else {
			isDead = false;
		}

		if (XCI.GetButton (XboxButton.Start)) {
			if (isDead) {
				Restart ();
			}
		}
	}

	//--------------------------------------------------------------------------------------
	//	Restart()
	// Is called if the player clicks start when the player is dead, and restarts the scene.
	//
	// Param:
	//		None
	// Return:
	//		Void
	//--------------------------------------------------------------------------------------
	public void Restart(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

}