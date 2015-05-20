using UnityEngine;
using System.Collections;

public class GameControllerBalance: AbstractGameController  {

	public static bool isActive = false;
	
	public static void StartGame(){
		isActive = true;
	}
	
	public static void PauseGame(){
		isActive = false;
	}
}
