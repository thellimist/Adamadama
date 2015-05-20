using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartGame : MonoBehaviour {
	
	public int counter = 100;
	public int randomIslem;
	public int randomSayi1;
	public int randomSayi2;
	public int randomButton;

	public static int sonuc;

	public bool isGameStarted = false;

	public Text welcomeText;

	public Text button1;
	public Text button2;
	public Text button3;
	public Text button4;

	public Text geriSayim;

	GameObject buttonObj1;
	GameObject buttonObj2;
	GameObject buttonObj3;
	GameObject buttonObj4;

	void Start () 
	{

		//To hide and show, we must use GameObjects not Text variables.
		buttonObj1 = GameObject.Find ("Button1");
		buttonObj2 = GameObject.Find ("Button2");
		buttonObj3 = GameObject.Find ("Button3");
		buttonObj4 = GameObject.Find ("Button4");

		//Hide the buttons.

		buttonObj1.SetActive (false);
		buttonObj2.SetActive (false);
		buttonObj3.SetActive (false);
		buttonObj4.SetActive (false);

	}

	void Update ()
	{
		if (!MiniGameController.gameOver && GameControllerCalculation.isActive) {
					
						// Showing the remaining seconds.
						if (counter % 10 == 0) {
								geriSayim = GameObject.Find ("Canvas2").transform.FindChild ("SecondText").GetComponent<Text> ();
								geriSayim.text = counter / 10 + "";
								if (counter <= 100)
										geriSayim.color = Color.red;
								else
										geriSayim.color = Color.black;
						}
						counter--;
						if(isGameStarted && geriSayim.text == "1"){
							if(button1.color == Color.black && 
							   button2.color == Color.black &&
							   button3.color == Color.black &&
							   button4.color == Color.black ){
										MiniGameController.GameOver();
										return;
							}
						}
						// If the remaining time is over, start from the beginning.
						if (counter == 0) {
								//Show the buttons.
								isGameStarted = true;
								buttonObj1.SetActive (true);
								buttonObj2.SetActive (true);
								buttonObj3.SetActive (true);
								buttonObj4.SetActive (true);
								
								counter = 250;
								randomIslem = Random.Range (0, 4);
								randomSayi1 = Random.Range (1, 10);
								randomSayi2 = Random.Range (1, 10);
								randomButton = Random.Range (1, 5);

								welcomeText = GameObject.Find ("Canvas2").transform.FindChild ("WelcomeText").GetComponent<Text> ();

								// We need to get every text value from the buttons in order to change them.
								button1 = GameObject.Find ("Canvas2").transform.FindChild ("Button1").transform.FindChild ("Button1Text").GetComponent<Text> ();
								button2 = GameObject.Find ("Canvas2").transform.FindChild ("Button2").transform.FindChild ("Button2Text").GetComponent<Text> ();
								button3 = GameObject.Find ("Canvas2").transform.FindChild ("Button3").transform.FindChild ("Button3Text").GetComponent<Text> ();
								button4 = GameObject.Find ("Canvas2").transform.FindChild ("Button4").transform.FindChild ("Button4Text").GetComponent<Text> ();

								button1.color = Color.black;
								button2.color = Color.black;
								button3.color = Color.black;
								button4.color = Color.black;

								if (randomIslem == 0) {
										//addition
										sonuc = randomSayi1 + randomSayi2;
										welcomeText.text = randomSayi1 + " + " + randomSayi2;
								} else if (randomIslem == 1) {
										//subtraction
										sonuc = randomSayi1 - randomSayi2;
										welcomeText.text = randomSayi1 + " - " + randomSayi2;
								} else if (randomIslem == 2) {
										//multiplication
										sonuc = randomSayi1 * randomSayi2;
										welcomeText.text = randomSayi1 + " x " + randomSayi2;
								} else if (randomIslem == 3) {
										//division
										while (randomSayi1 % randomSayi2 != 0) {
												randomSayi1 = Random.Range (1, 100);
												randomSayi2 = Random.Range (1, 100);
										}
										sonuc = randomSayi1 / randomSayi2;
										welcomeText.text = randomSayi1 + " / " + randomSayi2;
								}

								// Put the correct value on one of the buttons and randomize others.
								if (randomButton == 1) {
										button1.text = sonuc.ToString ();
										button2.text = (sonuc + Random.Range (1, 50)).ToString ();
										button3.text = (sonuc * Random.Range (2, 10)).ToString ();
										button4.text = (sonuc - Random.Range (1, 20)).ToString ();
								} else if (randomButton == 2) {
										button2.text = sonuc.ToString ();
										button3.text = (sonuc + Random.Range (5, 30)).ToString ();
										button1.text = (sonuc * Random.Range (2, 10)).ToString ();
										button4.text = (sonuc - Random.Range (5, 15)).ToString ();
								} else if (randomButton == 3) {
										button3.text = sonuc.ToString ();
										button1.text = (sonuc + Random.Range (7, 50)).ToString ();
										button4.text = (sonuc * Random.Range (2, 10)).ToString ();
										button2.text = (sonuc - Random.Range (7, 20)).ToString ();
								} else if (randomButton == 4) {
										button4.text = sonuc.ToString ();
										button2.text = (sonuc + Random.Range (10, 50)).ToString ();
										button3.text = (sonuc * Random.Range (3, 12)).ToString ();
										button1.text = (sonuc - Random.Range (10, 30)).ToString ();
								}

						}
						
				}
	}
}
