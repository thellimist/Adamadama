using UnityEngine;
using System.Collections;

public class Balance_BarScript : MonoBehaviour {

	public static float angle;
	public static float xPos;
	public static float yPos;
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
		if (Input.GetKey ("left"))
		{
			angle += 0.1f;
			transform.RotateAround(transform.position, Vector3.forward, angle);
		}
		if (Input.GetKey ("right"))
		{
			angle -= 0.1f;
			transform.RotateAround(transform.position, Vector3.back, angle);	
		}

		if (GameControllerBalance.isActive) {

						// Stable the bar
						transform.position = new Vector3 (xPos, yPos, 0);
						


			
						// Rotate bar according to accelerometer input
						float xAxisMovement = MiniGameController.getAccelerometerInput ().x;
						angle = -xAxisMovement * 20;
						Quaternion qq = Quaternion.AngleAxis (angle, Vector3.forward);
						transform.rotation = qq;
				} else {
					
				}

	
	}

	public static void gameResetter(){

		angle = 0;
		xPos = 0;
		yPos = 0;
		//transform.position = new Vector3 (xPos, yPos, 0);
		//Quaternion qq = Quaternion.AngleAxis (angle, Vector3.forward);
		//transform.rotation = qq;


	}



}
