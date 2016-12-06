using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class RtsManager : MonoBehaviour {
	//Manage Game Information
	public static RtsManager Current = null;

	//Getting Player Information from PlayerSetupDefinition Class
	public List<PlayerSetupDefinition> Players = new List<PlayerSetupDefinition>();

	//get the TerrainCollider from the terrain of the map
	public TerrainCollider MapCollider;

	//where on the map we clicked, or we not have clicked
	//? means it is nullable because there is a chance we might not click on the map, in which case there is no point
	public Vector3? ScreenPointToMapPosition(Vector2 point) //2D representation of vectors and points
	{
		
		var ray = Camera.main.ScreenPointToRay (point); //ScreenPointToRay returns a ray going from camera through a screen point
		RaycastHit hit;
		//if we did not hit the map, return null
		if (!MapCollider.Raycast (ray, out hit, Mathf.Infinity))
			return null;
		//return the hit.point to get the position
		return hit.point;
	}

	//function to check terrain for obstacles
	public bool IsGameObjectSafeToPlace(GameObject go)
	{
		//get vertices from the MeshFilter
		var verts = go.GetComponent<MeshFilter> ().mesh.vertices;

		//get the obstacles that can interfere with build site
		var obstacles = GameObject.FindObjectsOfType<NavMeshObstacle> ();
		//get a list of the GameObject colliders
		var cols = new List<Collider> ();
		//iterate over obstacles and add the colliders
		foreach (var o in obstacles) {
			if (o.gameObject != go) {
				//add colliders to cols
				cols.Add (o.gameObject.GetComponent<Collider> ());
			}
		}

		//iterate over the vertices
		foreach (var v in verts) {
			//store the hit from the NavMeshHit
			NavMeshHit hit;
			//point in real worl space
			var vReal = go.transform.TransformPoint (v);
			//set the position of the object
			NavMesh.SamplePosition (vReal, out hit, 100, NavMesh.AllAreas);
			//check if the GameObject is on the correct axis
			bool onXAxis = Mathf.Abs (hit.position.x - vReal.x) < 0.5f;
			bool onZAxis = Mathf.Abs (hit.position.z - vReal.z) < 0.5f;
			//check to see if we have hit any colliders
			bool hitCollider = cols.Any (c => c.bounds.Contains (vReal));

			//check if our booleans are false and if there is a hitCollider in the way
			if (!onXAxis || !onZAxis || hitCollider) {
				return false;
			}
		}
		//if everything is good, return true and place structure
		return true;
	}

	//constructors will always complete before start method
	public RtsManager () {
		//When game starts RtsManager will be this Instance
		Current = this;		
	}

	// Use this for initialization
	void Start () {
		//get all starting players
		foreach (var p in Players) {
			//get player starting unit information
			foreach (var u in p.StartingUnits)
			{
				//starts each player with a GameObject(DroneUnit) at their location
				var go = (GameObject)GameObject.Instantiate(u, p.Location.position, p.Location.rotation);

				//get Player GameObject
				var player = go.AddComponent<Player>();
				player.Info = p;
				//check to see if the player is ai, if not, add the RightClickNavigation
				if (!p.IsAi)
				{
					//if player hasn't been set, set player = p
					if (Player.Default == null) Player.Default = p;
					go.AddComponent<RightClickNavigation>();
					//add the buttons to the Human Players action menu
					go.AddComponent<ActionSelect>();
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {

	}
}
