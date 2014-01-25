using UnityEngine;
using System.Collections;

public class Netwok : MonoBehaviour 
{
	public string connectionIP = "127.0.0.1";
	public int connectionPort = 25001;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Network.isServer)
		{
			Vector3 moveDir = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
			float speed = 5;
			transform.Translate(speed * moveDir * Time.deltaTime);
		}
	}

	void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info)
	{
		if (stream.isWriting)
		{
			Vector3 pos = transform.position;
			stream.Serialize(ref pos);

			Vector3 vel = transform.rigidbody2D.velocity;
			stream.Serialize(ref vel);
		}
		else
		{
			Vector3 receivedPosition = Vector3.zero;
			stream.Serialize(ref receivedPosition);

			Vector3 receivedVelocity = Vector3.zero;
			stream.Serialize(ref receivedVelocity);
		}
	}

	void OnGUI()
	{
		if (Network.peerType == NetworkPeerType.Disconnected)
		{
			GUI.Label(new Rect(10, 10, 300, 20), "Status: Disconnected");
			if (GUI.Button(new Rect(10, 30, 120, 20), "Client Connect"))
			{
				Network.Connect(connectionIP, connectionPort);
			}
			if (GUI.Button(new Rect(10, 50, 120, 20), "Initialize Server"))
			{
				Network.InitializeServer(1, connectionPort, false);
			}
		}
		else if (Network.peerType == NetworkPeerType.Client)
		{
			GUI.Label(new Rect(10, 10, 300, 20), "Status: Connected as Client");
			if (GUI.Button(new Rect(10, 30, 120, 20), "Disconnect"))
			{
				Network.Disconnect(200);
			}
		}
		else if (Network.peerType == NetworkPeerType.Server)
		{
			GUI.Label(new Rect(10, 10, 300, 20), "Status: Connected as Server");
			if (GUI.Button(new Rect(10, 30, 120, 20), "Disconnect"))
			{
				Network.Disconnect(200);
			}
		}
	}
}
