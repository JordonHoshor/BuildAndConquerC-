using UnityEngine;
using System.Collections;

//inherits from AiBehavior
public class CreateBaseAi : AiBehavior {

	//get access to AiSupport Class
	private AiSupport support = null;

	//how much structure costs
	public float Cost = 200;
	//how many units per base
	public int UnitsPerBase = 5;
	//how far from drone can we build
	public float RangeFromDrone = 50;
	//how man times should we try to build before moving to the next drone
	public int TriesPerDrone = 3;
	//store the BasePrefab
	public GameObject BasePrefab;

	//override inherited methods, set the weights of descions
	public override float GetWeight ()
	{
		//if support is null, get the AiSupport Class
		if (support == null)
			support = AiSupport.GetSupport (gameObject);
		//if there isnt enough credits or drones, set low weight
		if (support.Player.Credits < Cost || support.Drones.Count == 0)
			return 0;
		//if there are no commandbases and we can make one, return 1 for weight
		if (support.CommandBases.Count * UnitsPerBase <= support.Drones.Count)
			return 1;

	    return 0;
	}

	//override inherited methods
	public override void Execute ()
	{
		Debug.Log ("Creating Base");

		//get GameObject to Instantiate
		var go = GameObject.Instantiate (BasePrefab);
		go.AddComponent<Player> ().Info = support.Player;

		//iterate over the available drones
		foreach (var drone in support.Drones) {
			//how many times to try for each drone
			for (int i = 0; i < TriesPerDrone; i++) {
				//start at the current drone position
				var pos = drone.transform.position;
				//change that position into a random direction. insideUnitSphere returns a units sphere
				pos += Random.insideUnitSphere * RangeFromDrone;
				//make sure the height is on the terrain
				pos.y = Terrain.activeTerrain.SampleHeight (pos);

				//set the base to this position
				go.transform.position = pos;

				//check if this is a safe place to put base, go is GameObject
				if (RtsManager.Current.IsGameObjectSafeToPlace (go)) {
					//subtract cost from total credits
					support.Player.Credits -= Cost;
					return;
				}
			}
		}
		//if there isnt an available space, destroy GameObject. Also prevents bases from overlapping
		Destroy (go);
	}
}
