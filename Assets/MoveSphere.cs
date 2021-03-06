﻿using UnityEngine;
using System.Collections;

public class MoveSphere : MonoBehaviour {
	public float speed;
	public VirtualJoystick joystick;

	private Rigidbody rb;

	void Start() {
		rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate() {
		//float moveHorizontal = Input.GetAxis("Horizontal");
		//float moveVertical = Input.GetAxis("Vertical");

		float moveHorizontal = joystick.GetDirection().x;
		float moveVertical = joystick.GetDirection().z;

		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

		rb.AddForce(movement * speed);
	}
}
