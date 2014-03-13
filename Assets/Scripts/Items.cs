using UnityEngine;
using System.Collections;

public class Items : MonoBehaviour 
{
	Stats stats;
	Gamelog gamelog;

	void Start()
	{
		stats = GetComponent<Stats>();
		gamelog = GetComponent<Gamelog>();
	}

	public bool UseItem(string item)
	{
		switch(GetType(item)){
		case "Weapon":
			ApplyPlayerAttack(GetWeaponAttack(item));
			gamelog.AddLog("You equip " + item);
			return true;
			break;
		case "Armour":
			ApplyArmourDefense(GetArmourDefense(item));
			gamelog.AddLog("You equip " + item);
			return true;
			break;
		case "Food":
			gamelog.AddLog("You consume " + item);
			ApplyHealthModifer(GetHealthModifier(item));
			return true;
			break;
		}
		return false;
	}

	string GetType(string item)
	{
		switch(item){
		//Weapons
		case "Iron Longsword":
		case "Iron Sword":
		case "Iron Dagger":
		case "Wooden Club":
		case "Iron Mace":
		case "Steel Sword":
		case "Steel Greatsword":
		case "Leather Whip":
			return "Weapon";
			break;
		case "Clothing":
		case "Leather Armour":
		case "Iron Chainmail Armour":
		case "Steel Plate Armour":
		case "Dwarven Steel Plate Armour":
		case "Elven Steel Armour":
		case "A Bunch of Rags":
		case "Iron Plate Armour":
		case "Steel Chainmail Armour":
		case "Old Robes":
		case "Wooden Armour":
			return "Armour";
			break;
		case "Rotten Kiwi":
		case "Healing Salve":
		case "Healing Herb Mixture":
		case "Mysterious Pill":
		case "Can of Carob Raisins":
		case "Pack of Vanilla Mints":
		case "Bottle of Rum":
		case "Bottle of Mead":
		case "Bandages":
		case "First-Aid Kit":
		case "Cake":
		case "Tube of Toothpaste":
			return "Food";
			break;
		}
		return null;
	}

	float GetWeaponAttack(string weapon)
	{
		switch(weapon){
		case "Iron Longsword":
			return 1.65f;
			break;
		case "Iron Sword":
			return 1.3f;
			break;
		case "Iron Dagger":
			return 1;
			break;
		case "Wooden Club":
			return 0.25f;
			break;
		case "Iron Mace":
			return 1.25f;
			break;
		case "Steel Sword":
			return 1.9f;
			break;
		case "Steel Greatsword":
			return 2.5f;
			break;
		case "Leather Whip":
			return 0.5f;
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
		case "Iron Chainmail Armour":
			return 2.5f;
			break;
		case "Steel Plate Armour":
			return 5;
			break;
		case "Dwarven Steel Plate Armour":
			return 7;
			break;
		case "Elven Steel Armour":
			return 7;
			break;
		case "A Bunch of Rags":
			return 0.01f;
			break;
		case "Iron Plate Armour":
			return 3;
			break;
		case "Steel Chainmail Armour":
			return 3.33f;
			break;
		case "Old Robes":
			return 0.2f;
			break;
		case "Wooden Armour":
			return 1;
			break;

		}
		return -1;
	}

	float GetHealthModifier(string foodItem)
	{
		switch(foodItem){
		case "Rotten Kiwi":
			float mod = Random.Range(-1,2);
			if(mod==0){
				gamelog.AddLog("Nothing happens.");
				return 0;
			}else if(mod==1){
				gamelog.AddLog("You slightly better. +1 hp");
				return 1;
			}else{
				gamelog.AddLog("You feel slightly worse. -1hp");
				return -1;
			}
			break;
		case "Healing Salve":
			gamelog.AddLog("You feel a little better. +3hp");
			return 3;
			break;
		case "Healing Herb Mixture":
			gamelog.AddLog("You feel healthy.");
			return 5;
			break;
		case "Mysterious Pill":
			float rnd = Random.Range(-1,2);
			if(rnd == 0){
				gamelog.AddLog("Nothing happens.");
				return 0;
			}else if(rnd == 1){
				gamelog.AddLog("Food pill? +1 hp");
				return 1;
			}else{
				gamelog.AddLog("It was cyanide...");
				return -1337;
			}
			break;
		case "Can of Carob Raisins":
			gamelog.AddLog("You feel slightly better. +0.25 hp");
			return 0.25f;
			break;
		case "Pack of Vanilla Mints":
			gamelog.AddLog("You now have a nice vanilla breath.");
			return 0;
			break;
		case "Bottle of Rum":
			gamelog.AddLog("*Hicup* +0.5 hp");
			return 0.5f;
			break;
		case "Bottle of Mead":
			gamelog.AddLog("Mmmmm... +0.5 hp");
			return 0.5f;
			break;
		case "Bandages":
			gamelog.AddLog("You feel better. +2 hp");
			return 2;
			break;
		case "First-Aid Kit":
			gamelog.AddLog("You feel a lot better. +4 hp");
			return 4;
			break;
		case "Cake":
			gamelog.AddLog("Cake is a lie. +0.001 hp");
			return 0.001f;
			break;
		case "Tube of Toothpaste":
			gamelog.AddLog("Blistering white teeth!");
			return 0;
			break;
		}
		return 0;
	}

	void ApplyPlayerAttack(float attack)
	{
		stats.SetAttack(attack);
	}

	void ApplyArmourDefense(float defense)
	{
		stats.SetDefence(defense);
	}

	void ApplyHealthModifer(float modifier)
	{
		stats.ModifyHealth(modifier);
	}
}
