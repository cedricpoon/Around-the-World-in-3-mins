using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour {

	public GameObject[] typeOfDimSums;

	[SerializeField]
	DimSumGameMaster master;

	GameObject currentDimSum;

	[SerializeField]
	Sprite wrong;

	[SerializeField]
	Sprite right;

	[SerializeField]
	Sprite full;

	// Use this for initialization
	void Start () {
		ShowUp ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.name == currentDimSum.name) {

			transform.Find("wishlist").GetComponent<SpriteRenderer> ().sprite = right;
			col.transform.GetComponent<DimSumCollision> ().OnRecreate ();

			new WaitForSecondsIEnum (1.2f, delegate(object[] objects) {
				MuteDown ();
			}).Run (this);

			master.UpdateScoreBy (10 /* Add 10 marks for correct dim sum */);

			Destroy (col.gameObject);
		} else {

			transform.Find("wishlist").GetComponent<SpriteRenderer> ().sprite = wrong;
			GetComponent<Collider> ().enabled = false;

			new WaitForSecondsIEnum (3, delegate(object[] objects) {
				ShowUp ();
			}).Run (this);

			master.UpdateScoreBy (-5 /* Minus 10 marks for wrong or incompleted dim sum */);
		}
	}

	public void OnFull() {
		StopAllCoroutines ();
		ShowUp ();
		transform.Find("wishlist").GetComponent<SpriteRenderer> ().sprite = full;
		GetComponent<Collider> ().enabled = false;
	}

	void ShowUp() {
		GetComponent<SpriteRenderer> ().enabled = true;
		transform.Find("wishlist").GetComponent<SpriteRenderer> ().enabled = true;
		GetComponent<Collider> ().enabled = true;

		currentDimSum = typeOfDimSums[Random.Range (0, typeOfDimSums.Length)];

		transform.Find("wishlist").GetComponent<SpriteRenderer> ().sprite = currentDimSum.GetComponent<SpriteRenderer> ().sprite;
	}

	void MuteDown() {
		GetComponent<SpriteRenderer> ().enabled = false;
		transform.Find("wishlist").GetComponent<SpriteRenderer> ().enabled = false;
		GetComponent<Collider> ().enabled = false;

		new WaitForSecondsIEnum (3, delegate(object[] objects) {
			ShowUp ();
		}).Run (this);
	}
}
