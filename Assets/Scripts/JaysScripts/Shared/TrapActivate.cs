using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapActivate : MonoBehaviour {
	//Attach to each Obstacle / Interactable Trap

	[SerializeField]TrapManager trapCode; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//if (GameManager.Instance.InputController.Activate) {
		//	trapCode.ActivateTrap ();
		//}

	}

	public void Activate(){
		trapCode.ActivateTrap ();
	}

	public void SetTiming(){
		trapCode.StartTiming ();
	}

}
