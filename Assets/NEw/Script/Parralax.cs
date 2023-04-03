using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parralax : MonoBehaviour {
	public float backgroundSize;
	public float paralaxSpeed;

	private Transform cameraTransorm;
	private Transform[] Layers;
	private float viewzone =10;
	private int LeftIndex;
	private int RightIndex;
	private float lastCameraX;

	// Use this for initialization
	void Start () {
		
		cameraTransorm = Camera.main.transform;
		lastCameraX = cameraTransorm.position.x;
		Layers = new Transform[transform.childCount];
		for (int i = 0; i < transform.childCount; i++) 
			Layers [i] = transform.GetChild (i);

			LeftIndex = 0;
			RightIndex = Layers.Length - 1;

		
	}
	private void Update () {
		float deltaX = cameraTransorm.position.x - lastCameraX;
		transform.position += Vector3.right * (deltaX * paralaxSpeed);
		lastCameraX = cameraTransorm.position.x;

		if (cameraTransorm.position.x < (Layers[LeftIndex].transform.position.x + viewzone))
			ScrollLeft ();
		if (cameraTransorm.position.x < (Layers[RightIndex].transform.position.x + viewzone))
			ScrollRight ();

	}
	private void ScrollLeft()
	{
		int lastRight = RightIndex;
		Layers [RightIndex].position = Vector3.right * (Layers [LeftIndex].position.x -backgroundSize);
		LeftIndex = RightIndex;
		RightIndex--;
		if (RightIndex < 0)
			RightIndex = Layers.Length - 1;
			
	}

	private void ScrollRight()
	{
		int lastRight = LeftIndex;
		Layers [LeftIndex].position = Vector3.right * (Layers [RightIndex].position.x - backgroundSize);
		RightIndex = LeftIndex;
		LeftIndex ++;
		if (LeftIndex == Layers.Length)
			LeftIndex = 0;

	}
	// Update is called once per frame

}
