using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour 
{

	public static bool isSoundOn = true;
	// Use this for initialization
	void Start () 
	{
		audio.Play ();
	}
	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
		audio.Stop ();
	}
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKey ("escape")) {
				Application.Quit();
		}
		if (MainMenu.isSoundOn == true) {
				if(audio.isPlaying == true){
				}
				else{
					audio.Play ();
				}
		} else {
			audio.Stop();
		}
	}



}
