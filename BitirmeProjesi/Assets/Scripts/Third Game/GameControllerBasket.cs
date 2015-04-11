using UnityEngine;
using System.Collections;

public class GameControllerBasket : AbstractGameController {


	public static bool isActive = false;

	public static void StartGame(){
		isActive = true;
	}
	
	public static void PauseGame(){
		isActive = false;
	}

} 
