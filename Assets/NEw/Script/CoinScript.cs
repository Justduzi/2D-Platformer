using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour {

	void OnCollisionEnter2D (Collision2D col)
	{
		ScoreText.CoinAmount += 1;
		Destroy (gameObject);
}
}
