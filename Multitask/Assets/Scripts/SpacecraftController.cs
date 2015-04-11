using UnityEngine;
using System.Collections;

public class SpacecraftController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (!MiniGameController.gameOver && GameControllerMissiles.isActive) {
						if (MiniGameController.getUpKey()) {
								Vector3 position = this.transform.position;
								if (position.y < 4.5)
										position.y += 0.1f;
								this.transform.position = position; 
						}
						if (MiniGameController.getDownKey()) {
								Vector3 position = this.transform.position;
								if (position.y > -4.5)
										position.y -= 0.1f;
								this.transform.position = position;
						}
						if (MiniGameController.getTouchCount() > 0) {
								Vector3 position = this.transform.position;
								Vector2 touchDeltaPosition = MiniGameController.getDeltaTouchPosition();
								position.y += touchDeltaPosition.y * 0.02f;
								this.transform.position = position;
						}
				}
	}
	void OnCollisionEnter2D (Collision2D col)
	{
		Destroy (col.gameObject);
		Time.timeScale = 0;
		MiniGameController.GameOver(); 
	}
}
