using UnityEngine;
using System.Collections;

public enum GameState 
{
	MainMenu,
	OneGame,
	TwoGames,
	ThreeGames,
	FourGames,
	GameOver
	/*    
		MainMenu,
	    Intro,
	    Tutorial,
	    GetReady,
	    LevelRunning,
	    LostLife,
	    GameOver,
	    HighScore,
	    Credits*/
};

public class GameSetup : MonoBehaviour 
{
	public static GameState state;


	void Awake()
	{
		//state = GameState.MainMenu;
		state = GameState.OneGame;
		DontDestroyOnLoad (this);
	}

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	static void StateChange(GameState newState)
	{
		state = newState;
	}
}
