using UnityEngine;
using System.Collections;

public class AttackInRange : MonoBehaviour {
	
	//explosion visual
	public GameObject ExplosionVisual;
	//how much time to wait to find a target
	public float FindTargetDelay = 1;
	//the attack range
	public float AttackRange = 100;
	//attack speed
	public float AttackFrequency = 0.25f;
	//attack damage
	public float AttackDamage = 5;
	//how long the bullet lasts
	public float BulletTime = 2;

	//get the targets health info
	private ShowUnitInfo target;
	//store our player
	public PlayerSetupDefinition player;
	//how much time has passed since we found a target and since we have shot
	public float findTargetCounter = 0;
	public float attackCounter = 0;

	// Use this for initialization
	void Start () 
	{
		//get the player info
		player = GetComponent<Player> ().Info;
	}

	//method to find a target when enough time has passed
	void FindTarget() 
	{
		//have we found a target, return if we have target
		if (target != null)
			return;

		//get the current players
		foreach (var p in RtsManager.Current.Players) {
			//make sure we don't attack our own units
			if (p == player)
				continue;

			//foudn a target, see if anythign is close enough to attack
			foreach (var unit in p.ActiveUnits) {
				//check the distance to target
				if (Vector3.Distance (unit.transform.position, transform.position) < AttackRange) {
					//get the target info
					target = unit.GetComponent<ShowUnitInfo> ();
					return;
				}
			}
		}
	}

	//method to attack
	void Attack ()
	{
		//if there is no target, return
		if (target == null)
			return;
		//check if the unit is in range to attack
		if (Vector3.Distance (target.transform.position, transform.position) > AttackRange) {
			target = null;
			return;
		}

		//decrement target health by attack damage
		target.CurrentHealth -= AttackDamage;
		var explosion = GameObject.Instantiate (ExplosionVisual, target.transform.position, Quaternion.identity);
	}

	// Update is called once per frame
	void Update () {
		//find how much time has passed
		findTargetCounter += Time.deltaTime;
		//check if enough time has passed
		if (findTargetCounter > FindTargetDelay) {
			//call FindTarget method
			FindTarget ();
			//reset counter
			findTargetCounter = 0;
		}

		attackCounter += Time.deltaTime;
		if (attackCounter > AttackFrequency) {
			Attack ();
			attackCounter = 0;
		}
	}
}
