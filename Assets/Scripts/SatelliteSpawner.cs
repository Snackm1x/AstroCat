using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SatelliteSpawner : MonoBehaviour {

	public List<GameObject> satelliteList = new List<GameObject>();
	Vector3 spawnPos = new Vector3(-3, -.05f, 0);

	float spawnTime = 2.5f;
	float timeSinceSpawn = 0f;

	// Update is called once per frame
	void Update () {
		timeSinceSpawn += Time.deltaTime;

		if(timeSinceSpawn >= spawnTime){
			spawnSatellite ();
			timeSinceSpawn = 0;
		}
	}

	void spawnSatellite(){
		int i = Random.Range (0, 3);
		GameObject newSat = Instantiate(satelliteList[i], spawnPos, Quaternion.identity) as GameObject;
	}
}
