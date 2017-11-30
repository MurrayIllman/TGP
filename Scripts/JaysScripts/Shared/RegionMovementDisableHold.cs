using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegionMovementDisableHold : MonoBehaviour {

	public bool CanDisable = false;

	public bool CanActivate = true;

	public float ActivateCD;

	private float NextActivate;

	private PlatformObstacle pfo;

	InputController playerInput;

	// Use this for initialization
	void Awake () {
		
	}

	void Start () {
		pfo = GetComponentInParent<PlatformObstacle> ();
		playerInput = GameManager.Instance.InputController;
	}

	private bool CheckCD() {
		if (Time.time >= NextActivate) {
			NextActivate = Time.time + ActivateCD;
			return true;
		}
		return false;
	}
	
	// Update is called once per frame

	private bool PlayerIsIn = false;
	private GameObject Player;
	void Update () {
		if (PlayerIsIn) {
			if (CanActivate == true && playerInput.Activate == true) {
				if (CanDisable == false) {
					CanDisable = true; // Only activate once.
					PlayerMovement pm = Player.GetComponent<PlayerMovement>();
					if (pm != null) {
						pm.DisableMovement ();
						pm.canFall = false;
						pfo.ReadyToMove (Player);
					}
				}
			}
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
			PlayerIsIn = true;
			Player = other.gameObject;
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.gameObject.tag == "Player") {
			PlayerIsIn = false;
			Player = null;
		}
	}
}
