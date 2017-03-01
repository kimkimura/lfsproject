using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalShoot : MonoBehaviour {
	private Vector3 bestShoot = new Vector3(7f,16.5f,0);
	private float prevAccelerationZ;
	private bool isRunning;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		StartCoroutine ("Interval");
	}
	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Ball") {
			if(Input.acceleration.z < prevAccelerationZ && Mathf.Abs(Input.acceleration.z - prevAccelerationZ) > 0.5f)
				col.gameObject.GetComponent<Rigidbody> ().velocity = bestShoot;
		}
	}
	IEnumerator Interval(){
		if (isRunning)
			yield break;
		isRunning = true;
		yield return new WaitForSeconds (0.25f);
		prevAccelerationZ = Input.acceleration.z;
		isRunning = false;
	}
}
