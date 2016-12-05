using UnityEngine;
using System.Collections;

//picked up by other classes
public abstract class AiBehavior : MonoBehaviour {

	//this is a way to influence the ai
	public float WeightMultiplier = 1;
	//how much time has passed
	public float TimePassed = 0;
	//method to detmine weight of descisions
	public abstract float GetWeight();
	//execute the descision
	public abstract void Execute();
}
