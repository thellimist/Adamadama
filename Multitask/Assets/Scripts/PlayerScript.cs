using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
	
	public int theScore = 0;
	Rect guiScreenRect;
	GUIStyle style;
	void Start(){

		guiScreenRect = new Rect(0.0f,0.0f,0.0f,0.0f);
		style = new GUIStyle ();
		
		style.fontSize= 18;
		
		
		guiScreenRect.x = 4;
		guiScreenRect.width = 200;
		guiScreenRect.y = 4;
		guiScreenRect.height = 20;



	}

	void Update () {

		if (GameControllerBasket.isActive) {
						//These two lines are all there is to the actual movement..

						if (MiniGameController.getLeftKey()) {
							float speed = -0.7f;
							transform.Translate (speed, 0, 0);
						}
						if (MiniGameController.getRightKey()) {
							float speed = 0.7f;
							transform.Translate (speed, 0, 0);
						}
						if (MiniGameController.getTouchCount() > 0) {
							float speed = 1.5f;
							transform.Translate (MiniGameController.getDeltaTouchPosition ().x * speed, 0, 0);
						}

						// Move object across XY plane

						if (transform.position.x <= -85.5f) {
								transform.position = new Vector3 (-85.5f, transform.position.y, transform.position.z);
						}

						if (transform.position.x >= 85.5f) {
								transform.position = new Vector3 (85.5f, transform.position.y, transform.position.z);
						}
				}
	}

}
