using UnityEngine;
using System.Collections;

public class batman : MonoBehaviour {

	public float enemySpeed = 2.0f;

	// ampumisjutskat
	public GameObject bullet;
	public float rate = 1f;
	public float t = 0f;


	// sekoäly
	public float targetting_distance = 10f;
	public float dist_to_target = 9999f;
	public GameObject target;
	public Vector3 targetpos;

	// Use this for initialization
	void Start () {
	
	}


	
	// Update is called once per frame
	void Update () {

		Targetting ();
		Moving ();
		Shooting ();




	
	}

	void Targetting()
	{
		// jos kohdetta ei vielä ole löytynyt, niin etsitään
		if (target == null)
		{
			// etsitään kohde
			target = GameObject.FindGameObjectWithTag("Player");
			
			// lasketaan etäisyys
			dist_to_target = Vector3.Distance(transform.position, target.transform.position);
			
			// jos liian kaukana, niin unohdetaan
			if(dist_to_target > targetting_distance)
			{
				target = null;

				// mennään rändömiin sijaintiin
				dist_to_target = Vector3.Distance(transform.position, targetpos);
				if(dist_to_target < 3f || dist_to_target > targetting_distance)
				{
					targetpos.x = Random.Range (-targetting_distance,targetting_distance);
					targetpos.z = Random.Range (-targetting_distance,targetting_distance);
					targetpos += transform.position;
				}
			}
		}
		else// kohde on löytynyt ja se on tarpeeks lähellä
		{
			targetpos = target.transform.position;
			targetpos.y = transform.position.y;
		}
	}
	void Moving()
	{
		targetpos.y = transform.position.y;

		LookAtZ (gameObject,targetpos);

		//gameObject.transform.Rotate (new Vector3(0,0,-90f));
		
		// liikkuminen
		rigidbody.velocity = transform.forward * enemySpeed;

		gameObject.transform.Rotate (new Vector3(-90,0,0));
	}
	
	void Shooting()
	{
		// ei ammuta jos ei ole kohdetta tai luotia
		if (target == null || bullet == null)
			return;

		//ampuminen
		t += Time.deltaTime; // aika kuluu
		
		
		// ampuu
		if (t > 1f / rate) {
			
			t = 0f;// nollataan aikalaskuri
			
			GameObject clone;
			
			// luodaan bulletista klooni
			clone = Instantiate (bullet,
			                     transform.position,
			                     transform.rotation) as GameObject;
			
			// laitetaan vauhtia luodille
			clone.rigidbody2D.velocity = -transform.up * 20f;
			clone.transform.Translate(new Vector3(0, -0.7f, 0));
			
			//
			LookAtZ(clone, clone.transform.position + (Vector3)clone.rigidbody2D.velocity);
			
			// klooni tuhotaan 3 sekunnin päästä
			Destroy (clone, 2.0f);
		}
	}

	void LookAtZ(GameObject ob, Vector3 target_pos)
	{
		/*
		Vector3 dir = target_pos-ob.transform.position;
		dir.Normalize();
		
		Quaternion target_q = ob.transform.rotation;
		
		if(dir.x > 0f && dir.x > Mathf.Abs(dir.z))// oikeelle
			target_q = Quaternion.LookRotation(target_pos - ob.transform.position,Vector3.down);
		if(dir.x < 0f && dir.x < -Mathf.Abs(dir.z))// vasemmalle
			target_q = Quaternion.LookRotation(target_pos - ob.transform.position,Vector3.up);
		
		if(dir.z > 0f && dir.z > Mathf.Abs(dir.x))// ylös
			target_q = Quaternion.LookRotation(target_pos - ob.transform.position,Vector3.right);
		if(dir.z < 0f && dir.z < -Mathf.Abs(dir.x))// alas
			target_q = Quaternion.LookRotation(target_pos - ob.transform.position,Vector3.left);
		
		target_q.x=0;
		target_q.z=0;
		
		ob.transform.rotation = target_q;
		*/

		Vector3 targetPostition = new Vector3( target_pos.x, 
		                                      ob.transform.position.y, 
		                                      target_pos.z ) ;
		ob.transform.LookAt( targetPostition ) ;
	}
	
	void OnDrawGizmos()
	{
		Gizmos.DrawLine (transform.position,targetpos);
	}
}
