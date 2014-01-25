using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {
	public Terminal terminal;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		string cmd = terminal.GetCommand();
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
