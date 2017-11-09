using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour {
	//WHOEVER MADE THIS DELET THIS
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void OnMouseDown () 
	{
		if (Input.GetMouseButtonDown(0)) {
			print ("Hello Murray");
		}
	}
}
