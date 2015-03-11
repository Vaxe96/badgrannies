using UnityEngine;
using System.Collections;

public class ampuminen : MonoBehaviour {
	
	public GameObject bullet;
	public float rate = 10f;
	public float t = 0f;
	
	
	
	// Update is called once per frame
	void Update () {
		
		
		t += Time.deltaTime; // aika kuluu
		
		
		// speissistä ampuu
		if (Input.GetMouseButton(0) && t>1f/rate) {
			
			t = 0f;// nollataan aikalaskuri
			
			GameObject clone;
			
			// luodaan bulletista klooni
			clone = Instantiate(bullet,
			                    transform.position,
			                    transform.rotation) as GameObject;
			
			// laitetaan vauhtia luodille
			clone.GetComponent<Rigidbody>().velocity = -transform.right * 20f;
			
			
			// klooni tuhotaan 3 sekunnin päästä
			Destroy (clone, 3.0f);
			
		}
		
		
	}
}

	
