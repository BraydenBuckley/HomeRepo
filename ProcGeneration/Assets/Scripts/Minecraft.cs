using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minecraft : MonoBehaviour {

	public int worldSizeX =20;
	public int worldSizeZ =20;
	public int worldSizeY =20;

	public GameObject dirtPrefab;
	public GameObject stonePrefab;

	private List<Cube> cubeList = new List<Cube> ();

	//Surface
	[Range(1f,100f)]
	public float surfaceScale = 2;

	[Range(0f,1f)]
	public float surfaceCutoff = 0.7f;

	[Range(0f,100f)]
	public float surfaceOffSetX = 0;

	[Range(0f,100f)]
	public float surfaceOffSetZ = 0;

	//Cave System
	[Range(0.01f,20)]
	public float caveScale = 10;

	[Range(0f,1f)]
	public float caveCutoff = 0.7f;

	[Range(0f,100f)]
	public float caveOffSetX = 0;

	[Range(0f,100f)]
	public float caveOffSetY = 0;

	[Range(0f,100f)]
	public float caveOffSetZ = 0;

	private float Perlin3D(float x,float y, float z){
		x += caveOffSetX;
		y += caveOffSetY;
		z += caveOffSetZ;

		float AB = Mathf.PerlinNoise (x, y);
		float BC = Mathf.PerlinNoise (y, z);
		float AC = Mathf.PerlinNoise (x, z);

		float BA = Mathf.PerlinNoise (y, x);
		float CB = Mathf.PerlinNoise (z, y);
		float CA = Mathf.PerlinNoise (z, x);

		float ABC = AB + BC + AC + BA + CB + CA;

		float average = ABC / 6;
		return average;

	}


	// Use this for initialization
	void Start () {
		for (int x = 0; x < worldSizeX; x++) {
			for (int y = 0; y < worldSizeY; y++) {
				for (int z = 0; z < worldSizeZ; z++) {
					
					GameObject cubeToPlace;
					if (Random.Range (0, y + 5) > worldSizeY - y || y > worldSizeY - 3) {
						cubeToPlace = dirtPrefab;
					} else {
						cubeToPlace = stonePrefab;
					}

					Vector3 cubePosition = new Vector3 (x, y, z);
					GameObject GO = Instantiate (cubeToPlace, cubePosition, Quaternion.identity);
					GO.name = "Cube: x-" + x + "y-" + y + "z-"+z;
					GO.GetComponent<Cube> ().position = new Vector3 (x, y, z);
					cubeList.Add (GO.GetComponent<Cube> ());
							
				}
			}
		}
		UpdateCube ();
	}
	
	public void UpdateCube(){
	
		foreach (var cube in cubeList) {
			if (Perlin3D ((cube.position.x) / caveScale, (cube.position.y) /
			   caveScale, (cube.position.z) / caveScale) > caveCutoff) {
				if (Mathf.PerlinNoise((cube.position.x+surfaceOffSetX)/surfaceScale,
					(cube.position.z+surfaceOffSetZ)/surfaceScale)>(cube.position.y/
						(float)worldSizeY)-surfaceCutoff){
					cube.gameObject.SetActive(true);							
				}else{
					cube.gameObject.SetActive(false);
				}
			}else{
						cube.gameObject.SetActive(false);
			}
		}
	}

	void Update (){
		//UpdateCube ();
	}
}
