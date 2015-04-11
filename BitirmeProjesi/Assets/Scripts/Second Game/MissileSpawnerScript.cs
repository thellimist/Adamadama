using UnityEngine;
using System.Collections;

public class MissileSpawnerScript : MonoBehaviour
{
		[SerializeField]
		GameObject missile;
		public int counter = 0;

		void Start ()
		{

		}
	
		// Update is called once per frame
		void Update ()
		{
				if (GameControllerMissiles.isActive) {
						if (counter == 0) {
								missile = Instantiate (Resources.Load ("Missile")) as GameObject;
								Vector2 objPos;
								objPos.x = transform.position.x;
								objPos.y = Random.Range (transform.position.y - 2.4f, transform.position.y + 2.4f);
								missile.transform.position = objPos;
						}
						if (counter == 35) {
								counter = 0;
						} else if (counter != 35) {
								counter++;
						}
								
				}
				GameObject[] missileClones =GameObject.FindGameObjectsWithTag ("Missile");
				for (int i = 0; i<missileClones.Length; i++) {
					
					missileClones[i].GetComponent<Rigidbody2D>().velocity = (new Vector3(-2.0f, 0.0f, 0.0f));
				}
		}
}