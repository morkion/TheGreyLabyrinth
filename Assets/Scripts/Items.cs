using UnityEngine;
using System.Collections;

public class Items : MonoBehaviour 
{
	Stats stats;

	void Start()
	{
		stats = GetComponent<Stats>();
	}

	public bool UseItem(string item)
	{
		switch(GetType(item)){
		case "Weapon":
			ApplyPlayerAttack(GetWeaponAttack(item));
			return true;
			break;
		}
		return false;
	}

	string GetType(string item)
	{
		switch(item){
		//Weapons
		case "Longsword":
		case "Sword":
		case "Dagger":
			return "Weapon";
			break;
		
		}
		return null;
	}

	float GetWeaponAttack(string weapon)
	{
		switch(weapon){
		case "Longsword":
			return 2;
			break;
		case "Sword":
			return 1.5f;
			break;
		case "Dagger":
			return 1;
			break;
		}
		return -1;
	}

	void ApplyPlayerAttack(float attack)
	{
		stats.SetAttack(attack);
	}
}
