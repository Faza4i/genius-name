using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
	//сила отталкивания
	public float force;
	//урон
	public float damage;
	//скорость стрельбы
	public float fireRate;
	//дальность стрельбы
	public float range;
	//эффект
	public ParticleSystem muzzleFlash;
	//спавн пули(место)
	public Transform bulletSpawn;
	//звук стрельбы
	public AudioClip shotFSX;
	//где будет звук стрельбы
	public AudioSource AS;
	//камера
	public Camera _cam;
	//эффект от пуль при попадании по поверхности
	public GameObject hitEffect;
	//эффект при дамаге
	public GameObject damageEffect;

	private float nextFire = 0f;

	void Start () {
		
	}
	
	void Update () {
		if (Input.GetButton ("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + 1f / fireRate;
			Shoot ();
		}
	}

	void Shoot(){
		AS.PlayOneShot (shotFSX);
		muzzleFlash.Play ();

		RaycastHit hit;

		if (Physics.Raycast (_cam.transform.position, _cam.transform.forward, out hit, range)) {
			Debug.Log ("Я ПОПАЛ ");

			if(hit.transform.gameObject.tag != "Zombi"){
				GameObject impact = Instantiate (hitEffect, hit.point, Quaternion.LookRotation (hit.normal));
				Destroy (impact, 2f);
			}

			if (hit.rigidbody != null && hit.rigidbody.gameObject.tag == "DynamicObj")
				hit.rigidbody.AddForce (-hit.normal * force);
			else if (hit.transform.gameObject.tag == "Zombi") {
				GameObject blood = Instantiate (damageEffect, hit.point, Quaternion.LookRotation (hit.normal));
				Destroy (blood, 2f);
				hit.transform.gameObject.GetComponent<ZombiHP> ().HP -= damage;
				Debug.Log (hit.transform.gameObject.GetComponent<ZombiHP> ().HP);
			}
		}
	}
}