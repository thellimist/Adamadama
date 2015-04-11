using UnityEngine;
using System.Collections;

public class Balance_BarScript : MonoBehaviour {

	public float angle;
	float xPos;
	float yPos;
	// Use this for initialization
	void Start () 
	{
		angle = 0;
		xPos = 0;
		yPos = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!MiniGameController.gameOver && GameControllerBalance.isActive) {
			// Stable the bar
			transform.position = new Vector3(xPos, yPos, 0);
			/*
			if (Input.GetKey ("left"))
			{
				angle += 0.1f;
				//transform.RotateAround(Vector3.zero, Vector3.forward, angle);
			}
			if (Input.GetKey ("right"))
			{
				angle -= 0.1f;
				//transform.RotateAround(Vector3.zero, Vector3.forward, angle);	
			}
			*/
			float speed = 1f;

			if (MiniGameController.getDKey()) {
				angle += -speed;
				Quaternion qq = Quaternion.AngleAxis (angle, Vector3.forward);
				transform.rotation = qq;
			}
			if (MiniGameController.getAKey()) {
				angle += speed;
				Quaternion qq = Quaternion.AngleAxis (angle, Vector3.forward);
				transform.rotation = qq;
				Debug.Log(angle);
			}

			// Rotate bar according to accelerometer input
			if (MiniGameController.getAccelerometerInput () != Vector3.zero) {
				float xAxisMovement = MiniGameController.getAccelerometerInput ().x;
				angle = -xAxisMovement * 20;
				Quaternion qq = Quaternion.AngleAxis (angle, Vector3.forward);
				transform.rotation = qq;
			}

		}

	
	}



}
