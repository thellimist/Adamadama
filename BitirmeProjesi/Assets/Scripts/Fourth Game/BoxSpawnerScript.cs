using UnityEngine;
using System.Collections;

public class BoxSpawnerScript : MonoBehaviour {
	[SerializeField] GameObject Crate;
	float timer = 0f;
	public bool endGame = false;
	// Use this for initialization

	void gameResetter(){
		GameObject[] crateClones =GameObject.FindGameObjectsWithTag ("Crate");
		for (int i = 0; i<crateClones.Length; i++) {
			
			Destroy(crateClones[i]);
		}
	}
	void Start () {
	}

	
	// Update is called once per frame
	void Update ()
	{
		if (!GameControllerRunAndJump.isActive)
		{
			gameResetter();
			/*
			for (int i = 0; i < crates.Count; i++)
			{
				((GameObject) crates[i]).rigidbody2D.velocity = (new Vector3(0.0f, 0.0f, 0.0f));
			}
			*/
		}
		else if (!endGame && GameControllerRunAndJump.isActive)
		{
			timer += Time.deltaTime;

			if(timer > 2){
				Spawner();
				timer = 0;
			}
			GameObject[] crateClones =GameObject.FindGameObjectsWithTag ("Crate");
				for (int i = 0; i<crateClones.Length; i++) {
					
					crateClones[i].rigidbody2D.velocity = (new Vector3(-7.0f, 0.0f, 0.0f));
            	}
		}
	}
	
	void Spawner()
	{
		if (!endGame && GameControllerRunAndJump.isActive)
		{
			Vector2 spawnPoint = new Vector2 (transform.position.x, transform.position.y);
			GameObject obje;
			obje = (GameObject) Instantiate (Crate, spawnPoint, Quaternion.identity);
		}
	}
}