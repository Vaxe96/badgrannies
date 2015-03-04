using UnityEngine;
using System.Collections;

public class Hp : MonoBehaviour {

	public int hp = 100;
	public AudioClip puspus;

	void OnCollisionEnter(Collision c)
	{
		if (c.gameObject.tag == "luoti2") {
			hp --; // pienennetään eläimiä
			
			// jos hiparit loppuu, niin tuhoudutaan
			if (hp <= 0)
			{	AudioSource.PlayClipAtPoint (puspus, transform.position);
				Destroy (gameObject);}
			

		}
		
	}
}
