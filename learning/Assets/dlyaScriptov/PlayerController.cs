using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	[Header("Скорость")]
	public float Vspeed;
	public float Hspeed;
	public float Cofactor;

	[Header("На земле ли?")]
	public bool isGround;

	[Header("сила прыжка")]
	public float jumpF;

	[Header("Спавн")]
	public Vector3 Spawn;

	[Header("Физика игрока")]
	public Rigidbody rb;

	void Update () {
		RunOrSit ();
		ToSpawn ();
	}
    void FixedUpdate(){
        GetInput();
    }
	
    private void GetInput(){
		if (Input.GetKey (KeyCode.W))
			transform.localPosition += transform.forward*Vspeed*Cofactor*Time.fixedDeltaTime;
		else if (Input.GetKey (KeyCode.S))
			transform.localPosition += -transform.forward*Vspeed*Cofactor*Time.fixedDeltaTime;

		if (Input.GetKey (KeyCode.A))
			transform.localPosition += -transform.right*Hspeed*Cofactor*Time.fixedDeltaTime;
		else if (Input.GetKey (KeyCode.D))
			transform.localPosition += transform.right*Hspeed*Cofactor*Time.fixedDeltaTime;

		if (Input.GetKeyDown (KeyCode.Space) && isGround){
			isGround = false;
			rb.AddForce (transform.up* jumpF);
		}
	}
	private void RunOrSit(){
		if (Input.GetKeyDown (KeyCode.LeftShift))
			Cofactor = 2f;
		else if (Input.GetKeyUp (KeyCode.LeftShift))
			Cofactor = 1f;

		if (Input.GetKeyDown (KeyCode.C))
			Cofactor = 0.5f;
		else if (Input.GetKeyUp (KeyCode.C))
			Cofactor = 1f;
	}
	private void ToSpawn(){
		if (transform.position.y <= -30)
			transform.position = Spawn;
	}

	private void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "Ground")
			isGround = true;
	}
}