using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {

	public float Vertical;
	public float Horizontal;
	public Vector2 MouseInput;
	//public bool ActivatePC;
	public bool Activate;
	public bool Exit;

	void Update() {
		Vertical = Input.GetAxis ("Vertical");
		Horizontal = Input.GetAxis ("Horizontal");
		MouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
		//if (Application.platform == RuntimePlatform.WindowsPlayer) {
			//Activate = Input.GetButton("Fire1");
		Activate = Input.GetKey(KeyCode.Space);
		Exit = Input.GetKey (KeyCode.Escape);
			//print (Activate);
		//}else{
			//TouchTap = Input.GetTouch ();
			if (Input.touchCount > 0) {
				if (Input.GetTouch (0).phase == TouchPhase.Began) {
					Activate = true;
					//print (Activate);
				}
				if (Input.GetTouch (0).phase == TouchPhase.Ended) {
					Activate = false;
				}
			}
		//}
	}
}
