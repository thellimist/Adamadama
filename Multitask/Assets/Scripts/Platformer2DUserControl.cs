using UnityEngine;

[RequireComponent(typeof(PlatformerCharacter2D))]
public class Platformer2DUserControl : MonoBehaviour 
{
	private PlatformerCharacter2D character;
	private bool jump;
	[SerializeField] public Texture2D pausetexture;
	
	void Awake()
	{
		character = GetComponent<PlatformerCharacter2D>();
	}
	
	void Update ()
	{
		// Read the jump input in Update so button presses aren't missed.

		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended) jump = true;
		if (Input.GetButtonDown("Jump")) jump = true;
		
	}
	
	void FixedUpdate()
	{
		// Read the inputs.

		float h = Input.GetAxis("Horizontal");
		
		// Pass all parameters to the character control script.
		character.Move( h, jump );
		
		// Reset the jump input once it has been used.
		jump = false;
	}

	void OnGUI()
	{

	}
}