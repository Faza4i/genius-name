using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCforMObible : MonoBehaviour {
	public float speed;
	public float jForse;
	public float gravity;
	public float cofactor;
	private AudioSource Au;
	public AudioClip walkAu;
	public AudioClip sitAu;
	public AudioClip runAu;
	public AudioClip jumpAu;
    public FixedJoystick Fixedjoystick;
	public float verticalSpeed = -1f;

	//приватные переменные
	private Vector3 moveDir;
	private CharacterController controller;

	void Start () {
		moveDir = Vector3.zero;
		controller = GetComponent<CharacterController> ();
		Au = GetComponent<AudioSource> ();
	}
	
    public void prigai(){
        if (controller.isGrounded) {
			verticalSpeed = jForse;
			Au.PlayOneShot (jumpAu);
			Au.pitch = 1f;
		}
    }

	void Update () {
		if (controller.isGrounded) {
			moveDir = new Vector3 (Fixedjoystick.Horizontal, 0, Fixedjoystick.Vertical);
			moveDir = transform.TransformDirection (moveDir);
			moveDir *= speed*cofactor;
		}
		if (moveDir.z != 0 || moveDir.x != 0) {
			if (cofactor == 1) {
				if (!Au.isPlaying)
					Au.PlayOneShot (walkAu);
			}
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
		
		verticalSpeed -= 9.81f*Time.deltaTime;
		moveDir.y = verticalSpeed;

		controller.Move (moveDir * Time.deltaTime);
	}
}
