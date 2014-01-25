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
		if ("MV".Equals(cmd)) {
			transform.position += new Vector3(1,0,0);
		}
	}
}
