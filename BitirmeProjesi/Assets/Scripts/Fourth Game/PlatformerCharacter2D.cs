using UnityEngine;

public class PlatformerCharacter2D : MonoBehaviour 
{
	bool facingRight = true;							// For determining which way the player is currently facing.
	
	[SerializeField] float jumpForce;					// Amount of force added when the player jumps.	
	
	[SerializeField] LayerMask whatIsGround;			// A mask determining what is ground to the character
	
	Transform groundCheck;								// A position marking where to check if the player is grounded.
	float groundedRadius = .2f;							// Radius of the overlap circle to determine if grounded
	bool grounded = false;								// Whether or not the player is grounded.
	Animator anim;										// Reference to the player's animator component.
	
	
	void Awake()
	{
		// Setting up references.
		groundCheck = transform.Find("GroundCheck");
		anim = GetComponent<Animator>();
	}
	
	
	void FixedUpdate()
	{
		// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundedRadius, whatIsGround);
		anim.SetBool("Ground", grounded);
		
		// Set the vertical animation
		//anim.SetFloat("vSpeed", rigidbody2D.velocity.y);
	}
	
	
	public void Move(float move, bool jump)
	{
		//GameObject spawner = GameObject.Find("BoxSpawner");
		// If the player should jump...
		if (grounded && jump && GameControllerRunAndJump.isActive) {
			// Add a vertical force to the player.
			anim.SetBool("Ground", false);
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce));
		}
	}
	
	
	void Flip ()
	{
		// Switch the way the player is labelled as facing.
		facingRight = !facingRight;
		
		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	
	void OnCollisionEnter2D(Collision2D carpisan)
	{
		if (carpisan.gameObject.tag == "Crate")
		{
			//GameObject spawner = GameObject.Find("BoxSpawner");
			MiniGameController.GameOver();
			anim.SetBool("Crouch", true);
		}
	}
}