using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBall : MonoBehaviour {
	private float count;
	public GameObject ball;
	// Use this for initialization
	void Start () {
		count = 0; 
	}
	// Update is called once per frame
	void Update () {
		if (count > 2) {
			float x = 8;
			float y = Random.Range (5.0f, 7.0f);
			float z = Random.Range (-7.5f,7.5f);
			GameObject newBall = Instantiate (ball,new Vector3(x,y,z),Quaternion.identity);
			newBall.transform.LookAt (GameObject.FindWithTag ("Player").transform.position);
			newBall.GetComponent<Rigidbody> ().velocity = newBall.transform.forward * 10 + new Vector3(0,7.8f,0);
			count = 0;
		}
		count += Time.deltaTime;
	}		
}
