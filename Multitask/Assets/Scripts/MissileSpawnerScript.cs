using UnityEngine;
using System.Collections;

public class MissileSpawnerScript : MonoBehaviour {
	[SerializeField] GameObject missile;
	int counter = 0;
	int counter_limit = 100;

	void Start () {
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!MiniGameController.gameOver && GameControllerMissiles.isActive)
		{
						if (counter == 0) {
								missile = Instantiate (Resources.Load ("Missile")) as GameObject;
								Vector2 objPos;
								objPos.x = transform.position.x;
								objPos.y = Random.Range (transform.position.y - 5f, transform.position.y + 5f);
								missile.transform.position = objPos;
						}
						if (counter == counter_limit)
								counter = 0;
						else if (counter != counter_limit)
								counter++;
				}
		}
}