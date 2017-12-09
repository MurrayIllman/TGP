using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float runSpeed;

	public bool canMove;

	public bool canFall;

	private float moveSpeed;
	private float fallSpeed;
	private float speeduptimer;

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
		if(speeduptimer < Time.time)
		{
			speeduptimer = Time.time + 5 + (10 * Random.value);
			//in this case the speeduptimer is changed on a random interval between 5 and 15 seconds, use Time.time+10 to use a static 10 ingame seconds for each increase (if you are increasing gamespeed to increase movement speed, im not sure how this would be affected.)
			IncreasePlayerSpeed();
		}
	}

	void IncreasePlayerSpeed(){
		runSpeed += 4;
	}
}
