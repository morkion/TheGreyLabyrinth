using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour 
{
	public float startingAttack = 5;
	public float rndAttackModifier = 0.1f;
	public float startingHealth = 2;
	public float rndHealthModifier = 0.1f;
	public float startingDefence = 0.5f;
	public float rndDefenceModifier = 0.1f;
	float attack;
	float health;
	float defence;

	Stats stats;
	Player player;
	Gamelog gamelog;

	bool shouldAttack = false;

	void Start()
	{
		GameObject cam = GameObject.FindGameObjectWithTag("MainCamera");
		stats = cam.GetComponent<Stats>();
		player = cam.GetComponent<Player>();
		gamelog = cam.GetComponent<Gamelog>();
		startingAttack += Random.Range(-rndAttackModifier, rndAttackModifier);
		startingHealth += Random.Range(-rndHealthModifier, rndHealthModifier);
		startingDefence += Random.Range(-rndDefenceModifier, rndDefenceModifier);
		attack = startingAttack;
		health = startingHealth;
		defence = startingDefence;
	}

	void Update()
	{
		if(health <= 0) Death();
	}

	void OnTriggerEnter(Collider col)
	{
		if(col.tag == "Player") gamelog.AddLog("Encountered an enemy.");
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
		if(shouldAttack && !stats.isDead()){
			GUI.BeginGroup(new Rect(Screen.width / 2 - 200, Screen.height / 2 - 100, 400, 200));

			GUI.Box(new Rect(0, 0, 400, 200), "Encounter");
			GUI.HorizontalScrollbar(new Rect(0, 25, 200, 25), 0, startingHealth, 0, health);
			GUI.Label(new Rect(200, 25, 200, 25)," " + health + " Health");
			GUI.Label(new Rect(0, 50, 400, 25), "Att: " + attack + " Def:" + defence);
			if(GUI.Button(new Rect(0, 100, 400, 50),"Attack")){
				float mobDmg = stats.GetAttack()-defence;
				if(mobDmg<0) mobDmg = 0;
				health -= mobDmg;
				gamelog.AddLog("You attack enemy for " + mobDmg + " damage.");

				float plrDmg = attack - stats.GetDefence();
				if(plrDmg<0) plrDmg = 0;
				stats.ModifyHealth(-plrDmg);
				gamelog.AddLog("Enemy attacks you for " + plrDmg + " damage.");
			}
			if(GUI.Button(new Rect(0, 150, 400, 50), "Flee")){
				if(player.Flee() == false){
					gamelog.AddLog("You failed to flee.");
					float plrDmg = attack - stats.GetDefence();
					if(plrDmg<0) plrDmg = 0;
					stats.ModifyHealth(-plrDmg);
					gamelog.AddLog("Enemy attacks you for " + plrDmg + " damage.");
				}else{
					gamelog.AddLog("You have fled from combat.");
				}
			}

			GUI.EndGroup();
		}
	}

	void Death()
	{
		player.canMove = true;
		gamelog.AddLog("Your enemy died.");
		Destroy(gameObject);
	}

}
