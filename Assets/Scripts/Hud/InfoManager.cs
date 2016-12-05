using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InfoManager : MonoBehaviour {
	//easily find class in code base
	public static InfoManager Current;

	//get unit profilePic
	public Image ProfilePic;
	//unit information variables
	public Text Line1, Line2, Line3;

	//constructor
	public InfoManager()
	{
		Current = this;
	}

	//method to set the text in the info box
	public void SetLines(string line1, string line2, string line3)
	{
		//get UI elements and set their values
		Line1.text = line1;
		Line2.text = line2;
		Line3.text = line3;
	}

	//clear text method
	public void ClearLines()
	{
		SetLines ("", "", "");
	}

	//set profilePic for info box
	public void SetPic(Sprite pic)
	{
		ProfilePic.sprite = pic;
		ProfilePic.color = Color.white;
	}

	//remove image from info box
	public void ClearPic()
	{
		ProfilePic.color = Color.clear;
	}

	// Use this for initialization
	void Start () {
		//clear info box on game start
		ClearLines ();
		ClearPic ();
	}
}
