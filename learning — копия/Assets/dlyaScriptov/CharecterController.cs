using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour {
	public float speed;
	public float jSpeed;
	public float gravity;
	public float cofactor;
	private AudioSource Au;
	public AudioClip walkAu;

	//приватные переменные
	private Vector3 moveDir;
	private CharacterController controller;

	void Start () {
		moveDir = Vector3.zero;
		controller = GetComponent<CharacterController> ();
		Au = GetComponent<AudioSource> ();
	}
	
	void FixedUpdate () {
		if (controller.isGrounded) {
			moveDir = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
			moveDir = transform.TransformDirection (moveDir);
			moveDir *= speed*cofactor;
		}
		if (moveDir != Vector3.zero) {
			if (!Au.isPlaying)
				Au.PlayOneShot (walkAu);
		}

		if (Input.GetKeyDown (KeyCode.Space)&& controller.isGrounded) {
			moveDir.y = jSpeed;
		}
		if (Input.GetKey (KeyCode.LeftShift)) {
			cofactor = 2f;
			Au.pitch = 2f;
		} else if (Input.GetKeyUp (KeyCode.LeftShift)) {
			cofactor = 1f;
			Au.pitch = 1f;
		} else if (Input.GetKey (KeyCode.C)) {
			cofactor = 0.5f;
			Au.pitch = 0.6f;
		} else if (Input.GetKeyUp (KeyCode.C)) {
			cofactor = 1f;
			Au.pitch = 1f;
		}
		
		moveDir.y -= gravity * Time.deltaTime;

		controller.Move (moveDir * Time.deltaTime);
	}
}
