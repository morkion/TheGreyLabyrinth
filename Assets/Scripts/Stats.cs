using UnityEngine;
using System.Collections;

public class Stats : MonoBehaviour 
{
	float attack = 0;
	float health = 5;

	void OnGUI()
	{
		GUI.BeginGroup(new Rect(0, Screen.height - 50, 200, 50));

		GUI.Box(new Rect(0, 0, 200, 50), "");
		GUI.HorizontalScrollbar(new Rect(0, 0, 100, 25),0,5,0,health);
		GUI.Label(new Rect(100, 0, 100, 25), "Health");
		GUI.Label(new Rect(0, 25, 200, 25), "Att: " + attack);

		GUI.EndGroup();
	}

	public void SetAttack(float newAtt)
	{
		attack = newAtt;
	}

	public void ModifyHealth(float modifier)
	{
		health += modifier;
	}

	public float GetAttack()
	{
		return attack;
	}

	void Update()
	{
		if(health<=0) Application.LoadLevel(Application.loadedLevel);
	}
}
