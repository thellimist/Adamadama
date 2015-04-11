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
		MiniGameConfigurations.currentGameState = MiniGameConfigurations.maximumAvailableGameState;
		StartCoroutine(myTextSetter (extractLevelInfo(MiniGameConfigurations.currentGameState.ToString())));		
	}
	IEnumerator myTextSetter(string scoreText) {
		currentLevelText.text = scoreText;
		yield return new WaitForSeconds(1.5f);
		currentLevelText.text = "";
	}

	public string extractLevelInfo(string gameStateString){

		string gameLevel;
		int stateIndex = gameStateString.IndexOf("State");
		if (stateIndex != -1) {
			gameLevel = gameStateString.Substring (0, stateIndex);
			gameLevel = gameLevel.Substring(0,5)+" "+gameLevel.Substring(5);
				} else {

			gameLevel = "LEVEL"+gameStateString.ToCharArray()[5];
				}
		return gameLevel;
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
						if (audio.isPlaying == false) {
								audio.Play ();
						}
				} else {
			audio.Stop();
				}
		score += Time.deltaTime;
		if (gameOver == false) {
				CameraManager ();
				GameStateManager ();
				InputManager ();
		}
		if (MiniGameConfigurations.currentGameState == GameState.Level1
				&& score > MiniGameConfigurations.firstGameFirstLevelSuccesTime) {
				StartCoroutine (myTextSetter ("LEVEL 2"));
				score = 0;
				MiniGameConfigurations.maximumAvailableGameState = GameState.Level2;
				MiniGameConfigurations.currentGameState = GameState.Level2;	
				waitUpdateForGameResetter();

		} else if (MiniGameConfigurations.currentGameState == GameState.Level2
				&& score > MiniGameConfigurations.secondGameSecondLevelSuccesTime) {
				StartCoroutine (myTextSetter ("LEVEL 3"));
				score = 0;
				MiniGameConfigurations.maximumAvailableGameState = GameState.Level3;
				MiniGameConfigurations.currentGameState = GameState.Level3;
			waitUpdateForGameResetter();
		} else if (MiniGameConfigurations.currentGameState == GameState.Level3
				&& score > MiniGameConfigurations.thirdGameThirdLevelSuccesTime) {
				StartCoroutine (myTextSetter ("LEVEL 4"));
				score = 0;
				MiniGameConfigurations.maximumAvailableGameState = GameState.Level4;
				MiniGameConfigurations.currentGameState = GameState.Level4;
				waitUpdateForGameResetter();
		} else if (MiniGameConfigurations.currentGameState == GameState.Level4
				&& score > MiniGameConfigurations.fourthGameFourthLevelSuccesTime) {
				StartCoroutine (myTextSetter ("LEVEL 5"));
				score = 0;
				MiniGameConfigurations.maximumAvailableGameState = GameState.Level5State1;
				MiniGameConfigurations.currentGameState = GameState.Level5State1;
		}
		// 2 Games level...
		else if (MiniGameConfigurations.currentGameState == GameState.Level5State1
				&& score > MiniGameConfigurations.fifthLevelSuccesTime / 2) {
				MiniGameConfigurations.currentGameState = GameState.Level5State2;
		} else if (MiniGameConfigurations.currentGameState == GameState.Level5State2
				&& score > MiniGameConfigurations.fifthLevelSuccesTime) {
				StartCoroutine (myTextSetter ("LEVEL 6"));
				score = 0;
				MiniGameConfigurations.maximumAvailableGameState = GameState.Level6State1;
				MiniGameConfigurations.currentGameState = GameState.Level6State1;
				waitUpdateForGameResetter();
		} else if (MiniGameConfigurations.currentGameState == GameState.Level6State1
				&& score > MiniGameConfigurations.sixthLevelSuccesTime / 2) {
				MiniGameConfigurations.currentGameState = GameState.Level6State2;
		} else if (MiniGameConfigurations.currentGameState == GameState.Level6State2
				&& score > MiniGameConfigurations.sixthLevelSuccesTime) {
				StartCoroutine (myTextSetter ("LEVEL 7"));
				score = 0;
				MiniGameConfigurations.maximumAvailableGameState = GameState.Level7State1;
				MiniGameConfigurations.currentGameState = GameState.Level7State1;
				waitUpdateForGameResetter();
		} else if (MiniGameConfigurations.currentGameState == GameState.Level7State1
				&& score > MiniGameConfigurations.seventhLevelSuccesTime / 2) {
				MiniGameConfigurations.currentGameState = GameState.Level7State2;
		} else if (MiniGameConfigurations.currentGameState == GameState.Level7State2
				&& score > MiniGameConfigurations.seventhLevelSuccesTime) {
				StartCoroutine (myTextSetter ("LEVEL 8"));
				score = 0;
				MiniGameConfigurations.maximumAvailableGameState = GameState.Level8State1;
				MiniGameConfigurations.currentGameState = GameState.Level8State1;
			waitUpdateForGameResetter();
		} else if (MiniGameConfigurations.currentGameState == GameState.Level8State1
				&& score > MiniGameConfigurations.eigthLevelSuccesTime / 2) {
				MiniGameConfigurations.currentGameState = GameState.Level8State2;
		} else if (MiniGameConfigurations.currentGameState == GameState.Level8State2
				&& score > MiniGameConfigurations.eigthLevelSuccesTime) {
				StartCoroutine (myTextSetter ("LEVEL 9"));
				score = 0;
				MiniGameConfigurations.maximumAvailableGameState = GameState.Level9State1;
				MiniGameConfigurations.currentGameState = GameState.Level9State1;
			waitUpdateForGameResetter();
		} else if (MiniGameConfigurations.currentGameState == GameState.Level9State1
				&& score > MiniGameConfigurations.ninethLevelSuccesTime / 2) {
				MiniGameConfigurations.currentGameState = GameState.Level9State2;
		} else if (MiniGameConfigurations.currentGameState == GameState.Level9State2
				&& score > MiniGameConfigurations.ninethLevelSuccesTime) {
				StartCoroutine (myTextSetter ("LEVEL 10"));
				score = 0;
				MiniGameConfigurations.maximumAvailableGameState = GameState.Level10State1;
				MiniGameConfigurations.currentGameState = GameState.Level10State1;
			waitUpdateForGameResetter();
		} else if (MiniGameConfigurations.currentGameState == GameState.Level10State1
				&& score > MiniGameConfigurations.tenthLevelSuccesTime / 2) {
				MiniGameConfigurations.currentGameState = GameState.Level10State2;
		} else if (MiniGameConfigurations.currentGameState == GameState.Level10State2
				&& score > MiniGameConfigurations.tenthLevelSuccesTime) {
				StartCoroutine (myTextSetter ("LEVEL 11"));
				score = 0;
				MiniGameConfigurations.maximumAvailableGameState = GameState.Level11State1;
				MiniGameConfigurations.currentGameState = GameState.Level11State1;
			waitUpdateForGameResetter();
		}
		// 3 Games Levels
		else if (MiniGameConfigurations.currentGameState == GameState.Level11State1
								&& score > MiniGameConfigurations.eleventhLevelSuccesTime / 3) {
								MiniGameConfigurations.currentGameState = GameState.Level11State2;
		} else if (MiniGameConfigurations.currentGameState == GameState.Level11State2
				&& score > MiniGameConfigurations.eleventhLevelSuccesTime * 2 / 3) {
				MiniGameConfigurations.currentGameState = GameState.Level11State3;
		} else if (MiniGameConfigurations.currentGameState == GameState.Level11State3
				&& score > MiniGameConfigurations.eleventhLevelSuccesTime) {
				StartCoroutine (myTextSetter ("LEVEL 12"));
				score = 0;
				MiniGameConfigurations.maximumAvailableGameState = GameState.Level12State1;
				MiniGameConfigurations.currentGameState = GameState.Level12State1;
			waitUpdateForGameResetter();
		} else if (MiniGameConfigurations.currentGameState == GameState.Level12State1
				&& score > MiniGameConfigurations.twelvethLevelSuccesTime / 3) {
				MiniGameConfigurations.currentGameState = GameState.Level12State2;
		} else if (MiniGameConfigurations.currentGameState == GameState.Level12State2
				&& score > MiniGameConfigurations.twelvethLevelSuccesTime * 2 / 3) {
				MiniGameConfigurations.currentGameState = GameState.Level12State3;
		} else if (MiniGameConfigurations.currentGameState == GameState.Level12State3
				&& score > MiniGameConfigurations.twelvethLevelSuccesTime) {
				StartCoroutine (myTextSetter ("LEVEL 13"));
				score = 0;
				MiniGameConfigurations.maximumAvailableGameState = GameState.Level13State1;
				MiniGameConfigurations.currentGameState = GameState.Level13State1;
			waitUpdateForGameResetter();
		} else if (MiniGameConfigurations.currentGameState == GameState.Level13State1
				&& score > MiniGameConfigurations.thirteenthLevelSuccesTime / 3) {
				MiniGameConfigurations.currentGameState = GameState.Level13State2;
		} else if (MiniGameConfigurations.currentGameState == GameState.Level13State2
				&& score > MiniGameConfigurations.thirteenthLevelSuccesTime * 2 / 3) {
				MiniGameConfigurations.currentGameState = GameState.Level13State3;
		} else if (MiniGameConfigurations.currentGameState == GameState.Level13State3
				&& score > MiniGameConfigurations.thirteenthLevelSuccesTime) {
				StartCoroutine (myTextSetter ("LEVEL 14"));
				score = 0;
				MiniGameConfigurations.maximumAvailableGameState = GameState.Level14State1;
				MiniGameConfigurations.currentGameState = GameState.Level14State1;
			waitUpdateForGameResetter();
		} else if (MiniGameConfigurations.currentGameState == GameState.Level14State1
				&& score > MiniGameConfigurations.fourteenthLevelSuccesTime / 3) {
				MiniGameConfigurations.currentGameState = GameState.Level14State2;
		} else if (MiniGameConfigurations.currentGameState == GameState.Level14State2
				&& score > MiniGameConfigurations.fourteenthLevelSuccesTime * 2 / 3) {
				MiniGameConfigurations.currentGameState = GameState.Level14State3;
		} else if (MiniGameConfigurations.currentGameState == GameState.Level14State3
				&& score > MiniGameConfigurations.fourteenthLevelSuccesTime) {
				StartCoroutine (myTextSetter ("LEVEL 15"));
				score = 0;
				MiniGameConfigurations.maximumAvailableGameState = GameState.Level14State1;
				MiniGameConfigurations.currentGameState = GameState.Level15State1;
			waitUpdateForGameResetter();
		} else if (MiniGameConfigurations.currentGameState == GameState.Level15State1
				&& score > MiniGameConfigurations.fifteenthLevelSuccesTime / 4) {
				MiniGameConfigurations.currentGameState = GameState.Level15State2;
		} else if (MiniGameConfigurations.currentGameState == GameState.Level15State2
				&& score > MiniGameConfigurations.fifteenthLevelSuccesTime * 2 / 4) {
				MiniGameConfigurations.currentGameState = GameState.Level15State3;
		} else if (MiniGameConfigurations.currentGameState == GameState.Level15State3
				&& score > MiniGameConfigurations.fifteenthLevelSuccesTime * 3 / 4) {
				MiniGameConfigurations.currentGameState = GameState.Level15State4;
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
		switch (MiniGameConfigurations.currentGameState)
		{ 
		case GameState.MainMenu:
			break;
		case GameState.GameOver:
			break;
		case GameState.Level1:
			GameControllerBalance.StartGame();
			break;
		case GameState.Level2:
			GameControllerMissiles.StartGame();
			break;
		case GameState.Level3:
			GameControllerBasket.StartGame();
			break;
		case GameState.Level4:
			GameControllerRunAndJump.StartGame();
			break;
		case GameState.Level5State1:	
			GameControllerBalance.StartGame();
			break;
		case GameState.Level5State2:
			GameControllerBalance.StartGame();
			GameControllerMissiles.StartGame();
			break;
		case GameState.Level6State1:
			GameControllerBalance.StartGame();
			break;
		case GameState.Level6State2:
			GameControllerBalance.StartGame();
			GameControllerBasket.StartGame();
			break;
		case GameState.Level7State1:
			GameControllerBalance.StartGame();
			break;
		case GameState.Level7State2:
			GameControllerBalance.StartGame();
			GameControllerRunAndJump.StartGame();
			break;
		case GameState.Level8State1:
			GameControllerMissiles.StartGame();
			break;
		case GameState.Level8State2:
			GameControllerMissiles.StartGame();
			GameControllerBasket.StartGame();
			break;
		case GameState.Level9State1:
			GameControllerMissiles.StartGame();
			break;
		case GameState.Level9State2:
			GameControllerMissiles.StartGame();
			GameControllerRunAndJump.StartGame();
			break;
		case GameState.Level10State1:
			GameControllerBasket.StartGame();
			break;
		case GameState.Level10State2:
			GameControllerBasket.StartGame();
			GameControllerRunAndJump.StartGame();
			break;
		case GameState.Level11State1:
			GameControllerBalance.StartGame();
			break;
		case GameState.Level11State2:
			GameControllerBalance.StartGame();
			GameControllerMissiles.StartGame();
			break;
		case GameState.Level11State3:
			GameControllerBalance.StartGame();
			GameControllerMissiles.StartGame();
			GameControllerBasket.StartGame();
			break;
		case GameState.Level12State1:
			GameControllerBalance.StartGame();
			break;
		case GameState.Level12State2:
			GameControllerBalance.StartGame();
			GameControllerMissiles.StartGame();
			break;
		case GameState.Level12State3:
			GameControllerBalance.StartGame();
			GameControllerMissiles.StartGame();
			GameControllerRunAndJump.StartGame();
			break;
		case GameState.Level13State1:
			GameControllerBalance.StartGame();
			break;
		case GameState.Level13State2:
			GameControllerBalance.StartGame();
			GameControllerBasket.StartGame();
			break;
		case GameState.Level13State3:
			GameControllerBalance.StartGame();
			GameControllerBasket.StartGame();
			GameControllerRunAndJump.StartGame();
			break;
		case GameState.Level14State1:
			GameControllerMissiles.StartGame();
			break;
		case GameState.Level14State2:
			GameControllerMissiles.StartGame();
			GameControllerBasket.StartGame();
			break;
		case GameState.Level14State3:
			GameControllerMissiles.StartGame();
			GameControllerBasket.StartGame();
			GameControllerRunAndJump.StartGame();
			break;
		case GameState.Level15State1:
			GameControllerBalance.StartGame();
			break;
		case GameState.Level15State2:
			GameControllerBalance.StartGame();
			GameControllerMissiles.StartGame();
			break;
		case GameState.Level15State3:
			GameControllerBalance.StartGame();
			GameControllerMissiles.StartGame();
			GameControllerBasket.StartGame();
			break;
		case GameState.Level15State4:
			GameControllerBalance.StartGame();
			GameControllerMissiles.StartGame();
			GameControllerBasket.StartGame();
			GameControllerRunAndJump.StartGame();
			break;
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
		case GameState.Level1:
			firstFullCam.rect = new Rect(0f, 0f, 1f, 1f);
			firstHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
			secondFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			secondHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
			thirdFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			thirdHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
			fourthFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			fourthHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
			break;
		case GameState.Level2:
			firstFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			firstHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
			secondFullCam.rect = new Rect(0f, 0f, 1f, 1f);
			secondHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
			thirdFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			thirdHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
			fourthFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			fourthHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
			break;
		case GameState.Level3:
			firstFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			firstHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
			secondFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			secondHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
			thirdFullCam.rect = new Rect(0f, 0f, 1f, 1f);
			thirdHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
			fourthFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			fourthHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
			break;
		case GameState.Level4:
			firstFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			firstHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
			secondFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			secondHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
			thirdFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			thirdHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
			fourthFullCam.rect = new Rect(0f, 0f, 1f, 1f);
			fourthHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
			break;
		case GameState.Level5State1:
			firstFullCam.rect = new Rect(0f, 0f, 1f, 1f);
			firstHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
			secondFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			secondHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
			thirdFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			thirdHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
			fourthFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			fourthHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
			break;
		case GameState.Level5State2:
			firstFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			firstHalfCam.rect = new Rect(0f, 0f, 0.5f, 1f);
			secondFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			secondHalfCam.rect = new Rect(0.5f, 0f, 0.5f, 1f);
			thirdFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			thirdHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
			fourthFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			fourthHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
			break;
		case GameState.Level6State1:
			firstFullCam.rect = new Rect(0f, 0f, 1f, 1f);
			firstHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
			secondFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			secondHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
			thirdFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			thirdHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
			fourthFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			fourthHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
			break;
		case GameState.Level6State2:
			firstFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			firstHalfCam.rect = new Rect(0f, 0f, 0.5f, 1f);
			secondFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			secondHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
			thirdFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			thirdHalfCam.rect = new Rect(0.5f, 0f, 0.5f, 1f);
			fourthFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			fourthHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
			break;
		case GameState.Level7State1:
			firstFullCam.rect = new Rect(0f, 0f, 1f, 1f);
			firstHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
			secondFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			secondHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
			thirdFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			thirdHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
			fourthFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			fourthHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
			break;
		case GameState.Level7State2:
			firstFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			firstHalfCam.rect = new Rect(0f, 0f, 0.5f, 1f);
			secondFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			secondHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
			thirdFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			thirdHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
			fourthFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			fourthHalfCam.rect = new Rect(0.5f, 0f, 0.5f, 1f);
			break;
		case GameState.Level8State1:
			firstFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			firstHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
			secondFullCam.rect = new Rect(0f, 0f, 1f, 1f);
			secondHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
			thirdFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			thirdHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
			fourthFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			fourthHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
			break;
		case GameState.Level8State2:
			firstFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			firstHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
			secondFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			secondHalfCam.rect = new Rect(0f, 0f, 0.5f, 1f);
			thirdFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			thirdHalfCam.rect = new Rect(0.5f, 0f, 0.5f, 1f);
			fourthFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			fourthHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
			break;
		case GameState.Level9State1:
			firstFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			firstHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
			secondFullCam.rect = new Rect(0f, 0f, 1f, 1f);
			secondHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
			thirdFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			thirdHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
			fourthFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			fourthHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
			break;
		case GameState.Level9State2:
			firstFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			firstHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
			secondFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			secondHalfCam.rect = new Rect(0f, 0f, 0.5f, 1f);
			thirdFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			thirdHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
			fourthFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			fourthHalfCam.rect = new Rect(0.5f, 0f, 0.5f, 1f);
			break;
		case GameState.Level10State1:
			firstFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			firstHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
			secondFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			secondHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
			thirdFullCam.rect = new Rect(0f, 0f, 1f, 1f);
			thirdHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
			fourthFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			fourthHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
			break;
		case GameState.Level10State2:
			firstFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			firstHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
			secondFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			secondHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
			thirdFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			thirdHalfCam.rect = new Rect(0f, 0f, 0.5f, 1f);
			fourthFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			fourthHalfCam.rect = new Rect(0.5f, 0f, 0.5f, 1f);
			break;
		case GameState.Level11State1:
			firstFullCam.rect = new Rect(0f, 0f, 1f, 1f);
			firstHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
			secondFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			secondHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
			thirdFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			thirdHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
			fourthFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			fourthHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
			break;
		case GameState.Level11State2:
			firstFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			firstHalfCam.rect = new Rect(0f, 0f, 0.5f, 1f);
			secondFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			secondHalfCam.rect = new Rect(0.5f, 0f, 0.5f, 1f);
			thirdFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			thirdHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
			fourthFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			fourthHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
			break;
		case GameState.Level11State3:
			firstFullCam.rect = new Rect(0f, 0.5f, 0.5f, 0.5f);
			firstHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
			secondFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			secondHalfCam.rect = new Rect(0.5f, 0f, 0.5f, 1f);
			thirdFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			thirdHalfCam.rect = new Rect(0f, 0f, 0.5f, 0.5f);
			fourthFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			fourthHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
			break;
		case GameState.Level12State1:
			firstFullCam.rect = new Rect(0f, 0f, 1f, 1f);
			firstHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
			secondFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			secondHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
			thirdFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			thirdHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
			fourthFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			fourthHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
			break;
		case GameState.Level12State2:
			firstFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			firstHalfCam.rect = new Rect(0f, 0f, 0.5f, 1f);
			secondHalfCam.rect = new Rect(0.5f, 0f, 0.5f, 1f);
			thirdFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			thirdHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
			fourthFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			fourthHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
			break;
		case GameState.Level12State3:
			firstFullCam.rect = new Rect(0f, 0.5f, 0.5f, 0.5f);
			firstHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
			secondFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			secondHalfCam.rect = new Rect(0.5f, 0f, 0.5f, 1f);
			thirdFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			thirdHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
			fourthFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			fourthHalfCam.rect = new Rect(0f, 0f, 0.5f, 0.5f);
			break;
		case GameState.Level13State1:
			firstFullCam.rect = new Rect(0f, 0f, 1f, 1f);
			firstHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
			secondFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			secondHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
			thirdFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			thirdHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
			fourthFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			fourthHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
			break;
		case GameState.Level13State2:
			firstFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			firstHalfCam.rect = new Rect(0f, 0f, 0.5f, 1f);
			secondFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			secondHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
			thirdFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			thirdHalfCam.rect = new Rect(0.5f, 0f, 0.5f, 1f);
			fourthFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			fourthHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
			break;
		case GameState.Level13State3:
			firstFullCam.rect = new Rect(0f, 0.5f, 0.5f, 0.5f);
			firstHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
			secondFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			secondHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
			thirdFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			thirdHalfCam.rect = new Rect(0.5f, 0f, 0.5f, 1f);
			fourthFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			fourthHalfCam.rect = new Rect(0f, 0f, 0.5f, 0.5f);
			break;
		case GameState.Level14State1:
			firstFullCam.rect = new Rect(0f, 0f, 0f, 0f);			
			firstHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
			secondFullCam.rect = new Rect(0f, 0f, 1f, 1f);
			secondHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
			thirdFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			thirdHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
			fourthFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			fourthHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
			break;	
		case GameState.Level14State2:
			firstFullCam.rect = new Rect(0f, 0f, 0f, 0f);			
			firstHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
			secondFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			secondHalfCam.rect = new Rect(0f, 0f, 0.5f, 1f);
			thirdFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			thirdHalfCam.rect = new Rect(0.5f, 0f, 0.5f, 1f);
			fourthFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			fourthHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
			break;
		case GameState.Level14State3:
			firstFullCam.rect = new Rect(0f, 0f, 0f, 0f);			
			firstHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
			secondFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			secondHalfCam.rect = new Rect(0f, 0.5f, 0.5f, 0.5f);
			thirdFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			thirdHalfCam.rect = new Rect(0.5f, 0f, 0.5f, 1f);
			fourthFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			fourthHalfCam.rect = new Rect(0f, 0f, 0.5f, 0.5f);
			break;
		case GameState.Level15State1:
			firstFullCam.rect = new Rect(0f, 0f, 1f, 1f);
			firstHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
			secondFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			secondHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
			thirdFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			thirdHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
			fourthFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			fourthHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
			break;
		case GameState.Level15State2:
			firstFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			firstHalfCam.rect = new Rect(0f, 0f, 0.5f, 1f);
			secondFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			secondHalfCam.rect = new Rect(0.5f, 0f, 0.5f, 1f);
			thirdFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			thirdHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
			fourthFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			fourthHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
			break;
		case GameState.Level15State3:
			firstFullCam.rect = new Rect(0f, 0.5f, 0.5f, 0.5f);
			firstHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
			secondFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			secondHalfCam.rect = new Rect(0.5f, 0.5f, 0.5f, 1f);
			thirdFullCam.rect = new Rect(0f, 0f, 0.5f, 0.5f);
			thirdHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
			fourthFullCam.rect = new Rect(0f, 0f, 0f, 0f);
			fourthHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
			break;
		case GameState.Level15State4:
			firstFullCam.rect = new Rect(0f, 0.5f, 0.5f, 0.5f);
			firstHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
			secondFullCam.rect = new Rect(0.5f, 0.5f, 0.5f, 0.5f);
			secondHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
			thirdFullCam.rect = new Rect(0f, 0f, 0.5f, 0.5f);
			thirdHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
			fourthFullCam.rect = new Rect(0.5f, 0f, 0.5f, 0.5f);
			fourthHalfCam.rect = new Rect(0f, 0f, 0f, 0f);
			break;
		
		case GameState.GameOver:
			break;
		}
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
