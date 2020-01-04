using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Manejar escenas
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {

	public void ChangeSceneTo(string sceneName){
		SceneManager.LoadScene(sceneName);
	}
}
