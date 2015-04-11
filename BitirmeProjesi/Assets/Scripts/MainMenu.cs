using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour 
{

	public static bool isSoundOn = true;
	// Use this for initialization
	void Start () 
	{
		GetComponent<AudioSource>().Play ();
	}
	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
		GetComponent<AudioSource>().Stop ();
	}
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKey ("escape")) {
				Application.Quit();
		}
		if (MainMenu.isSoundOn == true) {
				if(GetComponent<AudioSource>().isPlaying == true){
				}
				else{
					GetComponent<AudioSource>().Play ();
				}
		} else {
			GetComponent<AudioSource>().Stop();
		}
	}



}
