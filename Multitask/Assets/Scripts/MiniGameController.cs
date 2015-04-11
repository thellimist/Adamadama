using UnityEngine;
using System.Collections;

public class MiniGameController : MonoBehaviour 
{	
	// Public Variables
	public Camera firstCam;
	public Camera secondCam;
	public Camera thirdCam;
	public Camera fourthCam;
	public Texture2D pauseButtonTexture;

	// Karma Variables
	float score;
	public static bool gameOver = false;
	GUIStyle myfontSize;

	// Input Variables
	static Vector2 touchDeltaPosition;
	static Vector3 accelerometerInput;
	static bool upKeyPressed = false;
	static bool downKeyPressed = false;
	static bool leftKeyPressed = false;
	static bool rightKeyPressed = false;
	static bool aKeyPressed = false;
	static bool dKeyPressed = false;
	static int touchCount = 0;

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
	
	// Update is called once per frame
	void Update () 
	{
		score += Time.deltaTime;


		// Change game state according to score dynamicly
		if (score > 15)
		{
			GameSetup.state = GameState.FourGames;
		}
		else if (score > 10)
		{
			GameSetup.state = GameState.ThreeGames;
		}
		else if (score > 5)
		{
			GameSetup.state = GameState.TwoGames;
		}

		CameraManager ();
		GameStateManager ();
		InputManager ();



	}

	public static void GameOver()
	{
		// Set gameover attributes
		gameOver = true;
		Time.timeScale = 0;
		GameControllerBalance.PauseGame();
		GameControllerMissiles.PauseGame();
		GameControllerBasket.PauseGame();
		GameControllerRunAndJump.PauseGame();

		// Open gameover GUI
	}

	void GameStateManager()
	{
		switch (GameSetup.state)
		{ 
		case GameState.MainMenu:
			break;
		case GameState.OneGame:
			GameControllerBalance.StartGame();
			GameControllerMissiles.PauseGame();
			GameControllerBasket.PauseGame();
			GameControllerRunAndJump.PauseGame();
			break;
		case GameState.TwoGames:
			GameControllerBalance.StartGame();
			GameControllerMissiles.StartGame();
			GameControllerBasket.PauseGame();
			GameControllerRunAndJump.PauseGame();
			break;
		case GameState.ThreeGames:
			GameControllerBalance.StartGame();
			GameControllerMissiles.StartGame();
			GameControllerBasket.StartGame();
			GameControllerRunAndJump.PauseGame();
			break;
		case GameState.FourGames:
			GameControllerBalance.StartGame();
			GameControllerMissiles.StartGame();
			GameControllerBasket.StartGame();
			GameControllerRunAndJump.StartGame();
			break;
		}
	}

	void InputManager()
	{
		if (!gameOver) {

			// Mobile Device
			if (Input.touchCount > 0 && 
			    Input.GetTouch(0).phase == TouchPhase.Moved) {
				// Get movement of the finger since last frame
				touchCount = Input.touchCount;
				touchDeltaPosition = Input.GetTouch(0).deltaPosition;
			} else {
				touchCount = 0;
			}

			accelerometerInput = Input.acceleration;

			// Computer
			if (Input.GetKey (KeyCode.UpArrow)) {
				upKeyPressed = true;
			}
			if (Input.GetKey (KeyCode.DownArrow)) {
				downKeyPressed = true;
			}
			if (Input.GetKey (KeyCode.LeftArrow)) {
				leftKeyPressed = true;
			}
			if (Input.GetKey (KeyCode.RightArrow)) {
				rightKeyPressed = true;
			}
			if (Input.GetKey ("a")) {
				aKeyPressed = true;
			}
			if (Input.GetKey ("d")) {
				dKeyPressed = true;
			}




			if (Input.GetKeyUp (KeyCode.UpArrow)) {
				upKeyPressed = false;
			}
			if (Input.GetKeyUp (KeyCode.DownArrow)) {
				downKeyPressed = false;
			}
			if (Input.GetKeyUp (KeyCode.LeftArrow)) {
				leftKeyPressed = false;
			}
			if (Input.GetKeyUp (KeyCode.RightArrow)) {
				rightKeyPressed = false;
			}
			if (Input.GetKeyUp ("a")) {
				aKeyPressed = false;
			}
			if (Input.GetKeyUp ("d")) {
				dKeyPressed = false;
			}



			// Quit App
			if (Input.GetKey ("escape")) {
				Application.Quit();
			}
		}

	}

