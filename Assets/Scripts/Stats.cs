using UnityEngine;
using System.Collections;

public class Stats : MonoBehaviour 
{
	float attack = 0;
	float health = 5;
	float defence = 0;

	int fragments = 0;
	public int neededFragments = 7;

	bool callDeath = true;

	Gamelog gamelog;

	void Start()
	{
		gamelog = GetComponent<Gamelog>();
	}

	void OnGUI()
	{
		GUI.BeginGroup(new Rect(0, Screen.height - 75, 200, 75));

		GUI.Box(new Rect(0, 0, 200, 75), "");
		GUI.HorizontalScrollbar(new Rect(0, 0, 100, 25), 0, health, 0, 5);
		GUI.Label(new Rect(100, 0, 100, 25), " " + health + " Health");
		GUI.Label(new Rect(0, 25, 200, 25), "Att: " + attack + " Def: " + defence);
		GUI.Label(new Rect(0, 50, 200, 25), "Fragments Found: " + fragments + "/" + neededFragments);

		GUI.EndGroup();
	}

	public void SetAttack(float newAtt)
	{
		attack = newAtt;
	}

	public void SetDefence(float newDef)
	{
		defence = newDef;
	}

	public void ModifyHealth(float modifier)
	{
		health += modifier;
	}

	public float GetAttack()
	{
		return attack;
	}

	public float GetDefence()
	{
		return defence;
	}

	void Update()
	{
		if(health <= 0 && callDeath) StartCoroutine("Death");
		if(health > 5) health = 5;
		if(fragments>=neededFragments) Application.LoadLevel(Application.loadedLevel + 1);
	}

	IEnumerator Death()
	{
		callDeath = false;
		gamelog.AddLog("You have died.");
		yield return new WaitForSeconds(3);
		Application.LoadLevel(Application.loadedLevel);
	}

	public bool isDead()
	{
		return !callDeath;
	}

	public void Degrade(float mobAttack, float mobDef)
	{
		attack -= Random.Range(0.001f, mobDef/10);
		defence -= Random.Range(0.001f, mobAttack/10);
		if(attack <= 0) attack = 0;
		if(defence <= 0) defence = 0;
	}

	public void PartialDegrade(float mobAttack)
	{
		defence -= Random.Range(0.001f, mobAttack/10);
		if(defence <= 0) defence = 0;
	}

	public void FragmentFound()
	{
		fragments++;
	}
}
