using UnityEngine;
using System.Collections;

public class BasketControllerScript : MonoBehaviour {

	Vector3 initialPosition ;

	void gameResetter(){
		transform.position = initialPosition;
		GameObject[] basketballClones =GameObject.FindGameObjectsWithTag ("Basketball");
		for (int i = 0; i<basketballClones.Length; i++) {

			Destroy(basketballClones[i]);
		}
	}

	void Start(){
		initialPosition = transform.position;
	}

	void Update () {
		
		if (Input.GetKey ("escape")) {
			Application.Quit();
		}
		if (GameControllerBasket.isActive) {
						//These two lines are all there is to the actual movement..
						float speed = 20f;
						if (Input.GetKey (KeyCode.RightArrow)) {
								transform.position += new Vector3 (speed * Time.deltaTime, 0.0f, 0.0f);
						}
						if (Input.GetKey (KeyCode.LeftArrow)) {
								transform.position -= new Vector3 (speed * Time.deltaTime, 0.0f, 0.0f);
						} else {
								speed = 384.0f / Screen.width;
								// Move object across XY plane
								Touch[] myTouches = Input.touches;
					
								float xMove = 0;
								for (int i = 0; i<myTouches.Length; i++) {
										if
										(
										// 3-4 First Step
										(MiniGameConfigurations.selected1GameIs == Game.Game3 && MiniGameConfigurations.currentGameState == GameState.Selected1GameIsActive)  
										||
										// 3-4 Secod Step
										( (MiniGameConfigurations.selected1GameIs == Game.Game3 && MiniGameConfigurations.currentGameState == GameState.Selected2GameIsActive) &&  myTouches[i].position.x <= Screen.width / 2 )
										||
										// 1-3-4,2-3-4 Second Step
										( (MiniGameConfigurations.selected2GameIs == Game.Game3 && MiniGameConfigurations.currentGameState == GameState.Selected2GameIsActive) &&  myTouches[i].position.x >= Screen.width / 2 )
										||
										// 1-3-4,2-3-4 Third Step
										( (MiniGameConfigurations.selected2GameIs == Game.Game3 && MiniGameConfigurations.currentGameState == GameState.Selected2GameIsActive) &&  myTouches[i].position.x >= Screen.width / 2 )
										||
										// 1-2-3 Third Step
										( (MiniGameConfigurations.selected3GameIs == Game.Game3 && MiniGameConfigurations.currentGameState == GameState.Selected3GameIsActive) &&  myTouches[i].position.x <= Screen.width / 2 && myTouches[i].position.y <= Screen.height / 2 )
										||
										// 1-2-3-4 Third Step
										( (MiniGameConfigurations.selected3GameIs == Game.Game3 && MiniGameConfigurations.currentGameState == GameState.Selected4GameIsActive) &&  myTouches[i].position.x <= Screen.width / 2 && myTouches[i].position.y <= Screen.height / 2 )
										)
										{
												xMove = myTouches [i].deltaPosition.x * speed;
												break;
										}
								}

								transform.Translate (xMove, 0, 0);

						
						}
						if (transform.position.x <= -7.2f) {
								transform.position = new Vector3 (-7.2f, transform.position.y, transform.position.z);
						}
			
						if (transform.position.x >= 7.2f) {
								transform.position = new Vector3 (7.2f, transform.position.y, transform.position.z);
						}

				} else {
					gameResetter();
				}
	}

}
