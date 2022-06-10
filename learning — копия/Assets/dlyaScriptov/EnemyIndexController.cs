using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIndexController : MonoBehaviour {
	private WaveSpawner _waveSpawner;

	void Start () {
		_waveSpawner = GameObject.FindGameObjectWithTag ("WaveControll").GetComponent<WaveSpawner> ();
		Debug.Log (_waveSpawner.gameObject.name);
	}

	void OnDestroy(){
		int enemiesLeft;
		enemiesLeft = GameObject.FindGameObjectsWithTag ("Zombi").Length;
		Debug.Log (enemiesLeft);
		if (enemiesLeft == 0) {
			_waveSpawner.LaunchWave ();
			Debug.Log ("New wave!");
		}
	}
}
