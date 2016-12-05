using UnityEngine;
using System.Collections.Generic;

public class MouseManager : MonoBehaviour {

	public static MouseManager Current;

	public MouseManager()
	{
		Current = this;
	}
		
	//List of all the selections from Interactive Class
	private List<Interactive> Selections = new List<Interactive>();

	// Update is called once per frame
	void Update () {
		//if no user input ignore this
		if (!Input.GetMouseButtonDown (0))
			return;
		
		//if a current 2D element(action menu) is being clicked, don't select 3D element behind
		var es = UnityEngine.EventSystems.EventSystem.current;

		//IsPointerOverGameObject returns true if over 2D ui element
		if (es != null && es.IsPointerOverGameObject ())
			//when both are true return
			return;

		if (Selections.Count > 0) {
			//when user holds shift keys, continue Selections
			if (!Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.RightShift))
			{
				//iterate over the Selections
				foreach(var sel in Selections)
				{
					//if the selection is not null, deselect
					if (sel != null) sel.Deselect();
				}
				//clear the selections
				Selections.Clear();
			}
		}

		//find out if we have clicked anything
		var ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		//if you do hit something, store it as a RaycastHit
		RaycastHit hit;
		//if the click didn't hit anything, return
		if (!Physics.Raycast (ray, out hit))
			return;
		
		//if the item we hit is interactive, get the Interactive Class
		var interact = hit.transform.GetComponent<Interactive> ();
		//if there is no interaction return
		if (interact == null)
			return;

		//select the unit and add the interaction
		Selections.Add (interact);
		interact.Select ();
	}
}
