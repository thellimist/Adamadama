using UnityEngine;
using System.Collections;

public class GameControllerRunAndJump : AbstractGameController {
	
	
	public static bool isActive = true;
	
	public static new void StartGame(){
		isActive = true;
	}
	
	public static new void PauseGame(){
		isActive = false;
	}
	
}