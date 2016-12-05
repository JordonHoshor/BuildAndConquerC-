using UnityEngine;
using System.Collections.Generic;

//Player information and active units, added to every player in game
public class Player : MonoBehaviour {

	//get access to this by calling Player.Info
	public PlayerSetupDefinition Info;

	public static PlayerSetupDefinition Default;

	void Start()
	{
		//add GameObject to ActiveUnits
		Info.ActiveUnits.Add (this.gameObject);
	}

	void OnDestroy()
	{
		//when a GameObject is destroyed remove from ActiveUnits
		Info.ActiveUnits.Remove (this.gameObject);
	}
}
