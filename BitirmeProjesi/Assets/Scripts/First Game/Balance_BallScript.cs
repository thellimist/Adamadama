using UnityEngine;
using System.Collections;

public class Balance_BallScript : MonoBehaviour {

	// Use this for initialization
	public static Vector3  initialPosition;
	public static void gameResetter(){
		initialPosition = new Vector3(0.32f,0.85f,0f);
		GameObject.Find ("Ball").transform.position = initialPosition;
		Quaternion qq = Quaternion.AngleAxis (0, Vector3.forward);
		GameObject.Find ("Ball").transform.rotation = qq;
	}
	void Start () 
	{
		initialPosition = new Vector3 (0.32f, 0.85f, 0f);
		transform.position = initialPosition;
		transform.GetComponent<Rigidbody2D>().AddForce( new Vector2(-3000,0));
	}
	
	// Update is called once per frame
	void Update () {
		if (!GameControllerBalance.isActive) {
						gameResetter ();
						///transform.position = initialPosition;
				} else {

				}
	}
}
