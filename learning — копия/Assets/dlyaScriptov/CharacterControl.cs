using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour {
	public float speed;
	public float jSpeed;
	public float gravity;
	public float cofactor;
	public Vector3 ToSpawn;

	//приватные переменные
	private Vector3 moveDir;
	private CharacterController controller;

	void Start () {
		moveDir = Vector3.zero;
		controller = GetComponent<CharacterController> ();
	}
	
	void FixedUpdate () {
		if (controller.isGrounded) {
			moveDir = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
			moveDir = transform.TransformDirection (moveDir);
			moveDir *= speed*cofactor;
		}
		if (Input.GetKeyDown (KeyCode.Space)&& controller.isGrounded) {
			moveDir.y = jSpeed;
		}
		if (Input.GetKey (KeyCode.LeftShift))
			cofactor = 2f;
		else if (Input.GetKeyUp (KeyCode.LeftShift))
			cofactor = 1f;
		else if (Input.GetKey (KeyCode.C))
			cofactor = 0.5f;
		else if (Input.GetKeyUp (KeyCode.C))
			cofactor = 1f;
		
		moveDir.y -= gravity * Time.deltaTime;

		controller.Move (moveDir * Time.deltaTime);
		
		if(this.gameObject.GetComponent<Transform>().position.y <= -30)
            this.gameObject.GetComponent<Transform>().position = ToSpawn;
	}
}