using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerPC : MonoBehaviour{
	private float mouseX;
	private float mouseY;

	[Header("Чувствительность мыши")]
	public float sensitivityMouse;

	public Transform player;

	void Start () {
		Cursor.lockState = CursorLockMode.Locked;
	}
	
	void Update () {
		mouseX = Input.GetAxis ("Mouse X") * sensitivityMouse*Time.deltaTime;
		mouseY = Input.GetAxis ("Mouse Y") * sensitivityMouse*Time.deltaTime;

	
		player.Rotate (mouseX * new Vector3 (0, 1, 0));
		transform.Rotate (-mouseY * new Vector3 (1, 0, 0));

		CursorLock ();
	}

	private void CursorLock(){
		if (Input.GetKey (KeyCode.Q))
			Cursor.lockState = CursorLockMode.Confined;
		if (Input.GetKeyUp (KeyCode.Q))
			Cursor.lockState = CursorLockMode.Locked;
	}
}
