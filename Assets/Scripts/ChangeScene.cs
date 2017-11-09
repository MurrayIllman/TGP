using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {
	public void ChangeToScene(int changeTheScene){
		SceneManager.LoadScene (changeTheScene);
	}
	public void Quit(){
		Application.Quit();
	}
}