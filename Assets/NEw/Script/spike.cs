using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class spike : MonoBehaviour {

	void OnCollisionEnter2D (Collision2D col)
	{
		//Check collision name
		Debug.Log("collision name = " + col.gameObject.name);
		if(col.gameObject.name == "Panther")
		{
			Destroy(col.gameObject);
		}
		 else if(col.gameObject.name == "Player")
		{
			Destroy(col.gameObject);
			StartCoroutine (Loadscene ());


		}
	}
	IEnumerator Loadscene()
	{
		yield return new WaitForSeconds (2);
		SceneManager.LoadScene ("002");
	}
}
