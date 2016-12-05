using UnityEngine;
using System.Collections;

public class MarkColor : MonoBehaviour {

	//public variable array of Renderers
	public MeshRenderer[] Renderers;

	// Use this for initialization
	void Start () {
		//get Player AccentColor component
		var color = GetComponent<Player> ().Info.AccentColor;
		foreach (var r in Renderers) {
			r.material.color = color;
		}
	}
}
