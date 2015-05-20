using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CheckScore : MonoBehaviour {
	
	public Text button1;
	public Text button2;
	public Text button3;
	public Text button4;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void check()
	{
		//Get the tag value of the button to choose.
		if (this.CompareTag ("button1")) 
		{
			button1 = GameObject.Find ("Canvas2").transform.FindChild ("Button1").transform.FindChild("Button1Text").GetComponent<Text> ();

			//Check whether this button has the correct value or not.
			if (button1.text.Equals(StartGame.sonuc.ToString()))
			{
				button1.text = "TRUE";
				button1.color = Color.green;
			}
			else
			{
				button1.text = "FALSE";
				button1.color = Color.red;
				MiniGameController.GameOver();
			}
		} 
		else if (this.CompareTag ("button2")) 
		{
			button2 = GameObject.Find ("Canvas2").transform.FindChild ("Button2").transform.FindChild("Button2Text").GetComponent<Text> ();

			//Check whether this button has the correct value or not.
			if (button2.text.Equals(StartGame.sonuc.ToString()))
			{
				button2.text = "TRUE";
				button2.color = Color.green;
			}
			else
			{
				button2.text = "FALSE";
				button2.color = Color.red;
				MiniGameController.GameOver();
			}
		} 
		else if (this.CompareTag ("button3")) 
		{
			button3 = GameObject.Find ("Canvas2").transform.FindChild ("Button3").transform.FindChild("Button3Text").GetComponent<Text> ();

			//Check whether this button has the correct value or not.
			if (button3.text.Equals(StartGame.sonuc.ToString()))
			{
				button3.text = "TRUE";
				button3.color = Color.green;
			}
			else
			{
				button3.text = "FALSE";
				button3.color = Color.red;
				MiniGameController.GameOver();
			}
		} 
		else if (this.CompareTag ("button4")) 
		{
			button4 = GameObject.Find ("Canvas2").transform.FindChild ("Button4").transform.FindChild("Button4Text").GetComponent<Text> ();

			//Check whether this button has the correct value or not.
			if (button4.text.Equals(StartGame.sonuc.ToString()))
			{
				button4.text = "TRUE";
				button4.color = Color.green;
			}
			else
			{
				button4.text = "FALSE";
				button4.color = Color.red;
				MiniGameController.GameOver();
			}
		}
	}
}
