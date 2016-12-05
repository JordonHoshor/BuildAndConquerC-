using UnityEngine;
using System.Collections;

public class Interactive : MonoBehaviour {

	//are we Selected, private so inspector can't change value
	private bool _Selected = false;

	//so other objects can see if an object is selected
	public bool Selected { get { return _Selected; } }

	//a way to manually select or deslect GameObject
	public bool Swap = false;

	public void Select()
	{
		//selects unit
		_Selected = true;
		//for every interaction that is associated with the object 
		foreach (var selection in GetComponents<Interaction>()) {
			selection.Select();
		}
	}

	public void Deselect()
	{
		//deselect game object
		_Selected = false;
		foreach (var selection in GetComponents<Interaction>()) {
			selection.Deselect();
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Swap) {
			//change to false
			Swap = false;
			//set wether or not an object is selected
			if (_Selected) Deselect();
			else Select ();
		}
	}
}
