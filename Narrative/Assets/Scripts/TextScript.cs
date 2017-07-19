using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextScript : MonoBehaviour {

	public GameObject text1;
	public GameObject text2;
	public GameObject text4;
	public GameObject text5;
	public GameObject text6;
	public GameObject text7;


	void OnTriggerEnter(){
		text1.SetActive (false);
		text2.SetActive (false);
		text4.SetActive (true);
		text5.SetActive (true);
		text6.SetActive (true);
		text7.SetActive (true);
	}
}
