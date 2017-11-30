using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Disables movement upon getting near region
public class RegionMovementDisable : MonoBehaviour {

	public bool CanDisable = false;

	private PlatformObstacle pfo;

	// Use this for initialization
	void Start () {
		pfo = GetComponentInParent<PlatformObstacle> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
			if (CanDisable == false) {
				CanDisable = true; // Only activate once.
				PlayerMovement pm = other.gameObject.GetComponent<PlayerMovement>();
				if (pm != null) {
					pm.DisableMovement ();
					pfo.ReadyToMove (other.gameObject);
				}
			}
		}
	}
}
