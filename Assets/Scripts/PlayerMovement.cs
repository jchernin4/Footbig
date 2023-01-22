using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	public CharacterController controller;
	public Transform groundCheck;
	public float checkRadius = 0.2f;
	public LayerMask groundMask;

	public float speed = 8f;
	public float gravity = -19.62f;
	public float jumpHeight = 1f;

	Vector3 velocity;
	bool isGrounded;
	void Start() {

	}

	void Update() {
		isGrounded = Physics.CheckSphere(groundCheck.position, checkRadius, groundMask);

		if (isGrounded && velocity.y < 0) {
			velocity.y = -2f;
		}

		float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");

		Vector3 move = transform.right * x + transform.forward * z;
		controller.Move(Vector3.ClampMagnitude(move * Time.deltaTime, 1.0f) * speed);

		if (Input.GetButtonDown("Jump") && isGrounded) {
			velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
		}

		velocity.y += gravity * Time.deltaTime;

		controller.Move(velocity * Time.deltaTime);
	}
}
