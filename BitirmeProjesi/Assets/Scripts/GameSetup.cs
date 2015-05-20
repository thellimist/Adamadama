using UnityEngine;
using System.Collections;

public enum Game{
	
	Game1,
	Game2,
	Game3,
	Game4,
	Game5,
	Game6,
	NotAGame
};
public enum GameType{

	selectedGameCount1,
	selectedGameCount2,
	selectedGameCount4
};
public enum GameState 
{
	MainMenu,
	//OneGame,
	//TwoGames,
	//ThreeGames,
	//FourGames,
	GameOver,
	Selected1GameIsActive,
	Selected2GameIsActive,
	Selected3GameIsActive,
	Selected4GameIsActive,

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

}

