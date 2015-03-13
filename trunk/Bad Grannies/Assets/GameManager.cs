using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static int score = 0;
	public static int hp = 100;
	private int starthp = 1;
	public Texture2D bgImage; 
	public Texture2D fgImage;

	public static bool player_destroyed = false;

	public GUIStyle score_tyyli;
	public GUIStyle gameover_tyyli;
	public Text scoretexti;


	void Start()
	{
		// nää pitää resetoida käsin, koska ne on staattisia

		player_destroyed = false;
		starthp=hp;
	}

	void OnGUI()
	{
		if (Application.loadedLevelName == "game_over")
						return;
		if(bgImage!=null && fgImage!=null)
		{
//			if(renderer.isVisible)
			{
				float x = 0;
				float y = 0;
				float w = 100f;
				float h = 100f;
				
				/// if(x+w/2 < Screen.width && x-w/2>0f && y+h/2 < Screen.height && y-h/2>0f)
				{
					
					float w2 = w*((float)(hp)/(float)(starthp));
					
					GUI.Label (new Rect(x-w/2,y,w,h),bgImage);
					
					GUI.BeginGroup (new Rect(x-w/2,y,w2,h));
					GUI.Label (new Rect(0,0,w,h),fgImage);
					GUI.EndGroup();
					
				}
			}
		}
		// printataan pisteet ruudulle vasempaan ylänurkkaan
		GUI.Label (new Rect(10,10,100,100),"SCORE: " + score,score_tyyli);

		// printataan GAME OVER keskelle ruutua
		if (player_destroyed == true)
		{
			float x = Screen.width/2;
			float y = Screen.height/2;
			GUI.Label (new Rect (x, y, 100, 100), "GAME OVER",gameover_tyyli);


			// namiskat
			if (GUI.Button (new Rect (x - 120, y + 120, 120, 100), "START"))
			{
				Application.LoadLevel("level_1");
			}
			if (GUI.Button (new Rect (x, y + 120, 120, 100), "QUIT"))
			{
				Application.LoadLevel("mainmenu");


			}
		}
	}

	void Update()
	{
		// restartti
		if (Input.GetKey (KeyCode.R)) {
						Application.LoadLevel (Application.loadedLevelName);
			score = 0;
				}
		if (scoretexti != null)
						scoretexti.text = "pisteet"+ GameManager.score;



	}
}





