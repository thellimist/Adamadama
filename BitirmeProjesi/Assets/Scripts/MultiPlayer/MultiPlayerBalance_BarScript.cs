using UnityEngine;
using System.Collections;

public class MultiPlayerBalance_BarScript : MonoBehaviour {

	public static float angle;
	public static float xPos;
	public static float yPos;
	// Use this for initialization
	void Start () 
	{
		angle = 0;
		xPos = 0;
		yPos = 0;
	}
	public float speed = 10f;
	
	private float lastSynchronizationTime = 0f;
	private float syncDelay = 0f;
	private float syncTime = 0f;
	private Vector3 syncStartPosition = Vector3.zero;
	private Vector3 syncEndPosition = Vector3.zero;
	
	void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info)
	{
		Vector3 syncPosition = Vector3.zero;
		Vector3 syncVelocity = Vector3.zero;
		if (stream.isWriting)
		{
			syncPosition = rigidbody.position;
			stream.Serialize(ref syncPosition);
			
			syncPosition = rigidbody.velocity;
			stream.Serialize(ref syncVelocity);
		}
		else
		{
			stream.Serialize(ref syncPosition);
			stream.Serialize(ref syncVelocity);
			
			syncTime = 0f;
			syncDelay = Time.time - lastSynchronizationTime;
			lastSynchronizationTime = Time.time;
			
			syncEndPosition = syncPosition + syncVelocity * syncDelay;
			syncStartPosition = rigidbody.position;
		}
	}
	
	void Awake()
	{
		lastSynchronizationTime = Time.time;
	}
	
	void Update()
	{
		if (networkView.isMine)
		{
			InputMovement();
			InputColorChange();
		}
		else
		{
			SyncedMovement();
		}
	}
	
	
	private void InputMovement()
	{
		if (Input.GetKey (KeyCode.W)) {
						angle += 0.1f;
						rigidbody2D.transform.RotateAround (transform.position, Vector3.forward, angle);
				}
		
		if (Input.GetKey (KeyCode.S)) {
						angle -= 0.1f;
			rigidbody2D.transform.RotateAround (transform.position, Vector3.forward, angle);
				}

	}
	
	private void SyncedMovement()
	{
		syncTime += Time.deltaTime;
		if (rigidbody != null) {
						rigidbody.position = Vector3.Lerp (syncStartPosition, syncEndPosition, syncTime / syncDelay);
				}
	}
	
	
	private void InputColorChange()
	{
		if (Input.GetKeyDown(KeyCode.R))
			ChangeColorTo(new Vector3(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f)));
	}
	
	[RPC] void ChangeColorTo(Vector3 color)
	{
		renderer.material.color = new Color(color.x, color.y, color.z, 1f);
		
		if (networkView.isMine)
			networkView.RPC("ChangeColorTo", RPCMode.OthersBuffered, color);
	}



}
