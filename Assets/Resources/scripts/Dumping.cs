using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dumping : MonoBehaviour {

	public DimSumGameMaster master;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter (Collision col) {
		col.gameObject.GetComponent<DimSumCollision> ().OnRecreate ();
		master.UpdateScoreBy (-10 /* Cost of dumping into rubbish bin */);
	}
}
