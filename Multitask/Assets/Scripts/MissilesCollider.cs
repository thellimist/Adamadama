using UnityEngine;
using System.Collections;

public class MissilesCollider : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (GameControllerMissiles.isActive) {
						Vector2 vec = new Vector2 (-1, 0);
						GetComponent<Rigidbody2D>().AddForce (vec);
						if (gameObject.transform.position.x < 30) {
								Destroy (gameObject);
						}
				}
	}
}
