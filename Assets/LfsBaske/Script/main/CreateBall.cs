using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBall : MonoBehaviour {
	private const int ballVelocity = 10;
	private const int notBallVelocity = 11;
	private Vector3 offset = new Vector3 (0, 7.8f, 0);
	private float count;
	public GameObject ball,notBall;
	public GameManager gameManager;
	// Use this for initialization
	void Start () {
		count = 0; 
	}
	// Update is called once per frame
	void Update () {
		if (gameManager.isStart) {
			if (count > 1.5f) {
				float x = 8;
				float y = Random.Range (5.0f, 7.0f);
				float z = Random.Range (-6.5f, 6.5f);

				if (Random.Range (1.0f, 100.0f) < 95) {
					GameObject newBall = Instantiate (ball, new Vector3 (x, y, z), Quaternion.identity);
					newBall.transform.LookAt (GameObject.FindWithTag ("Player").transform.position);
					newBall.GetComponent<Rigidbody> ().velocity = newBall.transform.forward * ballVelocity + offset;
				} else {
					GameObject newNotBall = Instantiate (notBall, new Vector3 (x, y, z), Quaternion.identity);
					newNotBall.transform.LookAt (GameObject.FindWithTag ("Player").transform.position + new Vector3(0,0,Random.Range(-1.5f,1.5f)));
					newNotBall.GetComponent<Rigidbody> ().velocity = newNotBall.transform.forward * notBallVelocity + offset;
				}
				count = 0;
			}
			count += Time.deltaTime;
		}
	}		
}
