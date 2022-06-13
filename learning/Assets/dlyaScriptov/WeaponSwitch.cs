using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSwitch : MonoBehaviour {
	public int weaponSwitch = 0;
	public int openWeapon =1;
	public Text ChamberText;
	private Weapon wp;

	void Start () {
		SelectWeapon ();
		StartCoroutine (Recharge ());
	}

	void Update () {
		int currentWeapon = weaponSwitch;

		if (Input.GetAxis ("Mouse ScrollWheel") > 0f ) {
			if(weaponSwitch >= openWeapon -1)
				weaponSwitch =0;
			else
				weaponSwitch++;
		}
		if (Input.GetAxis ("Mouse ScrollWheel") < 0f ) {
			if(weaponSwitch <= 0)
				weaponSwitch = openWeapon -1;
			else
				weaponSwitch--;
		}

		if(Input.GetKeyDown(KeyCode.Alpha1))
			weaponSwitch = 0;
		else if(Input.GetKeyDown(KeyCode.Alpha2)&& openWeapon >= 2)
			weaponSwitch = 1;
		else if(Input.GetKeyDown(KeyCode.Alpha3)&& openWeapon >= 3)
			weaponSwitch = 2;
		ChamberText.text = wp.bulletsChamber + "/" + wp.bulletsMax;


		if(currentWeapon!= weaponSwitch)
			SelectWeapon();
	}

	void SelectWeapon(){
		int i = 0;
		foreach (Transform weapon in transform) {
			if (i == weaponSwitch) {
				weapon.gameObject.SetActive (true);
				wp = weapon.gameObject.GetComponent<Weapon> ();
			}else
				weapon.gameObject.SetActive (false);
			i++;
		}
	}
	IEnumerator Recharge(){
		if (wp.bulletsChamber > 0) {
			yield return new WaitForSeconds (0.5f);
			StartCoroutine (Recharge ());
			Debug.Log ("Все ок");
		}else {
			Debug.Log ("перезарядка...");
			wp.AS.PlayOneShot (wp.RechargeSound);
			yield return new WaitForSeconds (wp.seconds);
			wp.bulletsChamber = wp.bulletsMax;
			StartCoroutine (Recharge ());
		}
	}
}
