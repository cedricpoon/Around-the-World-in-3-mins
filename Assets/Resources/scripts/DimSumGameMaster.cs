using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DimSumGameMaster : MonoBehaviour {

	int score;

	[SerializeField]
	Text scoreText;

	[SerializeField]
	int maxScore;

	[SerializeField]
	CustomerBehaviour[] customers;

	public GameObject overlay;

	public void UpdateScoreBy (int score) {
		if (!(this.score <= 0 && score < 0)){
			this.score += score;

			if (score > 0) {
				scoreText.color = Color.green;
				new WaitForSecondsIEnum (1f, delegate(object[] objects) {
					scoreText.color = Color.black;
				}).Run (this);
			} else {
				scoreText.color = Color.red;
				new WaitForSecondsIEnum (1f, delegate(object[] objects) {
					scoreText.color = Color.black;
				}).Run (this);
			}

			scoreText.text = this.score.ToString();
		}

		if (this.score >= maxScore) {
			foreach (CustomerBehaviour c in customers)
				c.OnFull ();
			
			new WaitForSecondsIEnum (1f, delegate(object[] objects) {
				OnGoodToKnow ();
			}).Run (this);
		}
	}

	void OnGoodToKnow () {
		overlay.SetActive (true);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
