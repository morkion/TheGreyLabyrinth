using UnityEngine;
using System.Collections;
using System.Threading;

public class GenerateLevel : MonoBehaviour 
{

	public GameObject cube;
	GameObject clone;

	public int size = 256;
	int[,] cubes;

	bool[,] cubeSpawned;

	void Start()
	{
		cubes = new int[size,size];
		cubeSpawned = new bool[size,size];
		for(int x = 0; x < size; x++){
			for(int z = 0; z < size; z++){
				cubes[x,z] = Random.Range(0,2);
				cubeSpawned[x,z] = false;
			}
		}
	}


	public int GetCube(float x, float z)
	{
		return cubes[Mathf.RoundToInt(x),Mathf.RoundToInt(z)];
	}

	public void SpawnCube(float x, float z)
	{
		if(!cubeSpawned[Mathf.RoundToInt(x),Mathf.RoundToInt(z)]){
			clone = Instantiate(cube,new Vector3(x,cubes[Mathf.RoundToInt(x),Mathf.RoundToInt(z)],z),Quaternion.identity) as GameObject;
			cubeSpawned[Mathf.RoundToInt(x),Mathf.RoundToInt(z)] = true;
		}
	}

	public void NoExit(float curX, float curZ){
		if(!cubeSpawned[Mathf.RoundToInt(curX)-1,Mathf.RoundToInt(curZ)]) cubes[Mathf.RoundToInt(curX)-1,Mathf.RoundToInt(curZ)] = Random.Range(0,2);
		if(!cubeSpawned[Mathf.RoundToInt(curX)+1,Mathf.RoundToInt(curZ)]) cubes[Mathf.RoundToInt(curX)+1,Mathf.RoundToInt(curZ)] = Random.Range(0,2);
		if(!cubeSpawned[Mathf.RoundToInt(curX),Mathf.RoundToInt(curZ)-1]) cubes[Mathf.RoundToInt(curX),Mathf.RoundToInt(curZ)-1] = Random.Range(0,2);
		if(!cubeSpawned[Mathf.RoundToInt(curX),Mathf.RoundToInt(curZ)+1]) cubes[Mathf.RoundToInt(curX),Mathf.RoundToInt(curZ)+1] = Random.Range(0,2);
	}


}
