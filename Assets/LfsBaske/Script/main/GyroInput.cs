using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroInput : MonoBehaviour {
	// Use this for initialization
	void Start () {
		Input.gyro.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		
		Quaternion gyroInput = Input.gyro.attitude;
		gyroInput.x *= -1;
		gyroInput.y *= -1;
		this.transform.localRotation = Quaternion.Euler (90, 0, 0) * gyroInput;
		//Debug.Log (gyroInput);

	}
}
