using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Controller : MonoBehaviour {
	[Header("Игрок")]
	public GameObject player; 
	[Header("Дистанция")]
	public float dist;
	[Header("Мэш агент врага")]
	NavMeshAgent nav;
	[Header("Радиус обзора(В метрах)")]
	public float radius;
	[Header("Дистанция атаки")]
	public float distAtack;
	[Header("Урон врага")]
	public int damageEnemy;
	[Header("Время ожидания для следующей атаки")]
	public float attackRate;
	public AudioSource zozoAuDIO;
	public AudioClip LoviPoEbly;
	public AudioClip poshel;
	public float VolumeLoviPoEbly;
	public float VolumePoshel;

	private float nextATK = 0f;

	void Start () {
		nav = GetComponent<NavMeshAgent> ();

		if (player == null) {
   			player = GameObject.FindGameObjectWithTag ("Player");
  		}
	}
	
	void Update () {
		dist = Vector3.Distance (player.transform.position, transform.position);
		if (dist > radius){
			nav.enabled = false;
			gameObject.GetComponent<Animator> ().SetTrigger ("Idle");
		}

		if (dist < radius) {
			nav.enabled = true;
			nav.SetDestination (player.transform.position);
			gameObject.GetComponent<Animator> ().SetTrigger ("Run");
			if (!zozoAuDIO.isPlaying)
				zozoAuDIO.PlayOneShot(poshel, VolumePoshel);
		}

		if (dist <= distAtack && Time.time > nextATK) {
			nextATK = Time.time + 1f / attackRate;
			Debug.Log ("папався");
			player.GetComponent<PlayerHP> ().playerHp -= damageEnemy;
			gameObject.GetComponent<Animator> ().SetTrigger ("Attack");
			zozoAuDIO.PlayOneShot(LoviPoEbly, VolumeLoviPoEbly);
		}
	}
}
