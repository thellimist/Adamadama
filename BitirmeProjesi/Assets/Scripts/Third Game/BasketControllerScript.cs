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
								speed = 0.2f;
								// Move object across XY plane
								Touch[] myTouches = Input.touches;
					
								float xMove = 0;
								for (int i = 0; i<myTouches.Length; i++) {
										if (MiniGameController.miniGameInputControl(myTouches[i],Game.Game3,MiniGameConfigurations.currentGameType,MiniGameConfigurations.currentGameState))
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
