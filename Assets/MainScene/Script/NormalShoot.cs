using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalShoot : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider col){
		col.gameObject.GetComponent<Rigidbody> ().velocity = this.transform.forward * Random.Range(15,25);
	}
}
