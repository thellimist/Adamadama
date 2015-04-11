using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuManagerScript : MonoBehaviour {

	public Button soundOnOffButton;
	public Sprite soundOffButtonSprite;
	public Sprite soundOnButtonSprite;

	public Button multiPlayerButton;

	void Start(){

		if (MainMenu.isSoundOn == true) {
			(soundOnOffButton).image.sprite =soundOnButtonSprite;
			//soundOnOffButton.sprite = soundOnButtonSprite;
		} else {
			(soundOnOffButton).image.sprite =soundOffButtonSprite;
		}

		}

	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
		DontDestroyOnLoad(soundOnOffButton.image);
		DontDestroyOnLoad(soundOffButtonSprite);
		DontDestroyOnLoad(soundOnButtonSprite);

	}



	public void StartGameButton () {
		MiniGameController.score = 0;
		Application.LoadLevel ("GameScene");
	}

	public void rateUsOnGoogleButton () {
		// TODO
	}

	public void leaderBoardButton () {
		// TODO
	}

	public void soundOnOffButtonFunction () {
		MainMenu.isSoundOn = !MainMenu.isSoundOn;
		if (MainMenu.isSoundOn == true) {
			(soundOnOffButton).image.sprite =soundOnButtonSprite;
			//soundOnOffButton.sprite = soundOnButtonSprite;
				} else {
			(soundOnOffButton).image.sprite =soundOffButtonSprite;
				}
	}

	public void editAccountButton () {
		Application.LoadLevel ("EditAccountScene");
	}

	public void multiPlayerButtonFunction () {
		Application.LoadLevel ("MultiPlayerScene");
	}
}
