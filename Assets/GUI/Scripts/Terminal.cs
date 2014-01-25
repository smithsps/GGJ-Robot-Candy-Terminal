using UnityEngine;
using System.Collections;

public class Terminal : MonoBehaviour {

	public GUIStyle termStyle;

	public string GetCommand() {
		return command;
	}

	// Height in lines
	private const int HEIGHT = 9;

	private string[] termLines;
	private int curLine;
	private string command;

	// Use this for initialization
	void Start () {
		termLines = new string[HEIGHT];
		curLine = 0;
		termLines[curLine] = "";
	}
	
	// Update is called once per frame
	void Update () {
		command = null;
		foreach (var c in Input.inputString) {
			switch (c) {
			case '\b':
				if (termLines[curLine].Length != 0) {
					termLines[curLine] = termLines[curLine].Substring(0, termLines[curLine].Length-1);
				}				
				break;

			case '\r':
			case '\n':
				command = termLines[curLine];
				if (curLine == HEIGHT-1) {
					// Scroll
					for (int i = 0; i < HEIGHT-1; i++) {
						termLines[i] = termLines[i+1];
					}
					termLines[curLine] = "";
				} else {
				    termLines[++curLine] = "";
				}
				break;
				
			default:
				termLines[curLine] += char.ToUpper(c);
				break;
			}		    
		}
	}

	// GUI Update
	void OnGUI () {
		int heightPx = HEIGHT*termStyle.fontSize + termStyle.padding.top + termStyle.padding.bottom;
		Rect termRect = new Rect(0, Screen.height-heightPx, Screen.width, heightPx);

		string termString = "";
		for (int i = 0; i <= curLine; ++i) {
			termString += ">" + termLines[i] + "\n";
		}

	    GUI.Label (termRect, termString, termStyle);
	}
}
