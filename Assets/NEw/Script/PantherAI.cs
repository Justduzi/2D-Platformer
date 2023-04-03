using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PantherAI : MonoBehaviour {
	public Transform target;
	float speed = 4.5f;
	// Use this for initialization
	void Start () {
		speed = speed;
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance(transform.position,target.position)>1f){//move if distance from target is greater than 1
			transform.Translate(new Vector3(speed* Time.deltaTime,0,0) );

		}
	}
	void OnCollisionEnter2D (Collision2D col)
	{
		//Check collision name
		Debug.Log("collision name = " + col.gameObject.name);
		 if(col.gameObject.name == "Player")
		{
			Destroy(col.gameObject);
			Destroy (gameObject, 2);
			StartCoroutine (Loadscene ());


		}
	}
	IEnumerator Loadscene()
	{
		yield return new WaitForSeconds (3);
		SceneManager.LoadScene ("002");
	}
}
