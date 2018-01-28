using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class customer : MonoBehaviour {

	string[] rawMaterials = { 
		"dough",
		"stuffing",
		"steamer-basket"
	};

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnDestroy () {
		for (int i = 0; i < rawMaterials.GetLength(0); i++){
			GameObject target = (GameObject)Instantiate (Resources.Load ("prefab/" + rawMaterials [i]));
			target.name = rawMaterials [i];
		}
	}
}
