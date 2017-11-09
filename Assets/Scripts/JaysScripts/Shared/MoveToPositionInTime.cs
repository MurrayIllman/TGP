using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPositionInTime : MonoBehaviour {

	public void MoveToPositionWrapper(Transform transform, Vector3 position, float timeToMove){
		StartCoroutine (MoveToPosition(transform, position, timeToMove));
	}

	private IEnumerator MoveToPosition(Transform transform, Vector3 position, float timeToMove) // If script is attached.
	{
		var currentPos = transform.position;
		var t = 0f;
		while(t < 1)
		{
			t += Time.deltaTime / timeToMove;
			transform.position = Vector3.Lerp(currentPos, position, t);
			yield return null;
		}
	}

	public void MoveToPositionWithObjectWrapper(GameObject gameObj, Vector3 position, float timeToMove){
		StartCoroutine (MoveToPositionWithObject(gameObj, position, timeToMove));
	}

	private IEnumerator MoveToPositionWithObject(GameObject gameObj, Vector3 position, float timeToMove){ // Pass object with no script.
		Debug.Log("moving");
		var transform = gameObj.transform;
		var currentPos = transform.position;
		var t = 0f;
		while(t < 1)
		{
			t += Time.deltaTime / timeToMove;
			transform.position = Vector3.Lerp(currentPos, position, t);
			yield return null;
		}
	}
}
