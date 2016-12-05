using UnityEngine;
using System.Collections;

public class FindbuildingSite : MonoBehaviour {

	//cost of the Command Base
	public float Cost = 200;
	//distance a unit can build from itself
	public float MaxBuildDistance = 30;
	//GameObject to plcae
	public GameObject BuildingPrefab;
	//get player information
	public PlayerSetupDefinition Info;
	//source(DroneUnit)
	public Transform Source;

	//store the renderer to change
	Renderer rend;
	//colors to change ghost structure to when it is safe or not safe to build
	Color Red = new Color (1, 0, 0, 0.5f);
	Color Green = new Color (0, 1, 0, 0.5f);

	void Start()
	{
		//disable default MouseManager
		MouseManager.Current.enabled = false;
		//get renderers on when start method is called
		rend = GetComponent<Renderer> ();
	}

	// Update is called once per frame
	void Update () {
		//set the current mouse position as tempTarget
		var tempTarget = RtsManager.Current.ScreenPointToMapPosition (Input.mousePosition);
		//if tempTarget has no value, return
		if (tempTarget.HasValue == false)
			return;
		//if there is a value, set the value to the position
		transform.position = tempTarget.Value;

		//least amout of distance that is safe to place
		if (Vector3.Distance (transform.position, Source.position) > MaxBuildDistance) {
			//if distance is greater that MaxBuildDistance change to red
			rend.material.color = Red;
			return;
		}

		//check to see if we can build
		if (RtsManager.Current.IsGameObjectSafeToPlace (gameObject)) {
			//if it is safe to build, set material to green
			rend.material.color = Green;
			//listen for player MouseButton input
			if (Input.GetMouseButtonDown (0)) {
				//get GameObject and instantiate
				var go = GameObject.Instantiate (BuildingPrefab);
				//add the ActionSelect Class to instantiated BuildingPrefab
				go.AddComponent<ActionSelect> ();
				//set the GameObject position
				go.transform.position = transform.position;
				//subtract the cost of the building from player total credits
				Info.Credits -= Cost;
				//add player info
				go.AddComponent<Player> ().Info = Info;
				//destroy the GhostBuildingPrefab
				Destroy (this.gameObject);
			}
		} else {
			//if not safe to build, change to red
			rend.material.color = Red;
		}
	}

	void OnDestroy()
	{
		//make sure to enable the MouseManage when we are finished
		MouseManager.Current.enabled = true;
	}

}
