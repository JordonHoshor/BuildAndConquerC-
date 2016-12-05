using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CashBoxManager : MonoBehaviour {

	//public variable to store the CashField value
	public Text CashField;
	
	// Update is called once per frame
	void Update () {
		//get the credits information from the Player
		CashField.text = "$ " + (int)Player.Default.Credits;
	}
}
