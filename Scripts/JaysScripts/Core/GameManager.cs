using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager: MonoBehaviour {
	//public static GameManager gameManager;
	public event System.Action<Player> OnLocalPlayerJoined;
	//private GameObject gameObject;
	//

	public static GameManager Instance = null;

//	private static GameManager m_Instance;
//	public static GameManager Instance {
//		get {
//			if (m_Instance == null) {
//				m_Instance = new GameManager ();
//				//m_Instance.gameObject = new GameObject ("_gameManager");
//				m_Instance.gameObject.AddComponent<InputController> ();
//				m_Instance.gameObject.AddComponent<Timer> ();
//				m_Instance.gameObject.AddComponent<Respawner> ();
//				m_Instance.gameObject.AddComponent<MoveToPositionInTime> ();
//			}
//			return m_Instance;
//		}
//		set {
//			if (m_Instance != null) {
//				m_Instance = value;
//			}
//		}
//	}

//	public void DontDestroyElseKill(MonoBehaviour mb) {
//		if (mb == m_Instance) {
//			MonoBehaviour.DontDestroyOnLoad (m_Instance.gameObject);
//		}else{
//			MonoBehaviour.Destroy (mb);
//		}
//	}
//
//	void Awake() {
//		DontDestroyElseKill (this);
//		Debug.Log ("Awake");
//		//conversationDisplayerComponent = Co
//	}

	void Awake () {
		if (Instance == null) {
			Instance = this;

		}else if (Instance != this){
			Destroy (gameObject); // or gameObject
		}
		Instance.gameObject.AddComponent<InputController> ();
		Instance.gameObject.AddComponent<Timer> ();
		Instance.gameObject.AddComponent<Respawner> ();
		Instance.gameObject.AddComponent<MoveToPositionInTime> ();
		DontDestroyOnLoad (gameObject);
	}

	private InputController m_InputController;
	public InputController InputController {
		get {
			if (m_InputController == null) {
				m_InputController = gameObject.GetComponent<InputController> ();
			}
			return m_InputController;
		}
	}

	private Timer m_Timer;
	public Timer Timer{
		get {
			if (m_Timer == null) {
				m_Timer = gameObject.GetComponent<Timer> ();
			}
			return m_Timer;
		}
	}

	private Respawner m_Respawner;
	public Respawner Respawner {
		get {
			if (m_Respawner == null) {
				m_Respawner = gameObject.GetComponent<Respawner> ();
			}
			return m_Respawner;
		}
	}

	private MoveToPositionInTime m_MoveToPositionInTime;
	public MoveToPositionInTime MoveToPositionInTime{
		get {
			if (m_MoveToPositionInTime == null) {
				m_MoveToPositionInTime = gameObject.GetComponent<MoveToPositionInTime>();
			}
			return m_MoveToPositionInTime;
		}
	}

	private Player m_LocalPlayer;
	public Player LocalPlayer {
		get {
			return m_LocalPlayer;
		}
		set {
			m_LocalPlayer = value;
			if (OnLocalPlayerJoined != null) {
				OnLocalPlayerJoined (m_LocalPlayer);
			}
		}
	}
}
