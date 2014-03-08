using UnityEngine;
using System.Collections;

public class Stats : MonoBehaviour 
{
	float attack = 0;
	float health = 5;
	float defence = 0;

	bool callDeath = true;

	Gamelog gamelog;

	void Start()
	{
		gamelog = GetComponent<Gamelog>();
	}

	void OnGUI()
	{
		GUI.BeginGroup(new Rect(0, Screen.height - 50, 200, 50));

		GUI.Box(new Rect(0, 0, 200, 50), "");
		GUI.HorizontalScrollbar(new Rect(0, 0, 100, 25), 0, 5, 0, health);
		GUI.Label(new Rect(100, 0, 100, 25), " " + health + " Health");
		GUI.Label(new Rect(0, 25, 200, 25), "Att: " + attack + " Def: " + defence);

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
}
