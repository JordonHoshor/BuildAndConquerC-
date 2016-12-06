using UnityEngine;
using System.Collections;

//inherits from AiBehavior Class
public class StrikeAi : AiBehavior {

	//how many drones required to attack
	public int DronesRequired = 10;
	//how much time to wait
	public float TimeDelay = 5;
	//how big the squad size will be, 50%
	public float SquadSize = 0.5f;
	//Increase squad size per wave
	public int IncreasePerWave = 10;

	Vector3[] positionArray = new [] {new Vector3(175, 55, 150), new Vector3(175, 55, 900), new Vector3(875, 55, 900), new Vector3(875, 55, 150)};

	public override void Execute ()
	{
//		List<Transform> playerList = new List<Transform> ();

		//get the ai
		var ai = AiSupport.GetSupport (this.gameObject);
		//log a message that the ai is attacking
		Debug.Log(ai.Player.Name + " is attacking!");

		//get current wave size
		int wave = (int)(ai.Drones.Count * SquadSize);
        
		    //increase drones require based on increase per wave
			DronesRequired += IncreasePerWave;

		//find out where the human player is
		foreach(var p in RtsManager.Current.Players) {
			var randPos = Random.Range (0, positionArray.Length);
			//ignore the other Ai
			//if (p.IsAi)
				//continue;
			//iterate through items required to send the wave
			for (int i = 0; i < wave; i++) {
				var drone = ai.Drones [i];
				//get the RightClickNavigation Component
				var nav = drone.GetComponent<RightClickNavigation> ();
				//send the drones to the target
				nav.SendToTarget (positionArray[randPos - 1]);
			}
			return;
		}
	}

	public override float GetWeight () {
		//if enough time passed
		if (TimePassed < TimeDelay)
			return 0;
		//when enough time has passed, reset the TimePassed
		TimePassed = 0;

		//get the ai
		var ai = AiSupport.GetSupport (this.gameObject);
		//is there enough drones
		if (ai.Drones.Count < DronesRequired)
			return 0;
		
		//if we do have enough drones, return 1 weight
		return 1;
	}
}
