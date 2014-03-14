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
		if(Input.anyKey) UseInput(Input.inputString);
		DestroyInput();
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
			if(GUI.Button(new Rect(200, 25 + (25 * i), 55, 25), "Use(" + (i + 1) + ")")){
				UseItem(i);
			}
			if(GUI.Button(new Rect(255, 25 + (25 * i), 45, 25), "X(F" + (i + 1) + ")")){
				DestroyItem(i);
			}
		}
		GUI.EndGroup();
	}

	void UseInput(string input)
	{
		int outInt = 0;
		int.TryParse(input, out outInt);
		if(outInt >= 1 && outInt <= 8) UseItem(outInt - 1);
		for(int f = 1; f <= 8; f++){
			if(input == "f" + f.ToString()) DestroyItem(f-1);
		}
	}
	void DestroyInput()
	{
		if(Input.GetKeyUp(KeyCode.F1)) DestroyItem(0);
		if(Input.GetKeyUp(KeyCode.F2)) DestroyItem(1);
		if(Input.GetKeyUp(KeyCode.F3)) DestroyItem(2);
		if(Input.GetKeyUp(KeyCode.F4)) DestroyItem(3);
		if(Input.GetKeyUp(KeyCode.F5)) DestroyItem(4);
		if(Input.GetKeyUp(KeyCode.F6)) DestroyItem(5);
		if(Input.GetKeyUp(KeyCode.F7)) DestroyItem(6);
		if(Input.GetKeyUp(KeyCode.F8)) DestroyItem(7);
	}

	void UseItem(int slotnum)
	{
		if(itemScript.UseItem(items[slotnum])){
			DropItem(slotnum);
		}
	}
	void DestroyItem(int slotnum)
	{
		gamelog.AddLog("You tossed " + items[slotnum] + " away.");
		DropItem(slotnum);
	}
}
