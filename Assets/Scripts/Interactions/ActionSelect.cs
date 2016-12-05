using UnityEngine;
using System.Collections;

//inherits from Interaction Class
public class ActionSelect : Interaction {

	//override methods
	public override void Deselect ()
	{
		//when we deselect, actions are cleared out
		ActionsManager.Current.ClearButtons ();
	}

	public override void Select ()
	{
		//clear buttons from previous selection
		ActionsManager.Current.ClearButtons ();
		//iterate over the actionBehavior attached to this GameObject
		foreach (var ab in GetComponents<ActionBehavior>()) {
			//add button from actions manager
			ActionsManager.Current.AddButton(
				ab.ButtonPic, 
				ab.GetClickAction());
		}
	}
}
