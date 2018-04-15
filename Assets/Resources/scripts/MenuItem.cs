using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuItem : MonoBehaviour {

	public string sceneName;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown()
	{ 
		SceneManager.LoadScene (sceneName);
	}

	void OnMouseOver()
	{
		GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, .5f);
	}

	void OnMouseExit()
	{
		GetComponent<SpriteRenderer> ().color = Color.white;
	}
}
