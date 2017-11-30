using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(MoveController))]
public class Player : MonoBehaviour {

	private float NextActivate;
	public float Cooldown = 0.1f;
	public float rayLength;
	public bool Dead;

	public LayerMask layerMaskDown;

	private GameObject detectedObject;
	private PlayerMovement playerMovement;

	private bool Falling = false;

	//private MoveController m_MoveController;
	//public MoveController MoveController {
	//	get {
	//		if (m_MoveController == null) {
	//			m_MoveController = GetComponent<MoveController> ();
	//		}
	//		return m_MoveController;
	//	}
	//}

	InputController playerInput;

	void Awake() {
		playerInput = GameManager.Instance.InputController;
		GameManager.Instance.LocalPlayer = this;
		playerMovement = GetComponent<PlayerMovement> ();
	}

	// Update is called once per frame

	private void StartFall() {
		playerMovement.canFall = true;
		Invoke ("StopMovementWait", 6f);
	}

	private void StopMovementWait() {
		playerMovement.DisableMovement ();
	}

	private void RaycastDownCheck() {
		Ray ray2 = new Ray (transform.position, -Vector3.up);
		RaycastHit hit2;
		Debug.DrawRay (ray2.origin, ray2.direction * rayLength, Color.green);
		if (Physics.Raycast (ray2, out hit2, 1f, layerMaskDown)) {
			
		}else{
			if (Falling == false) {
				Falling = true;
				Invoke ("StartFall", 0.3f);
			}
		}
	}

	void Update () {
		RaycastDownCheck ();
		Ray ray = new Ray (transform.position, transform.right);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit, rayLength)) {
			//print(hit.collider.gameObject.name)
			detectedObject = hit.collider.gameObject;
		}else{
			detectedObject = null;
		}
		Debug.DrawRay (ray.origin, ray.direction * rayLength, Color.green);
		if (detectedObject != null) {
			TrapActivate trapActivate = detectedObject.GetComponentInParent<TrapActivate> ();
			if (trapActivate != null) {
				trapActivate.SetTiming ();
				if ((Input.GetKeyDown(KeyCode.Space) || Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer && playerInput.Activate == true) && Time.time > NextActivate) {	
					NextActivate = Time.time + Cooldown;
					if (detectedObject.tag == "ObstacleTrigger") {
						trapActivate.Activate ();
						//GameObject foundObjParent = detectedObject.GetComponentInParent
						//Ray ray2 = Camera.main.ScreenPointToRay(Input.mousePosition);
						//RaycastHit hit2;
						//if (Physics.Raycast(ray2, out hit2, Mathf.Infinity)){
							// the object identified by hit.transform was clicked
							// do whatever you want
							//if (hit2.transform.name == "ObjectClick" || hit2.transform.CompareTag("ClickTag")) {
							//	trapActivate.Activate (); // Object reference not set to instance of an object. Search parent for code.
							//}
						
						//}

					}
				}
			}
		}
	}

	public void Die(){
		print ("Player ded");
		Dead = true;
		playerMovement.DisableMovement ();
		playerMovement.canFall = false;
		// show menu
	}

}
