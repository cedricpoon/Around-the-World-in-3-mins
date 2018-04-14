using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marquee : MonoBehaviour {

	public static bool IsActive = true;

	public float RelativeSpeed;

	[SerializeField]
	GameObject[] MarqueeList;

	public GameObject NextMarquee;

	public bool isShown {
		get {
			return GetComponent<Renderer> ().isVisible;
		}
	}

	// Use this for initialization
	public virtual void Start () {

	}
	
	// Update is called once per frame
	public virtual void Update () {
		if (IsActive) {
			// Actual rolling
			transform.position -= new Vector3 (0, RelativeSpeed);

			if (isShown && NextMarquee == null && MarqueeList.Length > 0)
				GenerateNext ();
			if (!isShown && NextMarquee != null)
				Destroy (gameObject);
		}
	}

	void GenerateNext () {
		// Generate a for next marquee
		NextMarquee = (GameObject)Instantiate(MarqueeList [Random.Range (0, MarqueeList.Length)]);
		NextMarquee.name = this.name;

		// Stick to top
		NextMarquee.transform.position = new Vector3 (
			transform.position.x, 
			transform.position.y + (
				GetComponent<SpriteRenderer>().sprite.bounds.size.y *
				transform.localScale.y
			)
		);

		// Copy parameters
		NextMarquee.GetComponent<Marquee>().RelativeSpeed = RelativeSpeed;
	}
}
