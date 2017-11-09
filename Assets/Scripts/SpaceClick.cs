using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpaceClick : MonoBehaviour {


	private ChangeScene cs;
	// Use this for initialization

	public Canvas MainCanvas;
	public Button PlayBtn;
	public Button ExitBtn;


	private float Cooldown;
	private float ActivateTime;
	private float StartTime;
	private bool Started = false;

	public List<Button> buttons;


	// Update is called once per frame
	private int buttonCount = 0;
	// Use this for initialization
	void Awake() {

	}

	void Start () {
		cs = GetComponent<ChangeScene> ();
		Cooldown = 1.5f;
		SetColour (1, PlayBtn);
		buttons.Add (PlayBtn);
		buttons.Add (ExitBtn);
	}

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

	private void ResetButtons() {
		SetColour (0, PlayBtn);
		SetColour (0, ExitBtn);
	}

	public void Resume() {
		buttonCount = 0;
		buttons.Clear ();
		ResetButtons ();
	}

	private void MoveButton() {
		buttonSetColour ();
	}
	
	// Update is called once per frame
	void Update () {
//		if (Input.GetKeyDown(KeyCode.Space)) {
//			cs.ChangeToScene (1);
//		}
		if (Input.GetKeyDown(KeyCode.Space)) {
			if (Started == false) {
				Started = true;
				ActivateTime = Time.realtimeSinceStartup + Cooldown;
			}
		}
		if (Input.GetKey(KeyCode.Space)) {
			if (Started == true && Time.realtimeSinceStartup >= ActivateTime) {
				print ("working");
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
