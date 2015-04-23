using UnityEngine;
using System.Collections;

public class MiniGameConfigurations : MonoBehaviour {

	public static int twoGameSelectedTotalMaxTime = 8;
	public static int fourGameSelectedTotalMaxTime = 8;
	/*
	public static int firstGameFirstLevelSuccesTime = 10;
	public static int secondGameSecondLevelSuccesTime = 10;
	public static int thirdGameThirdLevelSuccesTime = 10;
	public static int fourthGameFourthLevelSuccesTime = 10;

	public static int fifthLevelSuccesTime = 10;
	public static int sixthLevelSuccesTime = 10;
	public static int seventhLevelSuccesTime = 10;
	public static int eigthLevelSuccesTime = 10;
	public static int ninethLevelSuccesTime = 10;
	public static int tenthLevelSuccesTime = 10;
	public static int eleventhLevelSuccesTime = 10;
	public static int twelvethLevelSuccesTime = 10;
	public static int thirteenthLevelSuccesTime = 10;
	public static int fourteenthLevelSuccesTime = 10;
	public static int fifteenthLevelSuccesTime = 10;

	*/
	
	public static Game selected1GameIs = Game.NotAGame;
	public static Game selected2GameIs = Game.NotAGame;
	public static Game selected3GameIs = Game.NotAGame;
	public static Game selected4GameIs = Game.NotAGame;

	public static GameType currentGameType = GameType.selectedGameCount2;
	public static GameState currentGameState = GameState.Selected1GameIsActive;

}
