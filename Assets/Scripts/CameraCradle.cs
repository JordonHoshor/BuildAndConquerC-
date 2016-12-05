using UnityEngine;
using System.Collections;

// Set main camera to player perspective
public class CameraCradle : MonoBehaviour {

	public float Speed = 20;
	public float Height = 250;

	// Use this for initialization
	void Start () {
		//iterate over the current players
		foreach (var p in RtsManager.Current.Players) {
			//skip the ai
			if (p.IsAi)
				continue;

			//get the position of the human player
			var pos = p.Location.position;
			//get the height
			pos.y = Height;
			//set the camera position to human player start position
			transform.position = pos;
		}
	}
	
	// Update is called once per frame
	void Update () {
		//move camera based on player input
		//keyboard arrows are used by default
		transform.Translate (
			Input.GetAxis ("Horizontal") * Speed * Time.deltaTime, //Time.deltaTime is time it took to complete last frame
			Input.GetAxis ("Vertical") * Speed * Time.deltaTime,
			0);
	}
}
