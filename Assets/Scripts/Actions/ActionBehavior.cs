using UnityEngine;
using System;
using System.Collections;

//abstract class gets picked up by other classes
public abstract class ActionBehavior : MonoBehaviour {
	//extract click action
	public abstract Action GetClickAction();
	//variable to hold the sprite
	public Sprite ButtonPic;
}
