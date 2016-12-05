using UnityEngine;
using System.Collections;

//abstract class: intended to be a base class for other classes
public abstract class Interaction : MonoBehaviour {

	public abstract void Select();
	public abstract void Deselect();
}
