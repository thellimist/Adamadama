using UnityEngine;
using System.Collections;

public class BoxSpawnerScript : MonoBehaviour {
	[SerializeField] GameObject Crate;
	float timer = 2.0f;
	ArrayList crates = new ArrayList();
	public bool endGame = false;
	// Use this for initialization
	void Start () {
		InvokeRepeating ("Spawner", timer, timer);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!GameControllerRunAndJump.isActive)
		{
			for (int i = 0; i < crates.Count; i++)
			{
				((GameObject) crates[i]).GetComponent<Rigidbody2D>().velocity = (new Vector3(0.0f, 0.0f, 0.0f));
			}
		}
		else if (!endGame)
		{
			for (int i = 0; i < crates.Count; i++)
			{
				((GameObject) crates[i]).GetComponent<Rigidbody2D>().velocity = (new Vector3(-20.0f, 0.0f, 0.0f));
				if (((GameObject) crates[i]).GetComponent<Rigidbody2D>().position.x < -4.0f)
				{
					Destroy(((Object) crates[i]));
					crates.RemoveAt(i);
					i -= 1;
				}
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
			crates.Add (obje);
		}
	}
}