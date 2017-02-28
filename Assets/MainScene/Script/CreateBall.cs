using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBall : MonoBehaviour {
	private float count;
	public GameObject ball;
	public Transform cameraTrans;
	private bool ballShoot;
	// Use this for initialization
	void Start () {
		count = 0; 
		ballShoot = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!ballShoot) {
			accelerationShoot ();
		} else {
			ShootCoolDown ();
		}
		
	}

	void ShootCoolDown(){
		if (count > 0.15f) {
			ballShoot = false;
			count = 0;
		} else {
			count += Time.deltaTime;
		}
	}

	void accelerationShoot(){
		if (Input.acceleration.x > 0.25f || Input.acceleration.y > 0.25f) {
			GameObject ballObj = Instantiate (ball, cameraTrans.position, cameraTrans.localRotation);
			Rigidbody ballRig = ballObj.GetComponent<Rigidbody> ();
			ballRig.velocity = new Vector3 (0, 0, 0);
			Quaternion shootVector = ballObj.transform.localRotation;
			//加速度センサーの入力の強さに応じてボールの射出速度を変化
			/*
			float acl = Mathf.Max (Input.acceleration.x, Input.acceleration.y, Input.acceleration.z);
			shootVector.x *=  2f;
			shootVector.y *=  2f;
			shootVector.z *=  2f;
			ballRig.velocity = ballObj.transform.forward  * acl * 10;
			*/
			ballRig.velocity = ballObj.transform.forward * 30;
			ballShoot = true;
		}
	}
}
