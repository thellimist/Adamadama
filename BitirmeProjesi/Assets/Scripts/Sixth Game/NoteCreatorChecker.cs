using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Sprites;

public class NoteCreatorChecker : MonoBehaviour {

	public Button redButton;
	public Button blueButton;
	public Button greenButton;
	public Button yellowButton;
	public Sprite redButtonDark;
	public Sprite redButtonBright;
	public Sprite greenButtonDark;
	public Sprite greenButtonBright;
	public Sprite blueButtonDark;
	public Sprite blueButtonBright;
	public Sprite yellowButtonDark;
	public Sprite yellowButtonBright;
	public AudioSource redButtonAudio;
	public AudioSource greenButtonAudio;
	public AudioSource yellowButtonAudio;
	public AudioSource blueButtonAudio;
	int counter;
	ArrayList buttons;
	ArrayList brightSprites;
	ArrayList darkSprites;
	ArrayList notes;
	ArrayList audios;
	bool play;
	int randomNumber;
	int nextNumber;
	bool gameOver;
	int bitisCounter;

	// Use this for initialization
	void Start () {
		redButton.gameObject.SetActive (true);
		blueButton.gameObject.SetActive (true);
		yellowButton.gameObject.SetActive (true);
		greenButton.gameObject.SetActive (true);


		counter = 0;
		bitisCounter = 0;
		buttons = new ArrayList();
		brightSprites = new ArrayList();
		darkSprites = new ArrayList();
		notes = new ArrayList();
		audios = new ArrayList();
		buttons.Add(redButton);
		buttons.Add(blueButton);
		buttons.Add(yellowButton);
		buttons.Add(greenButton);
		brightSprites.Add(redButtonBright);
		brightSprites.Add(blueButtonBright);
		brightSprites.Add(yellowButtonBright);
		brightSprites.Add(greenButtonBright);
		darkSprites.Add(redButtonDark);
		darkSprites.Add(blueButtonDark);
		darkSprites.Add(yellowButtonDark);
		darkSprites.Add(greenButtonDark);
		audios.Add(redButtonAudio);
		audios.Add(blueButtonAudio);
		audios.Add(yellowButtonAudio);
		audios.Add(greenButtonAudio);
		play = true;
		gameOver = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!MiniGameController.gameOver && GameControllerNoteMemory.isActive) {
			redButton.gameObject.SetActive (true);
			blueButton.gameObject.SetActive (true);
			yellowButton.gameObject.SetActive (true);
			greenButton.gameObject.SetActive (true);
						counter++;
						// Play dedigim sey, notalarin random calindigi kisim.
						if (play) {
								// Counter her kirk oldugunda bir nota caliyorum.
								if (counter == 40) {
										randomNumber = Random.Range (0, 4);
										notes.Add (randomNumber);
					if((audios [randomNumber] as AudioSource) != null){
						Debug.Log (" NOT NNULLL"+(audios [randomNumber] as AudioSource));
					}
					else{
						Debug.Log (" NULL");
					}
										(buttons [randomNumber] as Button).GetComponentInChildren<Image> ().overrideSprite = darkSprites [randomNumber] as Sprite;
										(audios [randomNumber] as AudioSource).Play ();
					Debug.Log (" PLAYING NOW");
								}
			// Notanin bitmesi 80'i buluyor. 4. notayi da caldiktan sona, adamin inputlari girmesini bekliyorum.
			else if (counter == 80) {
										(buttons [randomNumber] as Button).GetComponentInChildren<Image> ().overrideSprite = brightSprites [randomNumber] as Sprite;
										counter = 0;
										if (notes.Count == 4) {
												play = false;
												nextNumber = ((int)notes [0]);
										}
								}
						} else {
								// Buradaysa adamdan bitisCounter 500 olana kadar tum notalari girmesini bekliyorum. Giremezse GG.
								bitisCounter++;
								if (bitisCounter == 5000)
										Debug.Log ("GG");
						}
				}
	}

	public void butonaBasildi(Button btn)
	{
		// Notalarin random calindigi kisimda butonlara basilmasi bir sey ifade etmiyor.
		// Basma sirasi bize gecince play == false.
		Debug.Log (" BASILDI MI LAAAN");
		if (play == false)
		{
			if (notes.Count > 0)
			{
				if (btn.CompareTag("Red") && nextNumber != 0)
				{
					gameOver = true;
				}
				else if (btn.CompareTag("Blue") && nextNumber != 1)
				{
					gameOver = true;
				}
				else if (btn.CompareTag("Yellow"))
				{
					if (nextNumber != 2)
					{
						gameOver = true;
					}
				}
				else if (btn.CompareTag("Green"))
				{
					if (nextNumber != 3)
					{
						gameOver = true;
					}
				}
			}
			notes.RemoveAt(0);
			if (notes.Count > 0)
			{
				nextNumber = ((int)notes[0]);
			}
			// Eger 4 notayi da dogru girdiysek gameOver hala false, o zaman yeni sequence gelebiliyor.
			else if (gameOver == false)
			{
				counter = -40;
				play = true;
			}
			// yoksa GG.
			else
			{
				Debug.Log("GG");
				MiniGameController.GameOver();
			}
		}

	}
}
