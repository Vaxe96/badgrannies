using UnityEngine;
using System.Collections;

public class Hp : MonoBehaviour {

	public int hp = 100;

	void OnCollisionEnter(Collision c)
	{
		if (c.gameObject.tag == "luoti2") {
			hp --; // pienennetään eläimiä
			
			// jos hiparit loppuu, niin tuhoudutaan
			if (hp <= 0)
				Destroy (gameObject);
			

		}
		
	}
}
