using UnityEngine;
using System.Collections;

public class UI : MonoBehaviour {

	public Texture OverlordLayoutTexture;
	public Texture PeterLayoutTexture;

	public bool state = true;

	// Use this for initialization
	void Start () {
		//Get Player state
		//state = true;
	}
	
	// Update is called once per frame
	void OnGUI() {
		if(state) {
			OverlordLayout();
		} else {
			PeterLayout();
		}
	}

	void PeterLayout() {
		GUI.DrawTexture(new Rect(0,0,1280,720), PeterLayoutTexture);
	}

	void OverlordLayout(){
		GUI.DrawTexture(new Rect(0,0,1280,720), OverlordLayoutTexture);
	}
}
