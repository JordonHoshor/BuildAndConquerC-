using UnityEngine;
using System.Collections.Generic;

public class VisibilityManager : MonoBehaviour {
	//how much time a GameObject will check for enemy units
	public float TimeBetweenChecks = 1;
	//how far we can see enemy units
	public float VisibleRange = 300;
	//manage how much time has passed
	private float waited = 10000;
	
	// Update is called once per frame
	void Update () {
		//increment waited time
		waited += Time.deltaTime;
		//if we haven't waited long enough, return
		if (waited <= TimeBetweenChecks)
			return;
		//when we have waited long enough, reset waited
		waited = 0;
		//get the player blips
		List<MapBlip> pBlips = new List<MapBlip> ();
		//get opponent blips
		List<MapBlip> oBlips = new List<MapBlip> ();

		//iterate over the curernt players
		foreach (var p in RtsManager.Current.Players) {
			//iterate over a palyers units
			foreach(var u in p.ActiveUnits)
			{
				//get the blip from that unit
				var blip = u.GetComponent<MapBlip>();
				//add the blib to the right player
				if (p == Player.Default) pBlips.Add (blip);
				else oBlips.Add(blip);
			}
		}
		//iterate over the oppents blips
		foreach (var o in oBlips) {
			//set to false until we can see
			bool active = false;
			//iterate over player blips
			foreach(var p in pBlips)
			{
				//how far between player and opponent blips
				var distance = Vector3.Distance(o.transform.position, p.transform.position);
				//if that range is less than the VisibleRange
				if (distance <= VisibleRange)
				{
					active = true;
					break;
				}
			}
			//show that active blip on the map
			o.Blip.SetActive(active);
			//show active unit in game
			foreach(var r in o.GetComponentsInChildren<Renderer>()) r.enabled = active;
		}
	}
}
