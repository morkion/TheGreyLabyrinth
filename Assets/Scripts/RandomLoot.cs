using UnityEngine;
using System.Collections;

public class RandomLoot : MonoBehaviour 
{
	public string[] loot;
	string chosenLoot;
	void Start()
	{
		chosenLoot = loot[Random.Range(0,loot.Length)];
	}

	void TakeLoot(GameObject player)
	{
		player.BroadcastMessage("AddItem", chosenLoot, SendMessageOptions.RequireReceiver);
	}

}
