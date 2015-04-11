using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MultiPlayerLogicScript : MonoBehaviour
{
	private const string typeName = "UniqueGameName";
	private const string gameName = "RoomName";
	
	private bool isRefreshingHostList = false;
	private HostData[] hostList;

	public Camera multiPlayerCamera;

	public GameObject multiPlayerBall1;
	public GameObject multiPlayerBar1;
	public GameObject multiDropChecker1;
	public GameObject multiPlayerBall2;
	public GameObject multiPlayerBar2;
	public GameObject multiDropChecker2;
	private bool amIHost;
	public int counter = 0;

	public Button createARoomButton;
	public Button showRoomsButton;

	void OnGUI()
	{
		if (!Network.isClient && !Network.isServer)
		{
			if (hostList != null)
			{
				for (int i = 0; i < hostList.Length; i++)
				{

					if (GUI.Button(new Rect(400, 100 + (110 * i), 300, 100), hostList[i].gameName))
						JoinServer(hostList[i]);
						

				}
			}
		}
	}
	
	public void StartServer()
	{
		createARoomButton.gameObject.SetActive (false);
		showRoomsButton.gameObject.SetActive (false);
		amIHost = true;
		Network.InitializeServer(5, 25000, !Network.HavePublicAddress());
		MasterServer.RegisterHost(typeName, gameName);
	}
	
	void OnServerInitialized()
	{
		//multiPlayerCamera.rect = new Rect (0f, 0.5f, 0.5f, 0.5f);
		SpawnPlayer();

	}
	
	
	void Update()
	{
		if (isRefreshingHostList && MasterServer.PollHostList().Length > 0)
		{
			isRefreshingHostList = false;
			hostList = MasterServer.PollHostList();
		}
	}
	
	public void RefreshHostList()
	{
		if (!isRefreshingHostList)
		{
			isRefreshingHostList = true;
			MasterServer.RequestHostList(typeName);
		}
	}
	
	
	private void JoinServer(HostData hostData)
	{
		createARoomButton.gameObject.SetActive (false);
		showRoomsButton.gameObject.SetActive (false);
		amIHost = false;
		Network.Connect(hostData);
	}
	
	void OnConnectedToServer()
	{
		SpawnPlayer();
	}
	
	
	private void SpawnPlayer()
	{
		Vector3 multiPlayerBar1Position = new Vector3 (0f, 1f, 0f);
		Vector3 multiPlayerBall1Position = new Vector3 (0f, 5f, 0f);
		Vector3 multiDropChecker1Position = new Vector3 (0f, -9f, 0f);

		Vector3 multiPlayerBar2Position = new Vector3(multiPlayerBar1Position.x-17f, multiPlayerBar1Position.y, 0f);
		Vector3 multiPlayerBall2Position = new Vector3(multiPlayerBall1Position.x-17f, multiPlayerBall1Position.y, 0f);
		Vector3 multiDropChecker2Position = new Vector3(multiDropChecker1Position.x-17f, multiDropChecker1Position.y, 0f);

		if (amIHost == true ) {

			Network.Instantiate (multiPlayerBar1, multiPlayerBar1Position, Quaternion.identity, 0);
			Network.Instantiate (multiPlayerBall1, multiPlayerBall1Position, Quaternion.identity, 0);
			Network.Instantiate (multiDropChecker1, multiDropChecker1Position, Quaternion.identity, 0);
						counter++;

		} 
		else if (amIHost == false) {

			Network.Instantiate (multiPlayerBar2, multiPlayerBar2Position , Quaternion.identity, 0);
			Network.Instantiate (multiPlayerBall2, multiPlayerBall2Position, Quaternion.identity, 0);
			Network.Instantiate (multiDropChecker2, multiDropChecker2Position, Quaternion.identity, 0);
			counter++;
		}
		
		
	}
}
