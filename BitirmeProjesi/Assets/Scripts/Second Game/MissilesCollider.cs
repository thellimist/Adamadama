using UnityEngine;
using System.Collections;

public class MissilesCollider : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (GameControllerMissiles.isActive) {
						if (gameObject.transform.position.x < 30) {
								Destroy (gameObject);
						}
				} else {
						rigidbody2D.velocity = Vector2.zero;
				}
	}
}
