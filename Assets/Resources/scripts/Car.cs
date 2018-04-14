using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour {

	public static Vector2[] positions = {
		new Vector2(-2.4f, -3.5f),
		new Vector2(-0.1f, -3.5f),
		new Vector2(2.35f, -3.5f)
	};

	[SerializeField]
	int positionIndex = 1;

	bool mutex;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		UpdatePosition ();
	}

	void Lock (){
		mutex = true;
		new WaitForSecondsIEnum (0.25f, delegate {
			mutex = false;
		}).Run (this);
	}

	void UpdatePosition () {
		if (!mutex)
			if (Input.GetAxis ("Horizontal") > 0 && positionIndex < positions.Length - 1) {
				positionIndex++;
				Lock ();
			} else if (Input.GetAxis ("Horizontal") < 0 && positionIndex > 0) {
				positionIndex--;
				Lock ();
			}
		transform.position = positions [positionIndex];
	}
}
