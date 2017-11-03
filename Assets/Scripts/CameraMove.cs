﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

	public float speed = 1f;

	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.W))
			transform.Translate (new Vector3 (0, speed));
		if (Input.GetKey (KeyCode.A))
			transform.Translate (new Vector3 (-speed, 0));
		if (Input.GetKey (KeyCode.S))
			transform.Translate (new Vector3 (0, -speed));
		if (Input.GetKey (KeyCode.D))
			transform.Translate (new Vector3 (speed, 0));
		if (Input.GetKey (KeyCode.UpArrow) && GetComponent<Camera>().orthographicSize > 1)
			GetComponent<Camera> ().orthographicSize--;
		if (Input.GetKey (KeyCode.DownArrow))
			GetComponent<Camera> ().orthographicSize++;
	}
}
