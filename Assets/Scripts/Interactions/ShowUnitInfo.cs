using UnityEngine;
using System.Collections;

//inherits from Interaction Class
public class ShowUnitInfo : Interaction {

	//GameObject name
	public string Name;
	//GameObject MaxHealth/CurrentHealth
	public float MaxHealth, CurrentHealth;
	//GameObject ProfilePic
	public Sprite ProfilePic;

	//should we show data
	bool show = false;

	public override void Select()
	{
		//show live health when unit is selected
		show = true;	
	}

	 void Update ()
	{
		if (!show)
			return;
		//call InfoManager to display image and text in the info box
		InfoManager.Current.SetPic (ProfilePic);
		InfoManager.Current.SetLines (
			Name, 
			CurrentHealth + "/" + MaxHealth,
			"Owner: " + GetComponent<Player> ().Info.Name);
	}

	public override void Deselect ()
	{
		//clear info box on Deselect
		InfoManager.Current.ClearPic ();
		InfoManager.Current.ClearLines ();
		//when unit is deselected, change show to false
		show = false;
	}
}
