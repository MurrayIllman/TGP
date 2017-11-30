using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISelector : MonoBehaviour {

	public Canvas MainCanvas;


	private float Cooldown;
	private float ActivateTime;
	private float StartTime;
	private bool Started = false;

	private GameManagerWorld gmw;

	public List<Button> buttons;

	InputController playerInput;
	// Use this for initialization
	void Awake() {
		
	}
	void Start () {
		Cooldown = 1.5f;
		gmw = GetComponent<GameManagerWorld> ();
		playerInput = GameManager.Instance.InputController;
	}

	// Update is called once per frame
	private int buttonCount = 0;

	private void SetColour(int mode, Button btn) {
		if (mode == 0) {
			btn.GetComponent<Image>().color = new Color (1, 1 ,1);
		}else{
			btn.GetComponent<Image>().color = new Color (147/255, 255/255 ,105/255);
		}

	}

	private void buttonClick() {
		for (int i = 0; i < buttons.Count; i++) {
			if (buttonCount == i) {
				buttons [i].onClick.Invoke ();
			}
		}
		Started = false;
	}

	private void buttonSetColour() {
		for (int i = 0; i < buttons.Count; i++) {
			if (buttonCount == i) {
				SetColour (1, buttons [i]);
			}else{
				SetColour(0, buttons[i]);
			}
		}
	}

	public void Pause(int mode) {
		if (mode == 0) {
			SetColour (1, gmw.ResumeBtn);
			buttons.Add (gmw.ResumeBtn);
			buttons.Add (gmw.PlayBtn);
			buttons.Add (gmw.BackMenuBtn);
		}else if (mode == 1) {
			SetColour (1, gmw.PlayBtn);
			buttons.Add (gmw.PlayBtn);
			buttons.Add (gmw.BackMenuBtn);
		}
	}

	private void ResetButtons() {
		SetColour (0, gmw.PlayBtn);
		SetColour (0, gmw.ResumeBtn);
		SetColour (0, gmw.BackMenuBtn);
	}

	public void Resume() {
		buttonCount = 0;
		buttons.Clear ();
		ResetButtons ();

	}

	private void MoveButton() {
		buttonSetColour ();
	}

	void Update () {
		if (gmw.Paused && (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.OSXPlayer)) {
			if (Input.GetKeyDown(KeyCode.Space)) {
				if (Started == false) {
					Started = true;
					ActivateTime = Time.realtimeSinceStartup + Cooldown;
				}
			}
			if (Input.GetKey(KeyCode.Space)) {
				if (Started == true && Time.realtimeSinceStartup >= ActivateTime) {
					buttonClick ();
					Started = false;
				}
			}
			if (Input.GetKeyUp(KeyCode.Space)) {
				if (Started == true) {
					Started = false;
					if (Time.realtimeSinceStartup >= ActivateTime) {
						//Press
						//buttonClick ();
					} else {
						buttonCount = buttonCount + 1;
						if (buttonCount > buttons.Count - 1) {
							buttonCount = 0;
						}
						MoveButton ();
					}
				}
			}
		}
	}
}
