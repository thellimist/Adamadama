using UnityEngine;
using System.Collections;

public class Balance_BallScript : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		transform.GetComponent<Rigidbody2D>().AddForce( new Vector2(20,0));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
