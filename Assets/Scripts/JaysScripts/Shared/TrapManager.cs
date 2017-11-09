using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapManager : MonoBehaviour {

	[SerializeField]float cooldown; // Not used, but if trap resets
	[SerializeField]protected float canActivateWindow; // Window that you can trigger the trap upon being near it
	public float CanActivateWindow { get { return canActivateWindow; } set { canActivateWindow = value; } }

	public bool canActivate = true;
	private bool finalSetWindow = false; // If true then can't activate again
	private bool isInWindow = false;
	public bool IsInWindow{
		get {
			return isInWindow;
		}
		set {
			isInWindow = value;
		}
	}

	private Time m_NextActivate;
	public Time NextActivate{
		get {
			return m_NextActivate;
		}
		set {
			m_NextActivate = value;
		}
	}

	public virtual bool ActivateTrap() {
		if (canActivate == false || isInWindow == false) {
			return false;
		}
		canActivate = false;
		return true;


	//	canActivate = false;
		//if (Time.time < m_NextActivate) {
		//	return;
		//}

		//NextActivate = Time.time + Cooldown;

		//canActivate = false;
	}


	void setWindow(){
		IsInWindow = false;
	}

	public virtual void StartTiming(){
		if (finalSetWindow == false) {
			IsInWindow = true;
			finalSetWindow = true;
			GameManager.Instance.Timer.Add (setWindow, canActivateWindow);
		}
	}
		

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
