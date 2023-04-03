using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MMenu : MonoBehaviour {

	public void Playgames(){

		SceneManager.LoadScene ("002");

	}
	public void PlaygamesOne(){
		SceneManager.LoadScene ("002");
	}
	public void Playgamestwo(){
		SceneManager.LoadScene ("01");
	}
	public void QuitGame(){

		Application.Quit();
	}

}

