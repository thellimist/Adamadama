using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MiniGameButtonManagerScript : MonoBehaviour {

	public GameObject gameOverButton;
	public GameObject retryButton; 
	public GameObject cloudImage; 
	public Text scoreText; 

	public Text mainScore;

	void Start(){
		mainScore.gameObject.SetActive (true);
		//mainScore.text = "0";
		gameOverButton.SetActive(false);
		retryButton.SetActive (false);
		cloudImage.SetActive (false);
		scoreText.gameObject.SetActive (false);
	}

	void Update(){

		mainScore.text = (Mathf.Round(MiniGameController.score * 10f) / 10f).ToString();

		if (MiniGameController.gameOver) {
			mainScore.gameObject.SetActive (false);
			cloudImage.SetActive (true);
			gameOverButton.SetActive(true);
			retryButton.SetActive(true);
			scoreText.gameObject.SetActive (true);
			scoreText.text = "Score : " + ((Mathf.Round(MiniGameController.score * 10f) / 10f).ToString());
		}
	}

	public void retryFunction() {
		GameControllerBalance.PauseGame();
		GameControllerMissiles.PauseGame();
		GameControllerBasket.PauseGame();
		GameControllerRunAndJump.PauseGame();
		MiniGameConfigurations.currentGameState = GameState.Selected1GameIsActive;
		Application.LoadLevel ("GameScene");
	}

	public void toMenuFunction() {
		GameControllerBalance.PauseGame();
		GameControllerMissiles.PauseGame();
		GameControllerBasket.PauseGame();
		GameControllerRunAndJump.PauseGame();
		MiniGameConfigurations.currentGameState = GameState.Selected1GameIsActive;
		Application.LoadLevel ("MainMenuScene");
	}
}

