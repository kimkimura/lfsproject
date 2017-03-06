using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Button : MonoBehaviour {
	public AudioSource audio;
	public AudioClip button;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void ReturnToTitle(){
		audio.PlayOneShot (button);
		SceneManager.LoadScene ("StartScene");
	}
}
