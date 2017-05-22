using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldCreator : MonoBehaviour {

	public int worldSizeX = 20;
	public int worldSizeY = 10;
	public int worldSizeZ = 20;
	public GameObject cubePrefab;

	public Transform cubeParent;

	// Use this for initialization
	void Start () {

		for (int x = 0; x < worldSizeX; x++) {
			for (int y = 0; y < worldSizeY; y++) {
				for (int z = 0; z < worldSizeZ; z++) {

					if (Random.Range (0, 2) == 0) {
						Vector3 cubePosition = new Vector3 (x, y, z);
						GameObject GO = Instantiate (cubePrefab, cubePosition, Quaternion.identity);
						GO.transform.SetParent (cubeParent);
						GO.name = "Cube:" + x + " Y:" + y + " Z:" + z;


						float red = (float)x / (worldSizeX - 1);
						float green = (float)y / (worldSizeY - 1);
						float blue = (float)z / (worldSizeZ - 1);
						GO.GetComponent<Renderer> ().material.color = new Color (red, green, blue);
					}
				}
			}
		}
	}
}