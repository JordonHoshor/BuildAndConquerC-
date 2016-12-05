using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Map : MonoBehaviour {

	//position and size of ViewPort
	public RectTransform ViewPort;
	//GameObject Corners of the map
	public Transform Corner1, Corner2;
	//grab the BlipPrefab to use when a unit is created
	public GameObject BlipPrefab;
	//public available instance of Map
	public static Map Current;

	private Vector2 terrainSize; 

	//transform for the current map, RectTransfrom includes height and width
	private RectTransform mapRect;

	//Constructor
	public Map()
	{
		Current = this;
	}

	// Use this for initialization
	void Start () {
		terrainSize = new Vector2 (
			Corner2.position.x - Corner1.position.x,
			Corner2.position.z - Corner1.position.z);

		mapRect = GetComponent<RectTransform> ();
	}

	//find out where we are in relationship to the corner of the terrain
	public Vector2 WorldPositionToMap(Vector3 point)
	{
		var mapPos = new Vector2 (
			point.x / terrainSize.x * mapRect.rect.width,
			point.z / terrainSize.y * mapRect.rect.height);
		return mapPos;
	}
	
	// Update is called once per frame
	void Update () {
		ViewPort.position = WorldPositionToMap (Camera.main.transform.position);
	}
}
