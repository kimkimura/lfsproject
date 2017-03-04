using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBall : MonoBehaviour {
	private const int ballVelocity = 10;
	private Vector3 offset = new Vector3 (0, 7.8f, 0);
	private float count;
	public GameObject ball;
	public GameManager gameManager;
	// Use this for initialization
	void Start () {
		count = 0; 
	}
	// Update is called once per frame
	void Update () {
		if (gameManager.isStart) {
			if (count > 1) {
				float x = 8;
				float y = Random.Range (5.0f, 7.0f);
				float z = Random.Range (-7.5f, 7.5f);
				GameObject newBall = Instantiate (ball, new Vector3 (x, y, z), Quaternion.identity);
				newBall.transform.LookAt (GameObject.FindWithTag ("Player").transform.position);
				newBall.GetComponent<Rigidbody> ().velocity = newBall.transform.forward * ballVelocity + offset;
				count = 0;
			}
			count += Time.deltaTime;
		}
	}		
}
