using UnityEngine;
using System.Collections;

public class CrateDestroyer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D (Collision2D theCollision)
	{
		Destroy (theCollision.gameObject);
	}
}
