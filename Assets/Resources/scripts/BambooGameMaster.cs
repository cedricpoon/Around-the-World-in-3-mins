using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BambooGameMaster : MonoBehaviour {

	int noOfPicked;

	[SerializeField]
	int totalNo;

	[SerializeField]
	Text totalRef, noRef;

	[SerializeField]
	Vector2 startPosition;

	public float minInterval, maxInterval, minSpeed, maxSpeed;

	public GameObject[] items;

	WaitForSecondsIEnum waitTick;

	// Use this for initialization
	void Start () {
		totalRef.text = "/ " + totalNo;
		UpdatePickedNumber (0);

		waitTick = new WaitForSecondsIEnum (0, delegate {
			GameObject item = Instantiate <GameObject>(items[Random.Range(0, items.Length)]);
			item.transform.position = startPosition;

			item.GetComponent<FlowItem>().RelativeSpeed = Random.Range(minSpeed, maxSpeed);

			waitTick.SetSeconds(Random.Range(minInterval, maxInterval)).Run(this);
		});

		waitTick.Run (this);
	}

	public void UpdatePickedNumber (int number) {
		if (number > 0 && noOfPicked + number <= totalNo || number < 0 && noOfPicked - number >= 0) {
			noOfPicked += number;
			noRef.text = noOfPicked.ToString ();

			if (number > 0) {
				noRef.color = Color.green;
				new WaitForSecondsIEnum (0.5f, delegate {
					noRef.color = Color.black;
				}).Run (this);
			} else if (number < 0) {
				noRef.color = Color.red;
				new WaitForSecondsIEnum (0.5f, delegate {
					noRef.color = Color.black;
				}).Run (this);
			}

			if (noOfPicked == totalNo)
				EndGame ();
		}
	}

	void EndGame () {
		
	}

	// Update is called once per frame
	void Update () {
		
	}
}
