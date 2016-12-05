using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class ActionsManager : MonoBehaviour {

	//get access to this class easily in code base
	public static ActionsManager Current;
	//list of all the buttons inside actions panel
	public Button[] Buttons;
	//get a list of all the actions available
	private List<Action> actionCalls = new List<Action>();

	//actions manager constructor
	public ActionsManager()
	{
		Current = this;
	}

	//method to clear the buttons
	public void ClearButtons()
	{
		//iterate over buttons and make sure disabled
		foreach (var b in Buttons)
			//disable buttons
			b.gameObject.SetActive (false);
		//clear the actionCalls
		actionCalls.Clear ();
	}

	//add a button with a sprite and click action
	public void AddButton(Sprite pic, Action onClick)
	{
		//index of the button
		int index = actionCalls.Count;
		//set the button to active
		Buttons [index].gameObject.SetActive (true);
		//set the image of the button
		Buttons [index].GetComponent<Image> ().sprite = pic;
		//add click event to the button
		actionCalls.Add (onClick);
	}

	//event methed to react to button clicks
	public void OnButtonClick (int index)
	{
		//look up the action method
		actionCalls [index] ();
	}


	// Use this for initialization
	void Start () {
		//initialize all buttons
		for (int i = 0; i < Buttons.Length; i++) {
			var index = i;
			//add button listener to listen for clicks
			Buttons[index].onClick.AddListener(delegate() {
				//add delegated event
				OnButtonClick (index);
			});
		}
		//clear buttons
		ClearButtons ();
	}
}
