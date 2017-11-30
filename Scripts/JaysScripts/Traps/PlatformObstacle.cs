using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformObstacle : MonoBehaviour {

	public float PlatformSpeed = 0.1f;
	private bool PlayerLocked = false;
	private bool FinishedPuzzle = false;
	private GameObject Player;

	private GameManagerWorld gmw;

	public GameObject StartPos;
	public GameObject EndPos;
	public GameObject MovingPlatform;

	InputController playerInput;

	// Use this for initialization
	void Awake () {
		
	}

	void Start () {
		playerInput = GameManager.Instance.InputController;
		gmw = GameObject.Find ("GameManager").GetComponent<GameManagerWorld> ();
	}

	private void ReturnControl () { // Obstacle over, can move.
		if (Player != null) {
			PlayerMovement pm = Player.GetComponent<PlayerMovement>();
			if (pm != null) {
				pm.RecoverMovement ();
			}
			Player = null;
		}
	}

	private void FinishPuzzle() {
		FinishedPuzzle = true;
		MovingPlatform.transform.position = EndPos.transform.position;
		ReturnControl ();
	}

	public void ReadyToMove(GameObject player){
		if (PlayerLocked == false) {
			PlayerLocked = true;
			if (player != null && player.tag == "Player") {
				Player = player;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerLocked && FinishedPuzzle == false) {
			// Move with mouse
			if (playerInput.Activate == true && gmw.Paused == false) {	
				MovingPlatform.transform.position += new Vector3 (PlatformSpeed,0,0);
				Player.transform.position += new Vector3 (PlatformSpeed,0,0);
				if (MovingPlatform.transform.position.x >= EndPos.transform.position.x) { // If current pos is greater than end pos.
					FinishPuzzle ();
				}

			}
		}
	}
}
