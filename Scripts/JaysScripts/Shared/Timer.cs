using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

	private class TimedEvent {
		public float TimeToExecute;
		public CallBack Method;
	}

	private List<TimedEvent> events; // List of all active events
	public delegate void CallBack();

	void Awake() {
		events = new List<TimedEvent> ();
	}

	public void Add(CallBack method, float inSeconds){ // Does the function in X seconds.
		events.Add (new TimedEvent {
			Method = method,
			TimeToExecute = Time.time + inSeconds
		});
	}

	void Update(){
		if (events == null) {
			return;
		}
		if (events.Count == 0) { // Object reference not set to instance thingy.
			return; // If no events then return
		}

		for (int i = 0; i < events.Count; i++) { // For loop as you cannot remove elements using other loop types from lists.
			var timedEvent = events [i];
			if (timedEvent.TimeToExecute <= Time.time) {
				timedEvent.Method ();
				events.Remove (timedEvent);
			}
		}

	}
}
