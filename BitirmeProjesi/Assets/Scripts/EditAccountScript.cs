using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EditAccountScript : MonoBehaviour {

	public InputField userName;
	public InputField mailAddress;

	public static string userNameString;
	public static string mailAddressString;


	void Start(){

		if (userNameString != null) {
			userName.text = userNameString;
		}

		if (mailAddressString != null) {
			mailAddress.text = mailAddressString;
		}

	}

	void Awake(){

		DontDestroyOnLoad (transform.gameObject);
		}

	public void saveSettings(){

		userNameString = userName.text;
		mailAddressString = mailAddress.text;
	}

	public void backToMenu(){
		
		Application.LoadLevel ("MainMenuScene");
	}
}
