using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitUI : MonoBehaviour {
	[SerializeField]
	private Camera cameraComponent;
	// Use this for initialization
	void Start () {
		cameraComponent = GetComponent<Camera> ();
		cameraComponent.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!cameraComponent.enabled)
			cameraComponent.enabled = true;
	}
}
