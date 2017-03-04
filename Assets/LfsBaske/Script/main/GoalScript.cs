using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
public class GoalScript : MonoBehaviour {
	public Text rightText,leftText;
	public GameManager gameManager;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		rightText.text = "Score:" + GameManager.score.ToString();
		leftText.text = "Score:" + GameManager.score.ToString();
	}
	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "Ball") {
			gameManager.Scoring (1);
			Destroy (col.gameObject);
		}
	}
}
