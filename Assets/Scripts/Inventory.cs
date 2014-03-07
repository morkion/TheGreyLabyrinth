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

	public bool AddItem(string item)
	{
		for(int i = 0; i < items.Length; i++){
			if(items[i]==null||items[i]==""){
				items[i] = item;
				return true;
				break;
			}
		}
		return false;
	}

	void DropItem(int slot)
	{
		items[slot] = "";
	}

	void OnGUI()
	{
		GUI.BeginGroup(new Rect(Screen.width - 200, 0, 200, 25 + 25 * items.Length));
		GUI.Box(new Rect(0, 0, 200, Screen.height), "Inventory");
		for(int i = 0; i < items.Length; i++){
			GUI.Label(new Rect(0, 25 + (25 * i), 100, 25), items[i]);
			if(GUI.Button(new Rect(100, 25 + (25 * i), 75, 25), "Use")){

			}
			if(GUI.Button(new Rect(175, 25 + (25 * i), 25, 25), "X")){
				DropItem(i);
			}
		}
		GUI.EndGroup();
	}
}
