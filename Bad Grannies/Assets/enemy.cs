using UnityEngine;
using System.Collections;

public class enemy : MonoBehaviour {

	public float speed = 0.5f;
	public int hp = 10;
	public AudioClip puspus;
	
	// ampumisasetukset
	public GameObject bullet;
	public GameObject Explosion;
	public GameObject target;
	public float rate = 0.5f;
	public float t = 0f;
	
	
	void Start()
	{
				if (target == null) {
				
			target = GameObject.FindGameObjectWithTag("Player");
				}
		}

	
	
	
	// Update is called once per frame
	void Update () {
		
		
		// liikkuminen
		transform.LookAt (target.transform.position+Vector3.up);
		GetComponent<Rigidbody>().velocity = transform.forward * speed;
		
		
		// ampuminen
		t += Time.deltaTime; // aika kuluu
		
		
		
		if (t>1f/rate) {
			
			t = 0f;// nollataan aikalaskuri
			
			GameObject clone;
			GameObject clone2;
			
			// luodaan bulletista klooni
			clone = Instantiate(bullet,
			                    transform.position,
			                    transform.rotation) as GameObject;

			// luodaan bulletista klooni
			clone2 = Instantiate(bullet,
			                    transform.position,
			                    transform.rotation) as GameObject;

			
			// laitetaan vauhtia luodille
			clone.GetComponent<Rigidbody>().velocity = transform.forward * 20f;
			clone.transform.Translate(new Vector3(0,-1.5f,0));
			
			
			// klooni tuhotaan 3 sekunnin päästä
			Destroy (clone, 3.0f);
			Destroy (clone2, 3.0f);
		}
		
	}
	
	void OnCollisionEnter(Collision c)
	{
		if (c.gameObject.tag == "Player")

		AudioSource.PlayClipAtPoint (puspus, transform.position);
		if (c.gameObject.tag == "luoti") {
						hp --; // pienennetään eläimiä
		
						// jos hiparit loppuu, niin tuhoudutaan
						if (hp <= 0)
			{
				Destroy (gameObject);}

						GameManager.score += 5;
				}
		
	}
}

