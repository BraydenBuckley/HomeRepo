using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorMath : MonoBehaviour {

	public Vector3 scaleVector1;

	public GameObject endPoint;
	public GameObject startPoint;
	public GameObject midPoint;
	public GameObject normalizedPoint;
	public LineRenderer LR;

	public TextMesh outputText;


	
	// Update is called once per frame
	void Update () {

		startPoint.transform.position = Vector3.zero;

		scaleVector1 = endPoint.transform.position;

		normalizedPoint.transform.position = Vector3.Normalize (scaleVector1);

		midPoint.transform.position = Vector3.Normalize (scaleVector1) * Vector3.Distance (startPoint.transform.position, endPoint.transform.position)/2;

		LR.SetPosition (1, scaleVector1);

		outputText.text = "End Point - Line Distance:" + Vector3.Distance (endPoint.transform.position, startPoint.transform.position).ToString ();
	}
}
