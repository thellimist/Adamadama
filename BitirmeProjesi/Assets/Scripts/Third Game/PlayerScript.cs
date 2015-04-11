using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

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
							(MiniGameConfigurations.currentGameState == GameState.Level3) 
							||
							(MiniGameConfigurations.currentGameState == GameState.Level10State1) 
							||
							(MiniGameConfigurations.currentGameState == GameState.Level6State2 &&  myTouches[i].position.x >= Screen.width / 2)
							||
							( MiniGameConfigurations.currentGameState == GameState.Level8State2 &&  myTouches[i].position.x >= Screen.width / 2 )
							||
							( MiniGameConfigurations.currentGameState == GameState.Level10State2 &&  myTouches[i].position.x <= Screen.width / 2 )
							||
							( MiniGameConfigurations.currentGameState == GameState.Level11State3 &&  myTouches[i].position.x <= Screen.width / 2 &&  myTouches[i].position.y <= Screen.height / 2)
							||
							( MiniGameConfigurations.currentGameState == GameState.Level13State2 &&  myTouches[i].position.x >= Screen.width / 2 )
							||
							( MiniGameConfigurations.currentGameState == GameState.Level13State3 &&  myTouches[i].position.x >= Screen.width / 2 )
							||
							( MiniGameConfigurations.currentGameState == GameState.Level14State2 &&  myTouches[i].position.x >= Screen.width / 2 )
							||
							( MiniGameConfigurations.currentGameState == GameState.Level14State3 &&  myTouches[i].position.x >= Screen.width / 2 )
							||
							( MiniGameConfigurations.currentGameState == GameState.Level15State3 &&  myTouches[i].position.x <= Screen.width / 2 &&  myTouches[i].position.y <= Screen.height / 2)
							||
							( MiniGameConfigurations.currentGameState == GameState.Level15State4 &&  myTouches[i].position.x <= Screen.width / 2 &&  myTouches[i].position.y <= Screen.height / 2)

							
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
