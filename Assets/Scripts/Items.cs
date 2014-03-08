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
		case "Armour":
			ApplyArmourDefense(GetArmourDefense(item));
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
		case "Clothing":
		case "Leather Armour":
		case "Chainmail Armour":
		case "Steel Plate Armour":
		case "Dwarven Steel Plate Armor":
			return "Armour";
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

	float GetArmourDefense(string armour)
	{
		switch(armour){
		case "Clothing":
			return 0.1f;
			break;
		case "Leather Armour":
			return 1.5f;
			break;
		case "Chainmail Armour":
			return 2.5f;
			break;
		case "Steel Plate Armour":
			return 5;
			break;
		case "Dwarven Steel Plate Armour":
			return 7;
			break;
		}
		return -1;
	}

	void ApplyPlayerAttack(float attack)
	{
		stats.SetAttack(attack);
	}

	void ApplyArmourDefense(float defense)
	{
		stats.SetDefence(defense);
	}
}
