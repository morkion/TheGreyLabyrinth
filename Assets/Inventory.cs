using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour 
{
	string[] items;
	void Start()
	{
		items = new string[8];
	}

	void Update()
	{

	}

	void AddItem(string item)
	{
		for(int i = 0; i < items.Length; i++){
			if(items[i]==null||items[i]==""){
				items[i] = item;
				break;
			}
		}
	}

	void DropItem(int slot)
	{
		items[slot] = "";
	}
}
