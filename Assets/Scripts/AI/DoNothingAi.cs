using UnityEngine;
using System.Collections;

//default action where nothing happens
public class DoNothingAi : AiBehavior {

	//return a weight value that is easily accesible
	public float ReturnWeight = 0.5f;

	//override functions
	public override float GetWeight ()
	{
		return ReturnWeight;
	}

	public override void Execute ()
	{
		Debug.Log ("Doing Nothing");
	}
}
