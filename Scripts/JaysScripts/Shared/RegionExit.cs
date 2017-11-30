using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Need this as it sinks after leaving platform.
public class RegionExit : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
			other.gameObject.transform.position = new Vector3 (other.gameObject.transform.position.x, 0.5f, other.gameObject.transform.position.z);
		}
	}
}
