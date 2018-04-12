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
	Customer[] customers;

	public GameObject overlay;

	public void UpdateScoreBy (int score) {
		if (!(this.score <= 0 && score < 0)){
			this.score += score;
			scoreText.text = this.score.ToString();
		}

		if (this.score >= maxScore) {
			foreach (Customer c in customers)
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
