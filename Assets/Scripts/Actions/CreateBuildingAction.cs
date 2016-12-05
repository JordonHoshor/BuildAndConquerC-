using UnityEngine;
using System.Collections;

//inherits from ActionBehavior
public class CreateBuildingAction : ActionBehavior {

	//cost of the structure
	public float Cost = 0;
	//store GameObject BuildingPrefab
	public GameObject BuildingPrefab;
	//distance from unit that a structure can be built
	public float MaxBuildDistance = 50;

	//get the GameObject that is the Ghost Image that will appear before structure is built
	public GameObject GhostBuildingPrefab;
	private GameObject active = null;

	//override GetClickAction
	public override System.Action GetClickAction ()
	{
		//return delegated function
		return delegate() {
			//get player information
			var player = GetComponent<Player>().Info;
			//fetermine if player has enough credits
			if (player.Credits < Cost)
			{
				//if not enough credits, return
				Debug.Log("Not enough, this costs " + Cost);
				return;
			}
			//instantiate GhostBuildingPrefab
			var go = GameObject.Instantiate(GhostBuildingPrefab);
			//call the FindbuildingSite Class
			var finder = go.AddComponent<FindbuildingSite>();
			//get the building prefab to place
			finder.BuildingPrefab = BuildingPrefab;
			//get the max build distance
			finder.MaxBuildDistance = MaxBuildDistance;
			//get the player infor for this building
			finder.Info = player;
			//get the transform(DroneUnit) that is trying to build
			finder.Source = transform;
			//make sure the ghost follows the mouse
			active = go;
		};
	}

	void Update()
	{
		if (active == null)
			return;

		if (Input.GetKeyDown (KeyCode.Escape))
			GameObject.Destroy (active);
	}

	void OnDestroy()
	{
		//see if object is active
		if (active == null)
			return;
		//if it is active, destroy
		Destroy (active);
	}

}
