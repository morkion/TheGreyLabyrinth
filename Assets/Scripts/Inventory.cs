using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour 
{
	string[] items;

	Items itemScript;

	Gamelog gamelog;

	void Start()
	{
		items = new string[8];
		itemScript = GetComponent<Items>();
		gamelog = GetComponent<Gamelog>();
	}

	void Update()
	{

	}

	public bool AddItem(string item)
	{
		for(int i = 0; i < items.Length; i++){
			if(items[i] == null || items[i] == ""){
				items[i] = item;
				gamelog.AddLog("You picked up " + items[i]);
				return true;
				break;
			}
		}
		gamelog.AddLog("Inventory full.");
		return false;
	}

	void DropItem(int slot)
	{
		items[slot] = "";
	}

	void OnGUI()
	{
		GUI.BeginGroup(new Rect(Screen.width - 300, 0, 300, 25 + 25 * items.Length));
		GUI.Box(new Rect(0, 0, 300, Screen.height), "Inventory");
		for(int i = 0; i < items.Length; i++){
			GUI.skin.label.alignment = TextAnchor.MiddleRight;
			GUI.Label(new Rect(0, 25 + (25 * i), 190, 25), items[i]);
			GUI.skin.label.alignment = TextAnchor.UpperLeft;
			if(GUI.Button(new Rect(200, 25 + (25 * i), 75, 25), "Use")){
				if(itemScript.UseItem(items[i])){
					DropItem(i);
				}
			}
			if(GUI.Button(new Rect(275, 25 + (25 * i), 25, 25), "X")){
				gamelog.AddLog("You tossed " + items[i] + " away.");
				DropItem(i);
			}
		}
		GUI.EndGroup();
	}
}
