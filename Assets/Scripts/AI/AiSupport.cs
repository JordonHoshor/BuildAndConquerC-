using UnityEngine;
using System.Collections.Generic;

public class AiSupport : MonoBehaviour {

	//list of how many drones and bases
	public List<GameObject> Drones = new List<GameObject>();
	public List<GameObject> CommandBases = new List<GameObject>();

	//which player information
	public PlayerSetupDefinition Player = null;

	//get access to this Class easily
	public static AiSupport GetSupport (GameObject go)
	{
		//return the GameObjects AiSupport Component
		return go.GetComponent<AiSupport>();
	}

	//method to refresh the data
	public void Refresh()
	{
		//clear any data that we have
		Drones.Clear ();
		CommandBases.Clear ();
		//iterates over the players active units
		foreach (var u in Player.ActiveUnits) {
			//if the unit name matches the string, add it to the appropriate list
			if (u.name.Contains("Drone Unit")) Drones.Add (u);
			if (u.name.Contains("Command Base")) CommandBases.Add(u);
		}
	}
}
