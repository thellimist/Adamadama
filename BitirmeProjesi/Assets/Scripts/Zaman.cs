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
		//GameObject spawner = GameObject.Find("BoxSpawner");
		// If the player should jump...
		if (GameControllerRunAndJump.isActive) {
						score += Time.deltaTime;
				}
	}

	void OnGUI()
	{
		/*0GUIStyle myfontSize = new GUIStyle();
		myfontSize.alignment = TextAnchor.UpperCenter;
		myfontSize.fontSize = 32;
		//GUI.Label( new Rect(Screen.width / 2, 50,Screen.width,Screen.height), ((int) score).ToString(), myfontSize);
		GUI.Label( new Rect(0, 0,Screen.width,Screen.height), (System.Math.Round(score, 1)).ToString(), myfontSize);*/
	}
}
