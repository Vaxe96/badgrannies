using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {
	
	public GameObject enemy;	// enemy
	public GameObject enemy2;
	public float rate = 0.05f;	// luomisnopeus
	public float t = 0f;		// ajastin
	public GameObject Player;
	public int luomisra = 15;
	public float aikaraja = 20f;

	void Start (){

				Player = GameObject.FindGameObjectWithTag ("Player");
		}


	// Update is called once per frame
	void Update () {

		t += Time.deltaTime; // aika kuluu
		aikaraja -= Time.deltaTime;
		if (aikaraja <0){
			aikaraja =20;
			luomisra = 15;
		}
		if (luomisra > 0 && t>1f/rate&&Vector3.Distance(transform.position,Player.transform.position)<100) {

			//teleporttaillaan satunnaiseen paikkaan

			Vector3 newpos = transform.position;
			newpos.x += Random.Range(-5,5);
			newpos.z += Random.Range(-5,5);
			luomisra --;


			
			t = 0f;// nollataan aikalaskuri
			

			
			// luodaan enemystä klooni
			GameObject clone;
			clone = Instantiate(enemy,
			            newpos,
			            transform.rotation) as GameObject;



		}
	}
}
