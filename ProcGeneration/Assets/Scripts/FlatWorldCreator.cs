using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlatWorldCreator : MonoBehaviour {
	
	public List<GameObject> groundPieceList = new List<GameObject>(); 

	public int worldSizeX = 20;
	public int worldSizeZ = 20;

	public float xOrg;
	public float zOrg;
	public float scale = 1.54f;
	public float multiplier = 3;

	public int groundPieceSize = 5;

	// Use this for initialization
	void Start () {
		for (int x = 0; x < worldSizeX; x++) {
			for (int z = 0; z < worldSizeZ; z++) {

				GameObject randomPiece = groundPieceList [Random.Range (0, groundPieceList.Count)];

				float xCoord = xOrg + (float)x / (float)worldSizeX * scale;
				float zCoord = zOrg + (float)z / (float)worldSizeZ * scale;
				float sample = Mathf.PerlinNoise (xCoord, zCoord);

				GameObject GO = Instantiate (randomPiece, new Vector3 

					(x*groundPieceSize, sample*multiplier, z*groundPieceSize), 
				//(x*groundPieceSize, Random.Range(-0.5f,0.5f), z*groundPieceSize),

				Quaternion.Euler(0,Random.Range(0,4)*90,0)) as GameObject;
			}
		}
	}

}
