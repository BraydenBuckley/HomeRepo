using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using XboxCtrlrInput;

public class RestartGame : MonoBehaviour {

	public bool isDead;

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

	//Restarts current scene
	public void Restart(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

}