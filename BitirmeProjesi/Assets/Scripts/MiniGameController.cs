using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MiniGameController : MonoBehaviour 
{	
	// Public Variables
	public Camera firstFullCam;
	public Camera firstHalfCam;
	public Camera secondFullCam;
	public Camera secondHalfCam;
	public Camera thirdFullCam;
	public Camera thirdHalfCam;
	public Camera fourthFullCam;
	public Camera fourthHalfCam;

	public Text	currentLevelText;

	// Karma Variables
	public static float score;
	public static bool gameOver = false;
	public static bool isSoundOn = true;

	public bool canCancellOperation = true;

	GUIStyle myfontSize;

	// Input Variables
	static Vector2 touchDeltaPosition;
	static Vector3 accelerometerInput;


	// Use this for initialization
	void Awake()
	{
		score = 0;
		gameOver = false;
	}

	void Start () 
	{
		Time.timeScale = 1;

	}

	public void waitUpdateForGameResetter() {

		canCancellOperation = false;
		GameControllerBalance.PauseGame ();
		GameControllerMissiles.PauseGame ();	
		GameControllerBasket.PauseGame ();
		GameControllerRunAndJump.PauseGame ();
		canCancellOperation = true;

	}

	// Update is called once per frame
	void Update () 
	{
		if (MainMenu.isSoundOn == true) {
						if (GetComponent<AudioSource>().isPlaying == false) {
								GetComponent<AudioSource>().Play ();
						}
				} else {
			GetComponent<AudioSource>().Stop();
				}
		score += Time.deltaTime;
		if (gameOver == false) {
				CameraManager ();
				GameStateManager ();
				InputManager ();
		/// 

		if 	(MiniGameConfigurations.currentGameState == GameState.Selected1GameIsActive
				&& 
		    (
		    (MiniGameConfigurations.currentGameType == GameType.selectedGameCount2 && score > MiniGameConfigurations.twoGameSelectedTotalMaxTime/2)
			||
			(MiniGameConfigurations.currentGameType == GameType.selectedGameCount4 && score > MiniGameConfigurations.fourGameSelectedTotalMaxTime/4)
			)
		    )
		{
				MiniGameConfigurations.currentGameState = GameState.Selected2GameIsActive;	
				waitUpdateForGameResetter();

		} 
		else if (MiniGameConfigurations.currentGameState == GameState.Selected2GameIsActive
		           && 
				(MiniGameConfigurations.currentGameType == GameType.selectedGameCount4 && score > MiniGameConfigurations.fourGameSelectedTotalMaxTime/2)
		         )
		{
				MiniGameConfigurations.currentGameState = GameState.Selected3GameIsActive;
				waitUpdateForGameResetter();
		} else if (MiniGameConfigurations.currentGameState == GameState.Selected3GameIsActive
		           && 
		           (MiniGameConfigurations.currentGameType == GameType.selectedGameCount4 && score > MiniGameConfigurations.fourGameSelectedTotalMaxTime*3/4)
		           )
		{
				MiniGameConfigurations.currentGameState = GameState.Selected4GameIsActive;
				waitUpdateForGameResetter();
		} 
		}

	}

	public static void GameOver()
	{
		// Set gameover attributes
		gameOver = true;
		MiniGameConfigurations.currentGameState = GameState.GameOver;
		//GameControllerBalance.PauseGame();
		//GameControllerMissiles.PauseGame();
		//GameControllerBasket.PauseGame();
		//GameControllerRunAndJump.PauseGame();
		Time.timeScale = 0;
	}

	void GameStateManager()
	{
		switch (MiniGameConfigurations.currentGameState) { 
				case GameState.MainMenu:
						break;
				case GameState.GameOver:
						break;
				case GameState.Selected1GameIsActive:
						gameStarterAccordingToGame(MiniGameConfigurations.selected1GameIs.ToString());
						break;
				case GameState.Selected2GameIsActive:
						gameStarterAccordingToGame(MiniGameConfigurations.selected1GameIs.ToString());
						gameStarterAccordingToGame(MiniGameConfigurations.selected2GameIs.ToString());
						break;
				case GameState.Selected3GameIsActive:
						gameStarterAccordingToGame(MiniGameConfigurations.selected1GameIs.ToString());
						gameStarterAccordingToGame(MiniGameConfigurations.selected2GameIs.ToString());
						gameStarterAccordingToGame(MiniGameConfigurations.selected3GameIs.ToString());
						break;
				case GameState.Selected4GameIsActive:
						gameStarterAccordingToGame(MiniGameConfigurations.selected1GameIs.ToString());
						gameStarterAccordingToGame(MiniGameConfigurations.selected2GameIs.ToString());
						gameStarterAccordingToGame(MiniGameConfigurations.selected3GameIs.ToString());
						gameStarterAccordingToGame(MiniGameConfigurations.selected4GameIs.ToString());
						break;
				}
	}

	public void gameStarterAccordingToGame(string gameNo){

		if (gameNo == "Game1") {
			GameControllerBalance.StartGame();
		}
		else if (gameNo == "Game2") {
			GameControllerMissiles.StartGame();
		}
		else if (gameNo == "Game3") {
			GameControllerBasket.StartGame();
		}
		else if (gameNo == "Game4") {
			GameControllerRunAndJump.StartGame();
		}

	}

	void InputManager()
	{
			if (Input.touchCount > 0 && 
			    Input.GetTouch(0).phase == TouchPhase.Moved) {
				// Get movement of the finger since last frame
				touchDeltaPosition = Input.GetTouch(0).deltaPosition;
			}

			accelerometerInput = Input.acceleration;

	}

	void CameraManager()
	{
		switch (MiniGameConfigurations.currentGameState)
		{ 
		case GameState.MainMenu:
			break;
		case GameState.Selected1GameIsActive:
			manageCameraAccordingTo1Game(MiniGameConfigurations.selected1GameIs.ToString());
			break;
		case GameState.Selected2GameIsActive:
			manageCameraAccordingTo2Game(MiniGameConfigurations.selected1GameIs.ToString(),
			                             MiniGameConfigurations.selected2GameIs.ToString());
			break;
		case GameState.Selected3GameIsActive:
			manageCameraAccordingTo3Game(MiniGameConfigurations.selected1GameIs.ToString(),
			                             MiniGameConfigurations.selected2GameIs.ToString(),
			                             MiniGameConfigurations.selected3GameIs.ToString());
			break;
		case GameState.Selected4GameIsActive:
			manageCameraAccordingTo4Game(MiniGameConfigurations.selected1GameIs.ToString(),
			                             MiniGameConfigurations.selected2GameIs.ToString(),
			                             MiniGameConfigurations.selected3GameIs.ToString(),
			                             MiniGameConfigurations.selected4GameIs.ToString());
			break;
		case GameState.GameOver:
			break;
		}
	}


	public void manageCameraAccordingTo1Game(string gameNo){
		resetCameraPositionsAndViews ();
		if (gameNo == "Game1") {
			firstFullCam.rect = new Rect(0f, 0f, 1f, 1f);
		}
		else if (gameNo == "Game2") {
			secondFullCam.rect = new Rect(0f, 0f, 1f, 1f);
		}
		else if (gameNo == "Game3") {
			thirdFullCam.rect = new Rect(0f, 0f, 1f, 1f);
		}
		else if (gameNo == "Game4") {
			fourthFullCam.rect = new Rect(0f, 0f, 1f, 1f);
		}
		// TODO ADD GAME Game 5 AND GAME 6
	}

	public void manageCameraAccordingTo2Game(string firstGameNo,string secondGameNo){

		resetCameraPositionsAndViews ();
		if (firstGameNo == "Game1") {
			firstHalfCam.rect = new Rect(0f, 0f, 0.5f, 1f);
			if(secondGameNo == "Game2"){
				secondHalfCam.rect = new Rect(0.5f, 0f, 0.5f, 1f);
			}
			else if(secondGameNo == "Game3"){
				thirdHalfCam.rect = new Rect(0.5f, 0f, 0.5f, 1f);
			}
			else if(secondGameNo == "Game4"){
				fourthHalfCam.rect = new Rect(0.5f, 0f, 0.5f, 1f);
			}
		}
		else if (firstGameNo == "Game2") {
			secondHalfCam.rect = new Rect(0f, 0f, 0.5f, 1f);
			if(secondGameNo == "Game3"){
				thirdHalfCam.rect = new Rect(0.5f, 0f, 0.5f, 1f);
			}
			else if(secondGameNo == "Game4"){
				fourthHalfCam.rect = new Rect(0.5f, 0f, 0.5f, 1f);
			}
		}
		else if (firstGameNo == "Game3") {
			thirdHalfCam.rect = new Rect(0f, 0f, 0.5f, 1f);
			fourthHalfCam.rect = new Rect(0.5f, 0f, 0.5f, 1f);
		}
		// TODO ADD GAME Game 5 AND GAME 6
	}

	public void manageCameraAccordingTo3Game(string firstGameNo,string secondGameNo,string thirdGameNo){
		resetCameraPositionsAndViews ();
		if (firstGameNo == "Game1" && secondGameNo == "Game2" && thirdGameNo =="Game3") {
			firstFullCam.rect = new Rect(0f, 0.5f, 0.5f, 0.5f);
			secondHalfCam.rect = new Rect(0.5f, 0f, 0.5f, 1f);
			thirdFullCam.rect = new Rect(0f, 0f, 0.5f, 0.5f);
		}
		else if (firstGameNo == "Game1" && secondGameNo == "Game2" && thirdGameNo =="Game4") {
			firstFullCam.rect = new Rect(0f, 0.5f, 0.5f, 0.5f);
			secondHalfCam.rect = new Rect(0.5f, 0.5f, 0.5f, 1f);
			fourthFullCam.rect = new Rect(0f, 0f, 0.5f, 0.5f);
		}
		else if (firstGameNo == "Game1" && secondGameNo == "Game3" && thirdGameNo =="Game4") {
			firstFullCam.rect = new Rect(0f, 0.5f, 0.5f, 0.5f);
			thirdHalfCam.rect = new Rect(0.5f, 0.5f, 0.5f, 1f);
			fourthFullCam.rect = new Rect(0f, 0f, 0.5f, 0.5f);
		}
		else if (firstGameNo == "Game2" && secondGameNo == "Game3" && thirdGameNo =="Game4") {
			secondFullCam.rect = new Rect(0f, 0.5f, 0.5f, 0.5f);
			thirdHalfCam.rect = new Rect(0.5f, 0.5f, 0.5f, 1f);
			fourthFullCam.rect = new Rect(0f, 0f, 0.5f, 0.5f);
		}
		// TODO ADD GAME Game 5 AND GAME 6
	}
	public void manageCameraAccordingTo4Game(string firstGameNo,string secondGameNo,string thirdGameNo,string fourthGameNo){
		resetCameraPositionsAndViews ();
		if (firstGameNo == "Game1" && secondGameNo == "Game2" && thirdGameNo =="Game3" && fourthGameNo =="Game4") {
			firstFullCam.rect = new Rect(0f, 0.5f, 0.5f, 0.5f);
			secondFullCam.rect = new Rect(0.5f, 0.5f, 0.5f, 0.5f);
			thirdFullCam.rect = new Rect(0f, 0f, 0.5f, 0.5f);
			fourthFullCam.rect = new Rect(0.5f, 0f, 0.5f, 0.5f);
		}
		// TODO ADD GAME Game 5 AND GAME 6
	}

	public void resetCameraPositionsAndViews(){

		firstFullCam.rect = new Rect(0f, 0f, 0f, 0f);
		firstHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
		secondFullCam.rect = new Rect(0f, 0f, 0f, 0f);
		secondHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
		thirdFullCam.rect = new Rect(0f, 0f, 0f, 0f);
		thirdHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
		fourthFullCam.rect = new Rect(0f, 0f, 0f, 0f);
		fourthHalfCam.rect = new Rect(0f, 0f, 0f, 0f);

		// TODO ADD GAME Game 5 AND GAME 6


	}

	public static Vector3 getAccelerometerInput()
	{
		return accelerometerInput;
	}
	
	public static Vector2 getDeltaTouchPosition()
	{
		return touchDeltaPosition;
	}

}
