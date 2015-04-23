using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameSelectionControllerScript : MonoBehaviour {

	public bool isGame1Selected;
	public bool isGame2Selected;
	public bool isGame3Selected;
	public bool isGame4Selected;
	public bool isGame5Selected;
	public bool isGame6Selected;

	public Text myErrorTextField;


	// Use this for initialization
	void Start () {
		  isGame1Selected=false;
		  isGame2Selected=false;
		  isGame3Selected=false;
		  isGame4Selected=false;
		  isGame5Selected=false;
		  isGame6Selected=false;
		  myErrorTextField.gameObject.SetActive(false);
	}

	public void changeGameSelectionState(string gameNumber){

		if(gameNumber == "1"){
			isGame1Selected = !isGame1Selected;
		}
		else if(gameNumber == "2"){
			isGame2Selected = !isGame2Selected;
		}
		else if(gameNumber == "3"){
			isGame3Selected = !isGame3Selected;
		}
		else if(gameNumber == "4"){
			isGame4Selected = !isGame4Selected;
		}
		else if(gameNumber == "5"){
			isGame5Selected = !isGame5Selected;
		}
		else if(gameNumber == "6"){
			isGame6Selected = !isGame6Selected;
		}

	
	}

	IEnumerator Wait(float duration)
	{
		yield return new WaitForSeconds(duration);
		myErrorTextField.gameObject.SetActive(false);
	}

	public void startGameWithSelectedGames(){

		ArrayList selectedOne = new ArrayList();
		if (isGame1Selected) {
			selectedOne.Add("Game1");		
		}
		if (isGame2Selected) {
			selectedOne.Add("Game2");		
		}
		if (isGame3Selected) {
			selectedOne.Add("Game3");		
		}
		if (isGame4Selected) {
			selectedOne.Add("Game4");		
		}
		if (isGame5Selected) {
			selectedOne.Add("Game5");		
		}
		if (isGame6Selected) {
			selectedOne.Add("Game6");		
		}

		if (selectedOne.Count != 2 && selectedOne.Count != 4) {
			myErrorTextField.gameObject.SetActive(true);
			StartCoroutine(Wait(1.5f));		
			return;
		}
		if (selectedOne.Count == 2) {
			MiniGameConfigurations.currentGameType = GameType.selectedGameCount2;
		}
		else if (selectedOne.Count == 4) {
			MiniGameConfigurations.currentGameType = GameType.selectedGameCount4;
		}
		for (int i = 0; i<selectedOne.Count; i++) {
				if(i==0){
					MiniGameConfigurations.selected1GameIs = convertFromStringToGameEnum((string)selectedOne[i]);
				}
				if(i==1){
					MiniGameConfigurations.selected2GameIs = convertFromStringToGameEnum((string)selectedOne[i]);
				}
				if(i==2){
					MiniGameConfigurations.selected3GameIs = convertFromStringToGameEnum((string)selectedOne[i]);
				}
				if(i==3){
					MiniGameConfigurations.selected4GameIs = convertFromStringToGameEnum((string)selectedOne[i]);
				}
		}
		MiniGameConfigurations.currentGameState = GameState.Selected1GameIsActive;
		Application.LoadLevel ("GameScene");

	}

	public Game convertFromStringToGameEnum(string nameAsString){

		if (nameAsString == "Game1") {
			return Game.Game1;
		}
		else if (nameAsString == "Game2") {
			return Game.Game2;
		}
		else if (nameAsString == "Game3") {
			return Game.Game3;
		}
		else if (nameAsString == "Game4") {
			return Game.Game4;
		}
		else if (nameAsString == "Game5") {
			return Game.Game5;
		}
		else if (nameAsString == "Game6") {
			return Game.Game6;
		}
		return Game.NotAGame;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
