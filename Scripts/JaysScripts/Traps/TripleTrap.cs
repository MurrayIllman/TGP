using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleTrap : MonoBehaviour {


	public List<GameObject> ActivateZones;

	public List<GameObject> DeathZones;

	// Use this for initialization
	void Start () {
		
	}

	public void ActivateTrigger(GameObject go) {
		for (int i = 0; i < ActivateZones.Count; i++) {
			print (go.name);
			print (ActivateZones [i].name);
			if (ActivateZones[i].gameObject.name == go.name) {
				TrapTriggerKill TTK = DeathZones [i].GetComponentInChildren<TrapTriggerKill> ();
				TTK.CanKill = false;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
