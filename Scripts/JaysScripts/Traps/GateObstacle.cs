using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GateObstacle : TrapManager {

	public GameObject MoveObject;

	public Canvas canvas;
	public Text overText;
	public Text underText;
	public Text overTimerText;
	public Text underTimerText;

	private bool GoGoGo = false;
	private bool DontMove = false;
	public bool CanDamage = true;
	public float MoveTime;
	public TrapTriggerKill killplz;

	private bool startedTrap;
	private float ActivateTimeClone;

	public override bool ActivateTrap(){
		bool Trigger = base.ActivateTrap ();
		if (Trigger == true) {
			GoGoGo = true;
		}
		return true;
	}

	public override void StartTiming(){
		base.StartTiming();
		startedTrap = true;
	}

	private IEnumerator WaitAndMove(float delayTime){
		yield return new WaitForSeconds (delayTime); // start at time X
		float startTime = Time.time; // Time.time contains current frame time, so remember starting point
		Vector3 StartPos = MoveObject.transform.position;
		Vector3 EndPos = StartPos + new Vector3 (0, 30, 0);
		while (Time.time - startTime <= 1) { // until one second passed
			transform.position = Vector3.Lerp (StartPos, EndPos, Time.time - startTime); // lerp from A to B in one second
			yield return null; // wait for next frame
		}
	}

	void Start(){
		killplz = transform.Find ("ObstacleTrigger").GetComponent<TrapTriggerKill> ();
		if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer) {
			overText.text = "Touch";
			underText.text = "Touch";
		}
		overTimerText.text = CanActivateWindow.ToString ("0.0");
		underTimerText.text = CanActivateWindow.ToString ("0.0");
		ActivateTimeClone = CanActivateWindow;
	}

	void Update(){
		if (GoGoGo == true && DontMove == false) {
			//MoveObject.transform.position = Mathf.Lerp (MoveObject.transform.position, MoveObject.transform.position + new Vector3 (0, 30, 0), 1f);
			//StartCoroutine(WaitAndMove(0f));
			DontMove = true;
			Vector3 StartPos = MoveObject.transform.position;
			Vector3 EndPos = StartPos + new Vector3 (0, 30, 0);
			GameManager.Instance.MoveToPositionInTime.MoveToPositionWithObjectWrapper(MoveObject, EndPos, MoveTime);
			CanDamage = false;
			if (killplz != null) {
				killplz.CanKill = CanDamage;
			}
			GoGoGo = false;
		}
		if (startedTrap && ActivateTimeClone > 0) {
			ActivateTimeClone -= Time.deltaTime;
			overTimerText.text = ActivateTimeClone.ToString ("0.0");
			underTimerText.text = ActivateTimeClone.ToString ("0.0");
		}
		//if (CanDamage) { // Checkif collide
		//	Player plrCode = GameManager.Instance.LocalPlayer.GetComponent<Player> ();
		//	if (plrCode) { // if the player script exists
		//		plrCode.Die();
		//	}
		//}
	}
}
