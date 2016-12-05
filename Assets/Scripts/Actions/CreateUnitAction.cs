using UnityEngine;
using System.Collections;

//inherits from ActionBehavior
public class CreateUnitAction : ActionBehavior {

	//public prefab to create
	public GameObject Prefab;
	//cost of unit to create
	public float Cost = 0;
	//player definition
	private PlayerSetupDefinition player;

	// Use this for initialization
	void Start () {
		//get access to player
		player = GetComponent<Player> ().Info;
	}

	//override GetClickAction
	public override System.Action GetClickAction ()
	{
		//return a delegated function
		return delegate() {
			//if player does not have enough credits, return
			if (player.Credits < Cost) {
				Debug.Log ("Cannot Create, It costs " + Cost);
				return;
			}
			//if player has enough credits, instantiate a new GameObject(DroneUnit)
			var go = (GameObject)GameObject.Instantiate (
				//Instantiate a prefab
				Prefab,
				//the position to instantiate
				transform.position,
				//Quaternion is used to represent rotation, so set the rotation of the instantiated GameObject
				Quaternion.identity);
			//add player info to the drone
			go.AddComponent<Player> ().Info = player;
			//add the RightClickNavigation Class to the new DroneUnit
			go.AddComponent<RightClickNavigation> ();
			//add the ActionSelect Class to the DroneUnit
			go.AddComponent<ActionSelect> ();
			//subtract the credits from total player credits
			player.Credits -= Cost;
		};
	}
}
