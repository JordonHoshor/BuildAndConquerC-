using UnityEngine;
using System.Collections;

//Class to destroy GameObjects
public class DestroyOnNoHealth : MonoBehaviour {

	//GameObject that is used for explosion
	public GameObject ExplosionPrefab;
	//reference to unit health
	private ShowUnitInfo info;

	// Use this for initialization
	void Start () {
		//get unit info
		info = GetComponent<ShowUnitInfo> ();
	}
	
	// Update is called once per frame
	void Update () {
		//check current health
		if (info.CurrentHealth <= 0) {
			//if less than 0, destroy GameObject
			Destroy (this.gameObject);
			//instantiate explosion
			GameObject.Instantiate (ExplosionPrefab, transform.position, Quaternion.identity);
		}
	}
}
