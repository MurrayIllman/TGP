﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour {
	public void Despawn(GameObject gameObj, float inSeconds){
		gameObj.SetActive (false);
		GameManager.Instance.Timer.Add (() => { // Brackets == method to execute
			gameObj.SetActive(true); // Method
		}, inSeconds);
	}
} 

