using UnityEngine;
using System.Collections;

public class MultiPlayerBalance_BallScript : MonoBehaviour {

	// Use this for initialization
	public static Vector3  initialPosition;
	void Start () 
	{
		transform.GetComponent<Rigidbody2D>().AddForce( new Vector2(-340,0));
	}
	
	// Update is called once per frame
	void Update () {

	}
}
