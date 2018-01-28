using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour {

	// Usage: First Ingredient + Second Ingredient = Third Ingredient
	string[,] makeList = { 
		{ "dough", "stuffing", "siumei" },
		{ "siumei", "steamer-basket", "siumei-many" },
		{ "siumei-many", "chat-balloon-1", "" },
		{ "siumei-many", "chat-balloon-2", "" }
	};


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}



	void OnTriggerEnter (Collider col)
	{
		for (int i = 0; i < makeList.GetLength(0); i++) {
			if (col.gameObject.name == makeList[i, 0] || this.name == makeList[i, 0])
			if (col.gameObject.name == makeList[i, 1] || col.gameObject.name == makeList[i, 1]) {

				Destroy (this.gameObject);
				Destroy (col.gameObject);

				if (makeList [i, 2] != "") {
					Vector3 loc = col.transform.position;

					GameObject target = (GameObject)Instantiate (Resources.Load ("prefab/" + makeList [i, 2]));
					target.transform.position = loc;
					target.name = makeList [i, 2];
				}

			}
		}
	}
}
