using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
public class GoalScript : MonoBehaviour {
	public Text rightText,leftText;
	static int Score = 0;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		rightText.text = "Score:" + Score;
		leftText.text = "Score:" + Score;
	}
	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "Ball") {
			Score += 1;
			Destroy (col.gameObject);
		}
	}
}
