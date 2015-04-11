using UnityEngine;
using System.Collections;

public class BasketCollider : MonoBehaviour {

	PlayerScript myPlayerScript;
	
	//Automatically run when a scene starts

	void Update(){

		transform.position = myPlayerScript.transform.position;
	}
	void Start()
	{

		GameObject bucket = GameObject.Find("bucket");

		myPlayerScript = bucket.GetComponent<PlayerScript>();

	}

	void OnCollisionEnter2D (Collision2D theCollision)
	{
		//In this game we don't need to check *what* we hit; it must be the eggs
		GameObject collisionGO = theCollision.gameObject;
		Destroy(collisionGO);
	}
}
