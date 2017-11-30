using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float runSpeed;

	public bool canMove;

	public bool canFall;

	private float moveSpeed;
	private float fallSpeed;

	// Use this for initialization
	void Start () {
		canMove = true;
		moveSpeed = runSpeed;
		Time.timeScale = 1; // Move again after reload.
	}

	public void DisableMovement() {
		canMove = false;
		moveSpeed = 0;
	}

	public void RecoverMovement() { // Reset Y pos as well, sometimes sinks through floor.
		transform.position = new Vector3 (transform.position.x, 0.5f, transform.position.z);
		canMove = true;
	}
		
	// Update is called once per frame
	void Update () {
		if (canMove) {
			//GetComponent<Rigidbody> ().velocity = new Vector3 (runSpeed, 0, 0);
			moveSpeed = runSpeed;
		}else{
			moveSpeed = 0;
		}
		if (canFall) {
			fallSpeed = runSpeed;
		}else{
			fallSpeed = 0;
		}
		if (canFall || canMove) {
			//GetComponent<Rigidbody> ().velocity = new Vector3 (moveSpeed, -fallSpeed, 0);
			transform.position += new Vector3 (moveSpeed* Time.deltaTime , -fallSpeed * Time.deltaTime, 0);
		}
	}
}
