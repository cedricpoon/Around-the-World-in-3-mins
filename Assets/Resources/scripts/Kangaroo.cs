using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kangaroo : Marquee {

	[SerializeField]
	Sprite killed;

	bool isKilled;

	KangarooGameMaster master;

	public override void Start ()
	{
		base.Start ();

		master = GameObject.Find ("KangarooGameMaster").GetComponent<KangarooGameMaster> ();
	}

	void OnDestroy () {
		master.DismissKangaroo ();
	}

	public override void Update ()
	{
		if (!isKilled)
			base.Update ();

		// For auto destroying
		if (base.isShown && NextMarquee == null) {
			NextMarquee = this.gameObject;
		}
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.name == "car") {
			GetComponent<Collider2D> ().enabled = false;
			master.Hit ();
			isKilled = true;
			GetComponent<SpriteRenderer> ().sprite = killed;

			new WaitForSecondsIEnum (0.5f, delegate {
				Destroy (this.gameObject);
			}).Run (this);
		}
	}
}
