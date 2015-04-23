using UnityEngine;
using System.Collections;

public class SpacecraftController : MonoBehaviour {

	// Use this for initialization

	Vector3 initialPosition;
	void gameResetter(){
		transform.position = initialPosition;
		GameObject[] missileClones =GameObject.FindGameObjectsWithTag ("Missile");
		for (int i = 0; i<missileClones.Length; i++) {
			Destroy(missileClones[i]);
		}
	}

	void Start () {
		initialPosition=transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (!MiniGameController.gameOver && GameControllerMissiles.isActive) {
						
						if (Input.GetKey (KeyCode.UpArrow)) {
								Vector3 position = this.transform.position;
								if (position.y < 2.2)
										position.y += 0.1f;
								this.transform.position = position; 
						}
						if (Input.GetKey (KeyCode.DownArrow)) {
								Vector3 position = this.transform.position;
								if (position.y > -2.2)
										position.y -= 0.1f;
								this.transform.position = position;
						}

						float speed = 54f / Screen.height;
						Touch[] myTouches = Input.touches;
						
						for (int i = 0; i<myTouches.Length; i++) {
								if (
								// 2-3,2-4,2-3-4 first step
								(MiniGameConfigurations.selected1GameIs == Game.Game2 && MiniGameConfigurations.currentGameState == GameState.Selected1GameIsActive) 
								||
								// 2-3,2-4,2-3-4 second step
								( (MiniGameConfigurations.selected1GameIs == Game.Game2 && MiniGameConfigurations.currentGameState == GameState.Selected2GameIsActive) &&  myTouches[i].position.x <= Screen.width / 2 )
								||
								// 2-3-4 third step
								((MiniGameConfigurations.selected1GameIs == Game.Game2 && MiniGameConfigurations.currentGameState == GameState.Selected3GameIsActive) &&  myTouches[i].position.x <= Screen.width / 2 &&  myTouches[i].position.y >= Screen.height / 2 )
								||
								// 1-2,1-2-3,1-2-4,1-2-3-4 second step
								((MiniGameConfigurations.selected2GameIs == Game.Game2 && MiniGameConfigurations.currentGameState == GameState.Selected2GameIsActive)  &&  myTouches[i].position.x >= Screen.width / 2)
								||
								// 1-2-3,1-2-4,1-2-3-4 third step
								((MiniGameConfigurations.selected2GameIs == Game.Game2 && MiniGameConfigurations.currentGameState == GameState.Selected3GameIsActive)  &&  myTouches[i].position.x >= Screen.width / 2)
								// 1-2-3-4 last step
								||			
								((MiniGameConfigurations.selected2GameIs == Game.Game2 && MiniGameConfigurations.currentGameState == GameState.Selected4GameIsActive)  &&  myTouches[i].position.x >= Screen.width / 2 &&  myTouches[i].position.y >= Screen.height / 2)
								)
								{
										Vector3 position = this.transform.position;
										Vector2 touchDeltaPosition = myTouches [i].deltaPosition;
										position.y += touchDeltaPosition.y * speed;
										if (position.y <= -2.2f) {
											position.y = -2.2f;
										}
										if (position.y >= 2.2f) {
												position.y = 2.2f;
										}
										this.transform.position = position;
										break;
								}
						}
				} else {
					gameResetter();
				}
	}

	void OnCollisionEnter2D (Collision2D col)
	{
			Destroy (col.gameObject);
			MiniGameController.GameOver();
	}
}
