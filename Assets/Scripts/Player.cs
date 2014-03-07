using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	Vector3 pos;
	GenerateLevel gen;

	void Start()
	{
		gen = GetComponent<GenerateLevel>();
	}

	void Update()
	{
		pos = transform.position;
		bool checkUp = gen.GetCube(pos.x, pos.z + 1) == 0;
		bool checkDown = gen.GetCube(pos.x, pos.z - 1) == 0;
		bool checkLeft = gen.GetCube(pos.x - 1, pos.z) == 0;
		bool checkRight = gen.GetCube(pos.x + 1, pos.z) == 0;
		int checks = gen.GetCube(pos.x, pos.z + 1) + gen.GetCube(pos.x, pos.z - 1) + gen.GetCube(pos.x - 1, pos.z) + gen.GetCube(pos.x + 1, pos.z);

		if(checks>=3){ 
			gen.NoExit(pos.x,pos.z);
		}else{
			if(checkUp){ 
				MoveUp();
			}
			gen.SpawnCube(pos.x,pos.z+1);
			if(checkDown){
				MoveDown();
			}
			gen.SpawnCube(pos.x,pos.z-1);
			if(checkLeft){
				MoveLeft();
			}
			gen.SpawnCube(pos.x-1,pos.z);
			if(checkRight){ 
				MoveRight();
			}
			gen.SpawnCube(pos.x+1,pos.z);
		}
	}

	void MoveUp()
	{
		if(Input.GetKeyUp(KeyCode.UpArrow)){
			transform.Translate(new Vector3(0,0,1),Space.World);
		}
	}
	void MoveDown()
	{
		if(Input.GetKeyUp(KeyCode.DownArrow)){
			transform.Translate(new Vector3(0,0,-1),Space.World);
		}
	}

	void MoveLeft()
	{
		if(Input.GetKeyUp(KeyCode.LeftArrow)){
			transform.Translate(new Vector3(-1,0,0),Space.World);
		}
	}

	void MoveRight()
	{
		if(Input.GetKeyUp(KeyCode.RightArrow)){
			transform.Translate(new Vector3(1,0,0),Space.World);
		}
	}
}
