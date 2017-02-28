using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDestroy : MonoBehaviour {
	private float destroyTime;
	// Use this for initialization
	void Start () {
		destroyTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (destroyTime > 10)
			Destroy (this.gameObject);
		else
			destroyTime += Time.deltaTime;
	}
}
