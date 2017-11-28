using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMenu : MonoBehaviour {

	public void LoadByIndex(int sceneIndex){
		SceneManager.LoadScene(sceneIndex);
	}
	public void Exit(){
		Application.Quit();		//en el editor no funciona
	}
}
