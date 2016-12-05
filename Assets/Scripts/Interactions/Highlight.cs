using UnityEngine;
using System.Collections;

//inherits from Interaction Class
public class Highlight : Interaction {

	public GameObject DisplayItem;

	//override the default behavior
	public override void Deselect ()
	{
		//when deselected disable DisplayItem
		DisplayItem.SetActive (false);
	}

	public override void Select ()
	{
		//when selected display the DisplayItem
		DisplayItem.SetActive (true);
	}

	// Use this for initialization
	void Start () {
		//disable DisplayItem on game start
		DisplayItem.SetActive (false);
	}
}
