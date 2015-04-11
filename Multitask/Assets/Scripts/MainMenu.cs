using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour 
{
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	void OnGUI() {
		if (GUI.Button (new Rect (180, 180, 500, 50), "Start Game"))
		{
			GameSetup.state = GameState.OneGame;
			Application.LoadLevel ("GameScene");
		}

		/*if (GUI.Button (new Rect (10, 130, 350, 30), "Two Ganse"))
		{
			GameSetup.state = GameState.TwoGames;
			Application.LoadLevel ("GameScene");
		}

		if (GUI.Button (new Rect (10, 200, 350, 30), "Three Ganse"))
		{
			GameSetup.state = GameState.ThreeGames;
			Application.LoadLevel ("GameScene");
		}*/
	}
}
