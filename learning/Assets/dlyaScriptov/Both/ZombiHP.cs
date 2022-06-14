using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiHP : MonoBehaviour {
	public float HP;

	void Update () {
		if (HP <= 0) {
			Debug.Log ("ой бля я здох");
			this.gameObject.GetComponent<Enemy_Controller> ().enabled = false;
			Destroy (this.gameObject);
		}
	}
}