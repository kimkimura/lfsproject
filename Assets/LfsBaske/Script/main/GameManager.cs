using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour {
	private const float time = 60;	//ゲーム制限時間
	private const float count = 10;	//スタートのカウントダウン時間
	[SerializeField]
	private float currentTime;		//現在の残り時間
	[SerializeField]
	private float countDown;		//現在のカウントダウン時間
	public bool isStart;			//ゲームがスタートしているかどうか
	[SerializeField]
	private bool isEnd;				//ゲームが終了したかどうか
	private bool isRunning;
	public static int score;		//得点（スコア）
	public GameObject rightCountDownText,leftCountDownText;
	public GameObject rightTimetext, leftTimetext;
	private Text rightTime,leftTime;
	private Text rightText,leftText;
	public AudioSource audio;
	public AudioClip timeCount,start,timeUp;
	// Use this for initialization
	void Start () {
		score = 0;
		rightTime = rightTimetext.GetComponent<Text> ();
		leftTime = leftTimetext.GetComponent<Text> ();
		rightText = rightCountDownText.GetComponent<Text> ();
		leftText = leftCountDownText.GetComponent<Text> ();
		currentTime = 0;
		isStart = false;
		isEnd = false;
		isRunning = false;
		StartCoroutine ("StartCountDown");
	}
	
	// Update is called once per frame
	void Update () {
		
		if (isStart) {
			currentTime -= Time.deltaTime;
			if (currentTime <= 0) {
				currentTime = 0;
				isStart = false;
				isEnd = true;
			}
			rightTime.text = "Time:" + ((int)currentTime).ToString ();
			leftTime.text = "Time:" + ((int)currentTime).ToString ();
		}
		if (isEnd) {
			StartCoroutine ("TimeUp");
		}
	}

	public void Scoring(int point){
		score += point;
	}
	IEnumerator StartCountDown(){
		countDown = count;
		rightTimetext.SetActive (false);
		leftTimetext.SetActive (false);
		rightCountDownText.SetActive (true);
		leftCountDownText.SetActive (true);
		while (countDown > 0) {
			rightText.text = "（ゴーグルを装着してください）\n" + countDown.ToString ();
			leftText.text = "（ゴーグルを装着してください）\n" + countDown.ToString ();
			audio.PlayOneShot (timeCount);
			yield return new WaitForSeconds (1);
			countDown--;
		}
		rightText.text = "Start!";
		leftText.text = "Start!";
		audio.PlayOneShot (start);
		yield return new WaitForSeconds (0.5f);
		currentTime = time;
		rightTime.text = "Time:" + currentTime.ToString ();
		leftTime.text = "Time:" + currentTime.ToString ();
		rightTimetext.SetActive (true);
		leftTimetext.SetActive (true);
		rightCountDownText.SetActive(false);
		leftCountDownText.SetActive(false);
		isStart = true;
	}
	IEnumerator TimeUp(){
		if(isRunning)
			yield break;
		isRunning = true;
		rightText.text = "TimeUp!\n（ゴーグルを外してください）";
		leftText.text = "TimeUp!\n（ゴーグルを外してください）";
		audio.PlayOneShot (timeUp);
		rightCountDownText.SetActive (true);
		leftCountDownText.SetActive (true);
		yield return new WaitForSeconds(5);

		SceneManager.LoadScene ("ResultScene");
	}
}
