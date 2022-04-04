using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour {

	//Variables for speed and Ponto
	public float speed;
	private float x;
	public float finalPosition;
	public float originalPosition;

	void Start()
	{
		originalPosition = transform.position.x;
	}


	// Update is called once per frame
	void Update () {

		//sets the new x position based on the speed and moves the background image
		x = transform.position.x;
		x += speed * Time.deltaTime;
		transform.position = new Vector3 (x, transform.position.y, transform.position.z);

		//sets the image to the original x position
		if (x <= finalPosition)
		{
			//Debug.Log("hhhh");
			x = originalPosition;
			transform.position = new Vector3 (x, transform.position.y, transform.position.z);
		}


	}
}
