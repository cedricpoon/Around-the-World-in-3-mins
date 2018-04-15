using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickedIndicator : MonoBehaviour {

	[SerializeField]
	Sprite correct;

	[SerializeField]
	Sprite correctIcon, wrongIcon, putIcon;

	[SerializeField]
	float timeout = 0.5f;

	[SerializeField]
	BambooGameMaster master;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Flicker () {
		this.GetComponent<SpriteRenderer> ().enabled = true;
		transform.Find ("icon").GetComponent<SpriteRenderer> ().enabled = true;

		new WaitForSecondsIEnum (timeout, delegate {
			transform.Find ("icon").GetComponent<SpriteRenderer> ().enabled = false;
			this.GetComponent<SpriteRenderer> ().enabled = false;
		}).Run (this);
	}

	public void OnInput () {
		transform.Find ("icon").GetComponent<SpriteRenderer>().sprite = putIcon;
		Flicker ();
		master.UpdatePickedNumber (1);
	}

	public void OnCheck (Sprite picked) {
		if (picked == correct) {
			transform.Find ("icon").GetComponent<SpriteRenderer> ().sprite = correctIcon;
			Flicker ();
		} else {
			transform.Find ("icon").GetComponent<SpriteRenderer> ().sprite = wrongIcon;
			Flicker ();
		}
	}
}
