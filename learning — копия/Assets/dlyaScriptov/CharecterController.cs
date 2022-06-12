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
	public AudioClip sitAu;
	public AudioClip runAu;
	public AudioClip jumpAu;

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
		if (moveDir.z != 0 || moveDir.x != 0) {
			if (cofactor == 1) {
				if (!Au.isPlaying)
					Au.PlayOneShot (walkAu);
			}
		} 

		if (Input.GetKeyDown (KeyCode.Space)&& controller.isGrounded) {
			moveDir.y = jSpeed;
			Au.PlayOneShot (jumpAu);
			Au.pitch = 1f;
		}
		if (Input.GetKey (KeyCode.LeftShift)) {
			cofactor = 2f;
			if (moveDir.z != 0 || moveDir.x != 0) {
				if (!Au.isPlaying)
					Au.PlayOneShot (runAu);
			}else
				Au.Stop ();
		} else if (Input.GetKeyUp (KeyCode.LeftShift)) {
			cofactor = 1f;
			Au.Stop();
		} else if (Input.GetKey (KeyCode.C)) {
			cofactor = 0.5f;
			if (moveDir.z != 0 || moveDir.x != 0) {
				if (!Au.isPlaying)
					Au.PlayOneShot (sitAu);
			} else
				Au.Stop ();
		} else if (Input.GetKeyUp (KeyCode.C)) {
			cofactor = 1f;
			Au.Stop();
		}
		
		moveDir.y -= gravity * Time.deltaTime;

		controller.Move (moveDir * Time.deltaTime);
	}
}