	void CameraManager()
	{
		switch (GameSetup.state)
		{ 
		case GameState.MainMenu:
			break;
		case GameState.OneGame:
			firstCam.rect = new Rect(0f, 0f, 1f, 1f);
			secondCam.rect = new Rect(0f, 0f, 0f, 0f);
			thirdCam.rect = new Rect(0f, 0f, 0f, 0f);
			fourthCam.rect = new Rect(0f, 0f, 0f, 0f);
			break;
		case GameState.TwoGames:
			firstCam.rect = new Rect(0f, 0f, 0.5f, 1f);
			secondCam.rect = new Rect(0.5f, 0f, 0.5f, 1f);
			thirdCam.rect = new Rect(0f, 0f, 0f, 0f);
			fourthCam.rect = new Rect(0f, 0f, 0f, 0f);
			break;
		case GameState.ThreeGames:
			firstCam.rect = new Rect(0f, 0.5f, 0.5f, 0.5f);
			secondCam.rect = new Rect(0.5f, 0f, 0.5f, 1f);
			thirdCam.rect = new Rect(0f, 0f, 0.5f, 0.5f);
			fourthCam.rect = new Rect(0f, 0f, 0f, 0f);
			break;
		case GameState.FourGames:
			firstCam.rect = new Rect(0f, 0.5f, 0.5f, 0.5f);
			secondCam.rect = new Rect(0.5f, 0.5f, 0.5f, 0.5f);
			thirdCam.rect = new Rect(0f, 0f, 0.5f, 0.5f);
			fourthCam.rect = new Rect(0.5f, 0f, 0.5f, 0.5f);
			break;
		case GameState.GameOver:
			break;
		}
	}

	void OnGUI()
	{ 
		myfontSize = new GUIStyle();
		myfontSize.alignment = TextAnchor.UpperCenter;
		myfontSize.fontSize = 32;
		//GUI.Label( new Rect(Screen.width / 2, 50,Screen.width,Screen.height), ((int) score).ToString(), myfontSize);
		GUI.Label( new Rect(0, 0,Screen.width,Screen.height), ((int) score).ToString(), myfontSize);

		if (gameOver)
		{
			Time.timeScale = 0;
			if(GUI.Button (new Rect (180, 180, 500, 50), "Go to Main Menu"))
			{
				Application.LoadLevel ("MainMenuScene");
			}
		}
//		if(GUI.Button(new Rect (400, 10, 30, 30), pauseButtonTexture))
//		{
//			if(Time.timeScale == 0) Time.timeScale = 1;
//			else Time.timeScale = 0;
//		}

	}

	public static Vector3 getAccelerometerInput()
	{
		return accelerometerInput;
	}
	
	public static Vector2 getDeltaTouchPosition()
	{
		return touchDeltaPosition;
	}

	public static int getTouchCount()
	{
		return touchCount;
	}

	public static bool getUpKey()
	{
		return upKeyPressed;
	}

	public static bool getDownKey()
	{
		return downKeyPressed;
	}

	public static bool getLeftKey()
	{
		return leftKeyPressed;
	}

	public static bool getRightKey()
	{
		return rightKeyPressed;
	}

	public static bool getAKey()
	{
		return aKeyPressed;
	}

	public static bool getDKey()
	{
		return dKeyPressed;
	}
}
