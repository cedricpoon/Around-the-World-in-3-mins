using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KangarooGameMaster : MonoBehaviour {

	[SerializeField]
	int noOfKangaroos = 1;

	int onScreenKangaroos;

	[SerializeField]
	GameObject kangaroo, overlay;

	[SerializeField]
	float offset, timeRemaining;

	float totalTime;

	[SerializeField]
	Text timeRef;

	WaitForSecondsIEnum waitTick;

	// Use this for initialization
	void Start () {
		totalTime = timeRemaining;
		OnChangeTimeRemaining (0);

		waitTick = new WaitForSecondsIEnum (1f, delegate {
			OnChangeTimeRemaining(-1);

			if (timeRemaining <= totalTime / 2) {
				noOfKangaroos = 2;
				timeRef.color = Color.red;
			}

			if (timeRemaining == 0) {
				timeRef.color = Color.green;
				EndGame();
			}
			else
				// Next Tick
				waitTick.Run(this);
		});
		waitTick.Run (this);
	}

	void EndGame() {
		Marquee.IsActive = false;

		new WaitForSecondsIEnum (1f, delegate {
			overlay.SetActive (true);
		}).Run (this);
	}
	
	// Update is called once per frame
	void Update () {
		GenerateKangaroo ();
	}

	void OnChangeTimeRemaining (int seconds) {
		timeRemaining += seconds;
		timeRef.text = timeRemaining.ToString ();	
	}

	public void Hit () {
		OnChangeTimeRemaining (+10 /* Killing kangaroo */);
	}

	public void DismissKangaroo () {
		onScreenKangaroos--;
	}

	void Reshuffle(float[] f)
	{
		for (int t = 0; t < f.Length; t++ )
		{
			float tmp = f[t];
			int r = Random.Range(t, f.Length);
			f[t] = f[r];
			f[r] = tmp;
		}
	}

	void GenerateKangaroo () {
		if (onScreenKangaroos == 0) {
			float[] xs = new float[Car.positions.Length];
			for (int i = 0; i < Car.positions.Length; i++)
				xs [i] = Car.positions [i].x;
			Reshuffle (xs);

			for (int i = 0; i < noOfKangaroos; i++) {
				((GameObject)Instantiate (kangaroo)).transform.position = new Vector3 (
					xs[i],
					offset
				);
				onScreenKangaroos++;
			}
		}
	}
}
