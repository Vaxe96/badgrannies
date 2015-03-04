using UnityEngine;
using System.Collections;

public class playerhp : MonoBehaviour {


	
	void OnTriggerEnter(Collider c)
	{
		if (c.gameObject.tag == "luoti2") {
			GameManager.hp --; // pienennetään eläimiä

			// jos hiparit loppuu, niin tuhoudutaan
			if (GameManager.hp <= 0)
				Application.LoadLevel("game_over");
			
			
		}
		
	}

}
