﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimSumCollision : MonoBehaviour {

	// Usage: First Ingredient + Second Ingredient = Third Ingredient
	string[,] makeList = { 
		{ "dough", "stuffing", "siumei" },
		{ "siumei", "steamer-basket", "siumei-many" },

		{ "dough", "pork", "chasiubao" },
		{ "chasiubao", "steamer-basket", "chasiubao-many" },

		{ "dough", "shrimp", "shrimp-dumpling" },
		{ "shrimp-dumpling", "steamer-basket", "shrimp-dumpling-many" }
	};
		
	public GameObject[] RawMaterials;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnRecreate() {
		for (int i = 0; i < RawMaterials.GetLength(0); i++){
			GameObject target = (GameObject)Instantiate (RawMaterials [i]);
			target.name = RawMaterials [i].name;
		}
	}

	void OnCollisionEnter (Collision col)
	{
		for (int i = 0; i < makeList.GetLength(0); i++) {
			if (col.gameObject.name == makeList[i, 0] || this.name == makeList[i, 0] || makeList[i, 0] == "")
				if (col.gameObject.name == makeList[i, 1] || col.gameObject.name == makeList[i, 1]) {

					Destroy (this.gameObject);

					if (makeList [i, 2] != "") {
						Destroy (col.gameObject);

						Vector3 loc = col.transform.position;

						GameObject target = (GameObject)Instantiate (Resources.Load ("prefab/" + makeList [i, 2]));
						target.transform.position = loc;
						target.name = makeList [i, 2];
					}

				}
		}
	}
}
