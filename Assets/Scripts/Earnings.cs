using UnityEngine;
using System.Collections;

public class Earnings : MonoBehaviour {

	//credits players earn per second
	public float CreditsPerSecond = 1;
	//set the player information
	private PlayerSetupDefinition player;

	// Use this for initialization
	void Start () {
		//get player info
		player = GetComponent<Player> ().Info;
	}

	// Update is called once per frame
	void Update () {
		//update credits per frame
		player.Credits += CreditsPerSecond * Time.deltaTime;
	}
}
