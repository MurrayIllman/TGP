using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleTrapActivate : MonoBehaviour {

	public bool CanDisable = false;

	public bool CanActivate = true;

	public float ActivateCD;

	private float NextActivate;

	InputController playerInput;
	private bool PlayerIsIn = false;
	private GameObject Player;

	private TripleTrap tt;

	// Use this for initialization
	void Start () {
		tt = gameObject.GetComponentInParent<TripleTrap> ();
		playerInput = GameManager.Instance.InputController;
	}

	void Update () {
		if (PlayerIsIn) {
			if (CanActivate == true && playerInput.Activate == true) {
				if (CanDisable == false) {
					CanDisable = true; // Only activate once.
					tt.ActivateTrigger(transform.parent.gameObject);
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
}
