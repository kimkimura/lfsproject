using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalShoot : MonoBehaviour {
	private float prevAccelerationZ;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider col){
		if(Input.acceleration.z < prevAccelerationZ && Mathf.Abs(Input.acceleration.z - prevAccelerationZ) > 0.4f)
			col.gameObject.GetComponent<Rigidbody> ().velocity = this.transform.forward * Random.Range(15,25);
		col.gameObject.layer = LayerMask.NameToLayer("ToutchedBall");
	}
}
