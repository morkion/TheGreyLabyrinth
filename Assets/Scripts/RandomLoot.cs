﻿using UnityEngine;
using System.Collections;

public class RandomLoot : MonoBehaviour 
{
	public string[] loot;
	string chosenLoot;

	bool showGui = false;

	void Start()
	{
		chosenLoot = loot[Random.Range(0,loot.Length)];
	}

	void TakeLoot(GameObject player)
	{
		if(player.GetComponent<Inventory>().AddItem(chosenLoot)){
			Destroy(gameObject);
		}
	}

	void OnTriggerStay(Collider col)
	{
		if(col.tag == "Player"){
			showGui = true;
			if(Input.GetKeyUp(KeyCode.E)) TakeLoot(GameObject.FindGameObjectWithTag("MainCamera"));
		}else{
			showGui = false;
		}
	}

	void OnTriggerExit(Collider col)
	{
		showGui = false;
	}

	void OnGUI()
	{
		if(showGui){
			GUI.BeginGroup(new Rect(Screen.width - 200, Screen.height - 100, 200, 100));

			GUI.Box(new Rect(0, 0, 200, 100), "Loot");
			GUI.Label(new Rect(0, 25, 200, 25), chosenLoot);
			if(GUI.Button(new Rect(0, 50, 200, 50), "Take (E)")){
				TakeLoot(GameObject.FindGameObjectWithTag("MainCamera"));
			}

			GUI.EndGroup();
		}
	}

}
