using UnityEngine;
using System.Collections.Generic;

//determine which descision is the best at this time
public class AiController : MonoBehaviour {

	public string PlayerName;
	//random value added to each ai
	public float Confusion = 0.3f;
	//how often the ai makes descions
	public float Frequency = 1;
	//store player information
	private PlayerSetupDefinition player;
	//a way for the ai to track how much time has passed
	private float waited = 0;
	//list of ai behaviors
	private List<AiBehavior> Ais = new List<AiBehavior>();
	//returns the private player
	public PlayerSetupDefinition Player { get { return player; } }

	// Use this for initialization
	void Start () {
		//iterate over each ai and add to list
		foreach (var ai in GetComponents<AiBehavior>()) {
			//Add the ai to the Ais List
			Ais.Add (ai);
		}
		//iterate over the current players
		foreach (var p in RtsManager.Current.Players) {
			//check to see if the playername equals the player
			if (p.Name == PlayerName) player = p;
		}
		//get the AiSupport Class, and add it to the player
		gameObject.AddComponent<AiSupport> ().Player = player;
	}

	// Update is called once per frame
	//figure out which ai is best in the list
	void Update () {
		//have we waited long enough
		waited += Time.deltaTime;
		//if waited is less than frequency, return
		if (waited < Frequency)
			return;

		//loggind system for the ai
		string aiLog = "";
		float bestAiValue = float.MinValue;
		//reference to hold onto the best ai
		AiBehavior bestAi = null;
		//get latest information before ai makes a descision
		AiSupport.GetSupport (gameObject).Refresh ();
		//iterate over ai to determine worth
		foreach (var ai in Ais) {
			//tell ai how much time has passed
			ai.TimePassed += waited;
			//how much is current ai worth
			var aiValue = ai.GetWeight() * ai.WeightMultiplier + Random.Range(0, Confusion);
			//get the ai name and value
			aiLog += ai.GetType().Name + ":" + aiValue + "\n";
			//check to see if aiValue is better than current ai
			if (aiValue > bestAiValue)
			{
				//if it is better, replace 
				bestAiValue = aiValue;
				bestAi = ai;
			}
		}
		//print the ailog to the console
		Debug.Log (aiLog);
		//execute the best ai
		bestAi.Execute ();
		//reset the timer
		waited = 0;
	}
}
