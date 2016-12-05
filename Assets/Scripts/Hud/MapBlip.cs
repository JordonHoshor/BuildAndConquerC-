using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MapBlip : MonoBehaviour {

	//get access to the blip GameObject
	private GameObject blip;
	//public Blip that returns private blip
	public GameObject Blip { get { return blip; } }

	// Use this for initialization
	void Start () {
		//get access to the BlipPrefab
		blip = GameObject.Instantiate (Map.Current.BlipPrefab);
		//gives a blip to each unit on the map
		blip.transform.parent = Map.Current.transform;
		//get player color
		var color = GetComponent<Player> ().Info.AccentColor;
		//sets blip color to the player color
		blip.GetComponent<Image> ().color = color;
	}
	
	// Update is called once per frame
	void Update () {
		//updates the units position on the map every frame
		blip.transform.position = Map.Current.WorldPositionToMap (transform.position);
	}

	void OnDestroy()
	{
		//destroy blip when GameObject is destroyed
		GameObject.Destroy (blip);
	}
}
