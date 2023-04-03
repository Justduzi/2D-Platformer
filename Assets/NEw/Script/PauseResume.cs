using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseResume : MonoBehaviour {
	public bool pause;

	// Use this for initialization
	void Start () {
		pause = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void onPause(){
		if (Input.GetKeyDown ("escape")) {
			pause = !pause;
			if (!pause) {
				Time.timeScale = 1;

			} else if (pause) {
				Time.timeScale = 0;
			}
		}
	}
}
