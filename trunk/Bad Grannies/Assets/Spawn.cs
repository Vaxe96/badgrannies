﻿using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {
	
	public GameObject enemy;	// enemy
	public GameObject enemy2;
	public float rate = 1f;		// luomisnopeus
	public float t = 0f;		// ajastin


	// Update is called once per frame
	void Update () {

		t += Time.deltaTime; // aika kuluu
		
		if (t>1f/rate) {

			// teleporttaillaan satunnaiseen paikkaan
			/*
			Vector3 newpos = transform.position;
			newpos.x = Random.Range(-5,5);
			transform.position = newpos;
*/


			
			t = 0f;// nollataan aikalaskuri
			

			
			// luodaan enemystä klooni
			GameObject clone;
			clone = Instantiate(enemy,
			            transform.position,
			            transform.rotation) as GameObject;



		}
	}
}