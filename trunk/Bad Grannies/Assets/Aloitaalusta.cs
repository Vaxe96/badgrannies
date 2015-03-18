using UnityEngine;
using System.Collections;

public class Aloitaalusta : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnGUI () {

		float x = Screen.width / 2;
		float y = Screen.height / 2;

		if (GUI.Button (new Rect (x + 370, y + 215, 150, 100), "Aloita alusta")) {
			Application.LoadLevel ("mainmenu");
			
		}
		Cursor.visible=true;
	}
}
