using UnityEngine;
using System.Collections;

using Pathfinding;
public class Commands : MonoBehaviour {
	private bool moveOverride = false;

	public Terminal terminal;

	private Seeker seeker;
	
	//The calculated path
	public Path path;
	
	//The AI's speed per second
	public float speed = 0.5f;
	
	//The max distance from the AI to a waypoint for it to continue to the next waypoint
	public float nextWaypointDistance = 0.1f;
	
	//The waypoint we are currently moving towards
	private int currentWaypoint = 0;

	// Use this for initialization
	void Start () {
		seeker = GetComponent<Seeker>();
		seeker.StartPath (transform.position, transform.position, OnPathComplete);
	}

	// Update is called once per frame
	void Update () {

		if(Network.isServer)
		{
			string cmd = terminal.GetCommand();
			if (cmd != null) {
				string[] words = cmd.Split(' ');
				Debug.Log (name);
				if ("MV".Equals(words[0])) {
					if (words[1].Equals(name.ToUpper())) { moveTo (new Vector3(-2, -1, 0)); moveOverride = true; }
				}

				if ("MV UP".Equals(cmd)) {
					rigidbody2D.AddForce(new Vector2(0,10));
				} else if ("MV DN".Equals(cmd)) {
					rigidbody2D.AddForce(new Vector2(0,-10));
				} else if ("MV RT".Equals(cmd)) {
					rigidbody2D.AddForce(new Vector2(10,0));
				} else if ("MV LT".Equals(cmd)) {
					rigidbody2D.AddForce(new Vector2(-10,0));
				} else if ("IDSPISPOPD".Equals(cmd)) {
					this.collider2D.enabled = !this.collider2D.enabled;	
				}
			}
		}

		GameObject player = GameObject.Find ("Delivery Guy - Mean");
		Vector3 dist = player.transform.position - transform.position;
		if (dist.magnitude <= 5.0f && moveOverride == false) {
			Debug.Log(player.transform.position);
			moveTo(player.transform.position);
		}

		if (path == null) {
			//We have no path to move after yet
			return;
		}
		
		if (currentWaypoint >= path.vectorPath.Count) {
			//Debug.Log ("End Of Path Reached");
			moveOverride = false;
			return;
		}
		
		//Direction to the next waypoint
		Vector3 dir = (path.vectorPath[currentWaypoint]-transform.position).normalized;
		dir *= speed * Time.fixedDeltaTime;
		transform.position = transform.position + dir;
		
		//Check if we are close enough to the next waypoint
		//If we are, proceed to follow the next waypoint
		if (Vector3.Distance (transform.position,path.vectorPath[currentWaypoint]) < nextWaypointDistance) {
			currentWaypoint++;
			return;
		}
	}
	
	public void OnPathComplete (Path p) {
		Debug.Log ("Yay, we got a path back. Did it have an error? "+p.error);
		if (!p.error) {
			path = p;
			//Reset the waypoint counter
			currentWaypoint = 0;
		}
	}
	
	public void moveTo (Vector3 targetPos) {
		seeker.StartPath (transform.position, targetPos, OnPathComplete);
	}
}
