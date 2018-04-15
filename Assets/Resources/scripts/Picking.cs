using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Picking : MonoBehaviour {

	GameObject collided;

	public Sprite PickedItem;

	[SerializeField]
	PickedIndicator dialog;
	[SerializeField]
	GameObject bowl;
	[SerializeField]
	Sprite picked, unpicked;

	// Use this for initialization
	void Start () {
		
	}

	void PickUp () {
		SpriteRenderer picked = this.transform.Find ("picked").GetComponent<SpriteRenderer> ();
		picked.sprite = collided.GetComponent<FlowItem> ().AfterPicking;
		picked.enabled = true;
		PickedItem = picked.sprite;
	}

	void PutDown () {
		SpriteRenderer picked = this.transform.Find ("picked").GetComponent<SpriteRenderer> ();
		PickedItem = null;
		picked.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis ("Fire1") > 0 && collided != null && collided != bowl && PickedItem == null) {
			PickUp ();
			dialog.OnCheck (PickedItem);
			Destroy (collided);
			collided = null;
		}
		if (Input.GetAxis ("Fire1") == 0 && PickedItem != null) {
			PutDown ();
		}

		if (Input.GetAxis ("Fire1") == 0) {
			GetComponent<SpriteRenderer> ().sprite = unpicked;
		} else {
			GetComponent<SpriteRenderer> ().sprite = picked;
		}
	}

	void OnTriggerEnter2D(Collider2D col) {
		collided = col.gameObject;
	}

	void OnTriggerExit2D(Collider2D col) {
		collided = null;
	}
}
