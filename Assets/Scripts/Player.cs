using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	Vector3 pos;

	GenerateLevel gen;
	Gamelog gamelog;

	bool checkUp = false;
	bool checkDown = false;
	bool checkLeft = false;
	bool checkRight = false;
	public bool canMove = true;

	void Start()
	{
		gen = GetComponent<GenerateLevel>();
		gamelog = GetComponent<Gamelog>();
	}

	void Update()
	{
		pos = transform.position;
		checkUp = gen.GetCube(pos.x, pos.z + 1) == 0;
		checkDown = gen.GetCube(pos.x, pos.z - 1) == 0;
		checkLeft = gen.GetCube(pos.x - 1, pos.z) == 0;
		checkRight = gen.GetCube(pos.x + 1, pos.z) == 0;
		int checks = gen.GetCube(pos.x, pos.z + 1) + gen.GetCube(pos.x, pos.z - 1) + gen.GetCube(pos.x - 1, pos.z) + gen.GetCube(pos.x + 1, pos.z);
		if(canMove){
			if(checks >= 3){ 
				gen.NoExit(pos.x, pos.z);
			}else{
				Spawning();
			}
			if(checks < 4 ) Movement();
		}
	}

	void Movement()
	{
		if(checkUp){ 
			MoveUp();
		}

		if(checkDown){
			MoveDown();
		}

		if(checkLeft){
			MoveLeft();
		}

		if(checkRight){ 
			MoveRight();
		}

	}

	void Spawning()
	{
		gen.SpawnCube(pos.x, pos.z + 1);
		gen.SpawnCube(pos.x, pos.z - 1);
		gen.SpawnCube(pos.x - 1, pos.z);
		gen.SpawnCube(pos.x + 1, pos.z);
	}

	void MoveUp()
	{
		if(Input.GetKeyUp(KeyCode.UpArrow) || !canMove){
			transform.Translate(new Vector3(0, 0, 1), Space.World);
			gamelog.AddLog("You moved up.");
		}
	}
	void MoveDown()
	{
		if(Input.GetKeyUp(KeyCode.DownArrow) || !canMove){
			transform.Translate(new Vector3(0, 0, -1), Space.World);
			gamelog.AddLog("You moved down.");
		}
	}

	void MoveLeft()
	{
		if(Input.GetKeyUp(KeyCode.LeftArrow) || !canMove){
			transform.Translate(new Vector3(-1, 0, 0),Space.World);
			gamelog.AddLog("You moved left.");
		}
	}

	void MoveRight()
	{
		if(Input.GetKeyUp(KeyCode.RightArrow) || !canMove){
			transform.Translate(new Vector3(1, 0, 0),Space.World);
			gamelog.AddLog("You moved right.");
		}
	}

	public bool Flee()
	{
		switch(Random.Range(0,4)){
		case 0:
			if(checkDown){
				MoveDown();
				canMove = true;
				return true;
			}else{
				return false;
			}
			break;
		case 1:
			if(checkLeft){
				MoveLeft();
				canMove = true;
				return true;
			}else{
				return false;
			}
			break;
		case 2:
			if(checkRight){
				MoveRight();
				canMove = true;
				return true;
			}else{
				return false;
			}
			break;
		case 3:
			if(checkUp){
				MoveUp();
				canMove = true;
				return true;
			}else{
				return false;
			}
			break;
		}
		return false;
	}
}
