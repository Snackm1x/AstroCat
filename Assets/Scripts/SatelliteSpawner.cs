using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SatelliteSpawner : MonoBehaviour {

	public List<GameObject> satelliteList = new List<GameObject>();
	GameObject spawnNode;
	Vector3 spawnPos;
	float spawnTime = 2.5f;
	float timeSinceSpawn = 0f;

	void Start(){
		spawnNode = GameObject.Find ("SpawnNode") as GameObject;
		spawnPos = spawnNode.transform.position;
	}

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
