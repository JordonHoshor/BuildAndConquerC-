using UnityEngine;
using System.Collections.Generic;

//Make this class visible to the inspector
[System.Serializable]

//Store Player information
public class PlayerSetupDefinition  {

	public string Name;

	public Transform Location;

	public Color AccentColor;
	//list of starting units
	public List<GameObject> StartingUnits = new List<GameObject>();
	//list of active units, private so they can't be edited in game
	private List<GameObject> activeUnits = new List<GameObject> ();
	//ActiveUnits has a getter that returns activeUnits
	public List<GameObject> ActiveUnits { get { return activeUnits; } }

	public bool IsAi;

	public float Credits;
}
