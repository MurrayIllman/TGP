using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BestTime : MonoBehaviour {

	public Text timerText;
	private float startTime;
	public float t;
	public Text highTime;

	// Use this for initialization
	void Start () {
		startTime = Time.time;
		highTime.text = PlayerPrefs.GetFloat("Longestrun", 0).ToString("f2");
	}
	
	// Update is called once per frame
	void Update () {
		t = Time.time - startTime;

		string minutes = ((int)t / 60).ToString ();
		string seconds = (t % 60).ToString ("f2");

		timerText.text = minutes + ":" + seconds;
	}
}
