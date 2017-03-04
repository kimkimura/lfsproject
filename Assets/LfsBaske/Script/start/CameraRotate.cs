using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour {
	private const float distance = 3;
	private float angle;
	public float yPos = 2;
	// Use this for initialization
	void Start () {
		angle = 0;
	}
	
	// Update is called once per frame
	void Update () {
		float x = Mathf.Cos (angle) * distance;
		float z = Mathf.Sin (angle) * distance;
		this.transform.position = new Vector3 (x, yPos, z);
		transform.LookAt (new Vector3 (0, 0, 0));
		angle += 1 * Time.deltaTime;
		if (angle > 360)
			angle = 0;
	}
}
