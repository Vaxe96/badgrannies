using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public GUIStyle tyyli;


	void OnGUI () {

		float x = Screen.width / 2;
		float y = Screen.height / 2;

		// laatikko
		GUI.Box(new Rect(x-200,y-120,400,240),"");

		// otsikko
		GUI.Label (new Rect(0,y-120,Screen.width,100),"Bad Grannies",tyyli);

		// namiskat
		if (GUI.Button (new Rect (x - 120, y + 120, 120, 100), "START"))
		{
			Application.LoadLevel("FireRate");
		}
		if (GUI.Button (new Rect (x, y + 120, 120, 100), "QUIT"))
		{
			Application.Quit();// toimii vaan buildatussa exessä
		}

		Cursor.visible=true;


	
	}
}


