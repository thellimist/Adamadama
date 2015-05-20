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
								if (position.y < -10.9)
										position.y += 0.1f;
								this.transform.position = position; 
						}
						if (Input.GetKey (KeyCode.DownArrow)) {
								Vector3 position = this.transform.position;
								if (position.y > -15.2)
										position.y -= 0.1f;
								this.transform.position = position;
						}

						float speed = 0.05f;
						Touch[] myTouches = Input.touches;
						
						for (int i = 0; i<myTouches.Length; i++) {
							if (MiniGameController.miniGameInputControl(myTouches[i],Game.Game2,MiniGameConfigurations.currentGameType,MiniGameConfigurations.currentGameState))
							{
										Vector3 position = this.transform.position;
										Vector2 touchDeltaPosition = myTouches [i].deltaPosition;
										position.y += touchDeltaPosition.y * speed;
										if (position.y <= -15.2f) {
											position.y = -15.2f;
										}
										if (position.y >= -10.9f) {
											position.y = -10.9f;
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
