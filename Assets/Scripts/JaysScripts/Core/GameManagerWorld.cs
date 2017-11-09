using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerWorld : MonoBehaviour {

	public Canvas MainCanvas;
	public Button PlayBtn;
	public Button ResumeBtn;
	public Button BackMenuBtn;
	public Button IOSMenu;

	public Player player;

	private PlayerMovement pMovement;

	public bool Paused;

	InputController playerInput;

	private UISelector UISel;

	// Use this for initialization
	void Start () {
		PlayBtn.gameObject.SetActive(false);
		BackMenuBtn.gameObject.SetActive(false);
		ResumeBtn.gameObject.SetActive(false);
		player = GameManager.Instance.LocalPlayer;
		pMovement = player.GetComponent<PlayerMovement> ();
		playerInput = GameManager.Instance.InputController;
		UISel = GetComponent<UISelector> ();
		if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer) {
			IOSMenu.gameObject.SetActive(true);
		}
	}

	public void EnableMenu() {
		PlayBtn.gameObject.SetActive(true);
		BackMenuBtn.gameObject.SetActive(true);
		Time.timeScale = 0;
		Paused = true;
		UISel.Pause (1);
	}

	public void ClickPlayAgain() {
		PlayBtn.gameObject.SetActive(false);
		BackMenuBtn.gameObject.SetActive(false);
		ResumeBtn.gameObject.SetActive(false);
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		Time.timeScale = 1;
		Paused = false;
		UISel.Resume ();
	}

	public void ClickBackToMenu() {
		//MainCanvas.enabled = false;
		PlayBtn.gameObject.SetActive(false);
		BackMenuBtn.gameObject.SetActive(false);
		ResumeBtn.gameObject.SetActive(false);
		Time.timeScale = 1;
		Paused = false;
		UISel.Resume ();
		//Load start scene
		//SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}

	public void ClickResume() {
		//MainCanvas.enabled = false;
		ResumeBtn.gameObject.SetActive(false);
		PlayBtn.gameObject.SetActive(false);
		BackMenuBtn.gameObject.SetActive(false);
		Time.timeScale = 1;
		Paused = false;
		UISel.Resume ();
	}

	public void PauseScreen() {
		ResumeBtn.gameObject.SetActive(true);
		PlayBtn.gameObject.SetActive(true);
		BackMenuBtn.gameObject.SetActive(true);
		//MainCanvas.enabled = true;
		Time.timeScale = 0;
		Paused = true;
		UISel.Pause (0);
	}
	
	// Update is called once per frame
	private float NextActivate;
	private float Cooldown = 3;
	private bool StartPause = false;
	void Update () {
		if (playerInput.Exit && Paused == false) {
			PauseScreen ();
		}
		if (player.Dead && Paused == false) {
			EnableMenu ();
		}
		if (pMovement.canMove == true && Paused == false) {
			if (Input.GetKeyDown(KeyCode.Space)) {
				if (StartPause == false) {
					StartPause = true;
					NextActivate = Time.time + Cooldown;
				}
			}
			if (Input.GetKey(KeyCode.Space)) {
				if (StartPause == true && Time.time >= NextActivate) { 
					StartPause = false;
					PauseScreen ();
				}
			}
			if (Input.GetKeyUp(KeyCode.Space)) {
				StartPause = false;
			}
		}
	}
}
