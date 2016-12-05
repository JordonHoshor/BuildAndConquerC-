using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

	//which direction to rotate GameObject
	public Vector3 Rotation = Vector3.zero; //shorthand for Vector3(0,0,0)
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//rotates GameObject when called, which is every frame
		transform.Rotate (Rotation * Time.deltaTime);
	}
}
