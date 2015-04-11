using UnityEngine;
using System.Collections;

public class Zaman : MonoBehaviour {

	float score = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		GameObject spawner = GameObject.Find("BoxSpawner");
		// If the player should jump...
		if (GameControllerRunAndJump.isActive) {
						score += Time.deltaTime;
				}
	}
}
