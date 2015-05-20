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
	public Camera fifthFullCam;
	public Camera fifthHalfCam;
	public Camera sixthFullCam;
	public Camera sixthHalfCam;

	public Canvas canvas2;
	public Canvas canvas3;

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
		//GameControllerBalance.PauseGame ();
		//GameControllerMissiles.PauseGame ();	
		//GameControllerBasket.PauseGame ();
		//GameControllerRunAndJump.PauseGame ();
		canCancellOperation = true;

	}

	// Update is called once per frame
	void Update () 
	{
		/*
		if (MainMenu.isSoundOn == true) {
						if (GetComponent<AudioSource>().isPlaying == false) {
								GetComponent<AudioSource>().Play ();
						}
				} else {
			GetComponent<AudioSource>().Stop();
				}
		*/
		score += Time.deltaTime;
		if (gameOver == false) {
				CameraManager ();
				GameStateManager ();
				InputManager ();
		/// 
			if(GameControllerCalculation.isActive){
				if(fifthFullCam.rect == new Rect(0f,0f,0,0f)){
					(canvas2).worldCamera = fifthHalfCam;
				}else{
					(canvas2).worldCamera = fifthFullCam;
				}
			}
			if(GameControllerNoteMemory.isActive){
				if(sixthFullCam.rect == new Rect(0f,0f,0,0f)){
					(canvas3).worldCamera = sixthHalfCam;
				}else{
					(canvas3).worldCamera = sixthFullCam;
				}
			}
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
		GameControllerBalance.PauseGame();
		GameControllerMissiles.PauseGame();
		GameControllerBasket.PauseGame();
		GameControllerRunAndJump.PauseGame();
		GameControllerCalculation.PauseGame();
		GameControllerNoteMemory.PauseGame();
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
		else if (gameNo == "Game5") {
			GameControllerCalculation.StartGame();
		}
		else if (gameNo == "Game6") {
			GameControllerNoteMemory.StartGame();
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
		getCameraByGameNo(gameNo,"Full").rect = new Rect(0f, 0f, 1f, 1f);
	}

	public Camera getCameraByGameNo(string gameNo,string fullOrHalf){
		if (gameNo == "Game1") {
			if(fullOrHalf =="Full"){
				return firstFullCam;
			}
			else{
				return firstHalfCam;
			}
		}
		else if (gameNo == "Game2") {
			if(fullOrHalf =="Full"){
				return secondFullCam;
			}
			else{
				return secondHalfCam;
			}
		}
		else if (gameNo == "Game3") {
			if(fullOrHalf =="Full"){
				return thirdFullCam;
			}
			else{
				return thirdHalfCam;
			}
		}
		else if (gameNo == "Game4") {
			if(fullOrHalf =="Full"){
				return fourthFullCam;
			}
			else{
				return fourthHalfCam;
			}
		}
		else if (gameNo == "Game5") {
			if(fullOrHalf =="Full"){
				return fifthFullCam;
			}
			else{
				return fifthHalfCam;
			}
		}
		else if (gameNo == "Game6") {
			if(fullOrHalf =="Full"){
				return sixthFullCam;
			}
			else{
				return sixthHalfCam;
			}
		}
		return null;

	}

	public void manageCameraAccordingTo2Game(string firstGameNo,string secondGameNo){

		resetCameraPositionsAndViews ();
		getCameraByGameNo(firstGameNo,"Half").rect = new Rect(0f, 0f, 0.5f, 1f);
		getCameraByGameNo(secondGameNo,"Half").rect = new Rect(0.5f, 0f, 0.5f, 1f);

	}

	public void manageCameraAccordingTo3Game(string firstGameNo,string secondGameNo,string thirdGameNo){
		resetCameraPositionsAndViews ();
		getCameraByGameNo(firstGameNo,"Full").rect = new Rect(0f, 0.5f, 0.5f, 0.5f);
		getCameraByGameNo(secondGameNo,"Half").rect = new Rect(0.5f, 0f, 0.5f, 1f);
		getCameraByGameNo(thirdGameNo,"Full").rect = new Rect(0f, 0f, 0.5f, 0.5f);

	}
	public void manageCameraAccordingTo4Game(string firstGameNo,string secondGameNo,string thirdGameNo,string fourthGameNo){
		resetCameraPositionsAndViews ();
		getCameraByGameNo(firstGameNo,"Full").rect = new Rect(0f, 0.5f, 0.5f, 0.5f);
		getCameraByGameNo(secondGameNo,"Full").rect = new Rect(0.5f, 0.5f, 0.5f, 0.5f);
		getCameraByGameNo(thirdGameNo,"Full").rect = new Rect(0f, 0f, 0.5f, 0.5f);
		getCameraByGameNo(fourthGameNo,"Full").rect = new Rect(0.5f, 0f, 0.5f, 0.5f);

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
		fifthFullCam.rect = new Rect(0f, 0f, 0f, 0f);
		fifthHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
		sixthFullCam.rect = new Rect(0f, 0f, 0f, 0f);
		sixthHalfCam.rect = new Rect(0f, 0f, 0f, 0f);

	}

	public static Vector3 getAccelerometerInput()
	{
		return accelerometerInput;
	}
	
	public static Vector2 getDeltaTouchPosition()
	{
		return touchDeltaPosition;
	}


	public static bool miniGameInputControl(Touch currentTouch,Game myGame,GameType gameType,GameState gameState){

	if (gameType == GameType.selectedGameCount1) {
			return true;
	}
	else if (gameType == GameType.selectedGameCount2) {
			if(gameState == GameState.Selected1GameIsActive){
				return true;
			}
			else if(gameState == GameState.Selected2GameIsActive){

				if(myGame == MiniGameConfigurations.selected1GameIs){
					return isInputPositionCorrect(currentTouch,"LEFT");
				}
				else if(myGame == MiniGameConfigurations.selected2GameIs){
					return isInputPositionCorrect(currentTouch,"RIGHT");
				}
			}
	}
	else if (gameType == GameType.selectedGameCount4) {
			if(gameState == GameState.Selected1GameIsActive){
				return true;
			}
			else if(gameState == GameState.Selected2GameIsActive){
				
				if(myGame == MiniGameConfigurations.selected1GameIs){
					return isInputPositionCorrect(currentTouch,"LEFT");
				}
				else if(myGame == MiniGameConfigurations.selected2GameIs){
					return isInputPositionCorrect(currentTouch,"RIGHT");
				}
			}
			else if(gameState == GameState.Selected3GameIsActive){
				
				if(myGame == MiniGameConfigurations.selected1GameIs){
					return isInputPositionCorrect(currentTouch,"UPPERLEFT");
				}
				else if(myGame == MiniGameConfigurations.selected2GameIs){
					return isInputPositionCorrect(currentTouch,"RIGHT");
				}
				else if(myGame == MiniGameConfigurations.selected3GameIs){
					return isInputPositionCorrect(currentTouch,"BOTTOMLEFT");
				}
			}
			else if(gameState == GameState.Selected4GameIsActive){
				
				if(myGame == MiniGameConfigurations.selected1GameIs){
					return isInputPositionCorrect(currentTouch,"UPPERLEFT");
				}
				else if(myGame == MiniGameConfigurations.selected2GameIs){
					return isInputPositionCorrect(currentTouch,"UPPERRIGHT");
				}
				else if(myGame == MiniGameConfigurations.selected3GameIs){
					return isInputPositionCorrect(currentTouch,"BOTTOMLEFT");
				}
				else if(myGame == MiniGameConfigurations.selected4GameIs){
					return isInputPositionCorrect(currentTouch,"BOTTOMRIGHT");
				}
			}
	}
		return true;
	
	}

	public static bool isInputPositionCorrect(Touch currentTouch,string inWhere){

		if (inWhere == "LEFT") {
			if(currentTouch.position.x <= Screen.width / 2){
				return true;
			}
			else{
				return false;
			}
			
		}
		else if (inWhere == "RIGHT") {
			if(currentTouch.position.x >= Screen.width / 2){
				return true;
			}
			else{
				return false;
			}
			
		}
		else if (inWhere == "UPPERLEFT") {
			if((currentTouch.position.x <= Screen.width / 2) && currentTouch.position.y >= Screen.height/2){
				return true;
			}
			else{
				return false;
			}
			
		}
		else if (inWhere == "UPPERRIGHT") {
			if((currentTouch.position.x >= Screen.width / 2) && currentTouch.position.y >= Screen.height/2){
				return true;
			}
			else{
				return false;
			}

		}
		
		else if (inWhere == "BOTTOMLEFT") {
			if((currentTouch.position.x <= Screen.width / 2) && currentTouch.position.y <= Screen.height/2 ){
				return true;
			}
			else{
				return false;
			}
			
		}
		
		else if (inWhere == "BOTTOMRIGHT") {
			if((currentTouch.position.x >= Screen.width / 2) && currentTouch.position.y <= Screen.height/2 ){
				return true;
			}
			else{
				return false;
			}
			
		}
		return true;


	}




}
