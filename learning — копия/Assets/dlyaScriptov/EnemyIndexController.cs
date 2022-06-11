using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyIndexController : MonoBehaviour {
	private WaveSpawner _waveSpawner;
	private int waveNum = 1;
	public Text wave;
	private GameObject waveObj;

	void Start () {
		_waveSpawner = GameObject.FindGameObjectWithTag ("WaveControll").GetComponent<WaveSpawner> ();
		Debug.Log (_waveSpawner.gameObject.name);
		if (wave == null)
			waveObj = GameObject.FindGameObjectWithTag ("WaveText");
			wave = waveObj.GetComponent<Text> ();;
	}

	void OnDestroy(){
		int enemiesLeft;
		enemiesLeft = GameObject.FindGameObjectsWithTag ("Zombi").Length;
		Debug.Log (enemiesLeft);
		if (enemiesLeft == 0) {
			waveNum ++;
			_waveSpawner.LaunchWave ();
			wave.text = "Wave:" + waveNum;
			Debug.Log ("New wave!");
		}
	}
}
