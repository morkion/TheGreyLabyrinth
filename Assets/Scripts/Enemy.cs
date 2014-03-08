using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour 
{
	public float startingAttack = 5;
	public float rndAttackModifier = 0.1f;
	public float startingHealth = 2;
	public float rndHealthModifier = 0.1f;
	float attack;
	float health;

	Stats stats;
	Player player;

	bool shouldAttack = false;

	void Start()
	{
		GameObject cam = GameObject.FindGameObjectWithTag("MainCamera");
		stats = cam.GetComponent<Stats>();
		player = cam.GetComponent<Player>();
		startingAttack += Random.Range(-rndAttackModifier, rndAttackModifier);
		startingHealth += Random.Range(-rndHealthModifier, rndHealthModifier);
		attack = startingAttack;
		health = startingHealth;
	}

	void Update()
	{
		if(health <= 0) Death();
	}

	void OnTriggerStay(Collider col)
	{
		if(col.tag == "Player"){
			shouldAttack = true;
			player.canMove = false;
		}else{
			//shouldAttack = false;
		}
	}

	void OnTriggerExit(Collider col)
	{
		shouldAttack = false;
		player.canMove = true;
	}

	void OnGUI()
	{
		if(shouldAttack){
			GUI.BeginGroup(new Rect(Screen.width / 2 - 200, Screen.height / 2 - 100, 400, 200));

			GUI.Box(new Rect(0, 0, 400, 200), "Encounter");
			GUI.HorizontalScrollbar(new Rect(0, 25, 200, 25), 0, startingHealth, 0, health);
			GUI.Label(new Rect(200, 25, 200, 25)," Health");
			GUI.Label(new Rect(0, 50, 400, 25), "Att: " + attack);
			if(GUI.Button(new Rect(0, 100, 400, 50),"Attack")){
				health -= stats.GetAttack();
				stats.ModifyHealth(-attack);
			}
			if(GUI.Button(new Rect(0, 150, 400, 50), "Flee")){
				if(player.Flee() == false) stats.ModifyHealth(-attack);
			}

			GUI.EndGroup();
		}
	}

	void Death()
	{
		player.canMove = true;
		Destroy(gameObject);
	}

}
