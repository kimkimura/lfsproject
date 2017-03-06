using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyBGM : MonoBehaviour {
	public GameObject bgm;
	// Use this for initialization
	void Start () {
		GameObject find = GameObject.FindWithTag ("BGM");
		if (find != null)
			Destroy (find);
		GameObject obj = Instantiate (bgm);
		DontDestroyOnLoad (obj);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
