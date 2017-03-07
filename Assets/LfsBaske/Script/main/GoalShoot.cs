using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalShoot : MonoBehaviour {
	private Vector3 bestShoot = new Vector3(7f,16.5f,0);
	private Vector3 prevAcceleration;
	private bool isRunning,isDamageRunning;
	private bool isDamage;
	public Animation anim;
	public GyroInput gyro;
	public AudioSource audioSource;
	public AudioClip shoot,damage;
	// Use this for initialization
	void Start () {
		isDamage = false;
	}
	
	// Update is called once per frame
	void Update () {
		StartCoroutine ("Interval");
		if (isDamage) {
			StartCoroutine ("Damage");
			gyro.enabled = false;
			Debug.Log ("ダメージなう");
		}
	}
	void OnTriggerEnter(Collider col){
		if (!isDamage) {
			switch (col.gameObject.tag) {
			case "Ball":
				{
					if (heddingBall ()) {
						col.gameObject.layer = LayerMask.NameToLayer ("ToutchedBall");
						if (this.gameObject.tag == "DummyCol")
							col.gameObject.GetComponent<Rigidbody> ().velocity = this.transform.forward * Random.Range (15, 25);
						else if (this.gameObject.tag == "BestHitCol")
							col.gameObject.GetComponent<Rigidbody> ().velocity = bestShoot;
						audioSource.PlayOneShot (shoot);
						col.gameObject.layer = LayerMask.NameToLayer ("ToutchedBall");
					}
					break;
				}
			case "NotBall":
				{
					isDamage = true;
					anim.Play ();
					audioSource.PlayOneShot (damage);
					break;
				}
			default:
				break;
			}
		}
	}
	IEnumerator Interval(){
		if (isRunning)
			yield break;
		isRunning = true;
		yield return new WaitForSeconds (0.25f);
		prevAcceleration = Input.acceleration;
		isRunning = false;
	}
	IEnumerator Damage(){
		if (isDamageRunning)
			yield break;
		isDamageRunning = true;
		yield return new WaitForSeconds (1f);
		isDamage = false;
		isDamageRunning = false;
		gyro.enabled = true;

	}
	bool heddingBall(){
		if (Input.acceleration.z < prevAcceleration.z && Mathf.Abs (Input.acceleration.z - prevAcceleration.z) > 0.3f)
			return true;
		else
			return false;
	}
}
