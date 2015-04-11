using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BallSpawnerScript : MonoBehaviour {
	
	public GameObject ball;
	
	private float nextBallTime = 0.0f;
	private float spawnRate = 1.5f;

	Mesh mesh;

	void Start() {
		mesh = GetComponent<MeshFilter>().mesh;
	}

	void Update () {

		if (GameControllerBasket.isActive) {
						if (nextBallTime < Time.time) {
								SpawnBall ();
								nextBallTime = Time.time + spawnRate;
	
								//Speed up the spawnrate for the next egg
								spawnRate *= 0.98f;
								spawnRate = Mathf.Clamp (spawnRate, 1.2f, 99f);
						}
		} 
	}
	
	void SpawnBall()
	{
		float length = mesh.bounds.size.x * transform.localScale.x;


		float xPos = Random.Range(transform.position.x -length/2, transform.position.x +length/2);
		Vector3 spawnPos = new Vector3(xPos,transform.position.y,-1);

		//ball = Instantiate(Resources.Load("basketball")) as GameObject;
		//Vector3 objectPos = mycam.ScreenToWorldPoint(spawnPos);
		ball.transform.position = spawnPos;

		Instantiate(ball, spawnPos, Quaternion.identity);
	}
}
