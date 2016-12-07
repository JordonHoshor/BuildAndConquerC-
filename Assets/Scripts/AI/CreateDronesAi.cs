using UnityEngine;
using System.Collections;

//inherits from AiBehavior
public class CreateDronesAi : AiBehavior {
	
	//how many drones a base should support
	public int DronesPerBase = 5;
	//DroneUnits cost
	public float Cost = 25;
	//get easy access to AiSupport
	private AiSupport support;

	public override float GetWeight ()
	{
		//get AiSupport
		if (support == null)
			support = AiSupport.GetSupport (gameObject);

		//check to see if we have enough credits
		if (support.Player.Credits < Cost)
			return 0;

		//get drone and base count
		var drones = support.Drones.Count;
		var bases = support.CommandBases.Count;

		//if there are 0 bases, return 0
		if (bases == 0)
			return 0;

		//if we have more drones than bases to support them, return 0
		if (drones >= bases * DronesPerBase) return 0;
		//if we pass all of these checks, build a drone
		return 1;

	}

	public override void Execute ()
	{
		//Debug.Log (support.Player.Name + " is creating a drone.");

		//select a base to build a drone
		var bases = support.CommandBases;
		//select random index of our bases
		var index = Random.Range (0, bases.Count);
		//select random command base
		var commandBase = bases [index];
		//locate and execute the CreateUnitAction and execute the GetClickAction the extra () executes the function
		commandBase.GetComponent<CreateUnitAction> ().GetClickAction () ();
	}
}
