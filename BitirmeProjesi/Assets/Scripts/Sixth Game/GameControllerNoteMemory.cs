using UnityEngine;
using System.Collections;

public class GameControllerNoteMemory  {

	public static bool isActive = false;
	
	public static void StartGame(){
		isActive = true;
	}
	
	public static void PauseGame(){
		isActive = false;
	}
}
