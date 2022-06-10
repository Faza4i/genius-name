﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {
	[SerializeField]private Waves[] _waves;
	private int _currentEnemyIndex;
	private int _currentWaveIndex;
	private int _enemiesLeftToSpawn;

	private void Start(){
		_enemiesLeftToSpawn = _waves [0].WaveSettings.Length;
		LaunchWave ();
	}

	private IEnumerator SpawnEnemyInWave(){
		if (_enemiesLeftToSpawn > 0) {
			yield return new WaitForSeconds (_waves [_currentWaveIndex].WaveSettings [_currentEnemyIndex].SpawnDelay);
			Instantiate (_waves [_currentWaveIndex].WaveSettings [_currentEnemyIndex].Enemy, _waves [_currentWaveIndex].WaveSettings [_currentEnemyIndex].NeededSpawner.transform.position, Quaternion.identity);
			_enemiesLeftToSpawn--;
			_currentEnemyIndex++;
			StartCoroutine (SpawnEnemyInWave ());
		} else {
			if (_currentWaveIndex < _waves.Length -1) {
				_currentWaveIndex++;
				_enemiesLeftToSpawn = _waves [_currentWaveIndex].WaveSettings.Length;
				_currentEnemyIndex = 0;
			} 
		}
	}

	public void LaunchWave(){
		StartCoroutine (SpawnEnemyInWave());
	}
}
[System.Serializable]
public class Waves{
	[SerializeField] private WaveSettings[] _waveSettings;
	public WaveSettings[] WaveSettings{get {return this._waveSettings;}}
}

[System.Serializable]
public class WaveSettings{
	[SerializeField]private GameObject _enemy;
	public GameObject Enemy{get {return this._enemy;}}
	[SerializeField]private GameObject _neededSpawner;
	public GameObject NeededSpawner{ get {return this._neededSpawner; } }
	[SerializeField]private float _spawnDelay;
	public float SpawnDelay{get { return this._spawnDelay; } }
}