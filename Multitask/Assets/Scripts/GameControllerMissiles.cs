using UnityEngine;
using System.Collections;

public class GameControllerMissiles : AbstractGameController {
	
	
	public static bool isActive = false;
	
	public static new void StartGame(){
		isActive = true;
	}

	public static new void PauseGame(){
		isActive = false;
	}
	
} 
