using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bowl : MonoBehaviour {

	[SerializeField]
	Picking pick;

	[SerializeField]
	Sprite target;

	[SerializeField]
	PickedIndicator pickInd;

	Collider2D collided;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (collided != null && Input.GetAxis("Fire1") == 0) {
			pickInd.OnInput ();
			collided = null;
		}
	}

	void OnTriggerStay2D (Collider2D col) {
		collided = null;
		if (pick.PickedItem == target) {
			collided = col;
		}
	}

	void OnTriggerExit2D (Collider2D col) {
		collided = null;
	}
}
