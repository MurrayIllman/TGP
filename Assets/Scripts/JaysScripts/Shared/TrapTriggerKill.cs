using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapTriggerKill : MonoBehaviour {

	public bool CanKill = true;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player" && CanKill == true) {
			Player player = other.GetComponent<Player> ();
			if (player != null) {
				player.Die ();
			}	
		}
	}
}
