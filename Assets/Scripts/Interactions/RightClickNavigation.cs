using UnityEngine;
using System.Collections;

//inherits from Interaction
public class RightClickNavigation : Interaction {

	//how far we have to be from the position relax
	public float RelaxDistance = 20;

	//get the NavMeshAgent
	private NavMeshAgent agent;
	//target destination
	private Vector3 target = Vector3.zero;
	private bool selected = false;
	private bool isActive = false;

	//override the default behavior
	public override void Deselect ()
	{
		selected = false;
	}

	public override void Select ()
	{
		selected = true;
	}

	//used to make the target variable public
	public void SendToTarget(Vector3 pos) {
		target = pos;
		SendToTarget ();
	}

	//tell unit to move to target
	public void SendToTarget()
	{
		agent.SetDestination (target);
		agent.Resume ();
		isActive = true;
	}

	// Use this for initialization
	void Start () {
		//get the NavMeshAgent
		agent = GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {
		//when unit is selected and right click has been clicked
		if (selected && Input.GetMouseButtonDown (1)) {
			var tempTarget = RtsManager.Current.ScreenPointToMapPosition(Input.mousePosition);
			if (tempTarget.HasValue) {
				target = tempTarget.Value;
				SendToTarget();
			}
		}
		//if the unit is currently moving, and is withing RelaxDeistance
		if (isActive && Vector3.Distance (target, transform.position) < RelaxDistance) {
			//Stop moving
			agent.Stop ();
			//unit is not moving
			isActive = false;
		}
	}
}
