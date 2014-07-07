using UnityEngine;
using System.Collections;

public class ScoreBox : MonoBehaviour {

	GameManager gameManager;

	//time variable
	float timeSinceLastScore = 0;

	//Reference to score scound
	AudioSource aSource;

	// Use this for initialization
	void Start () {
		//Set references
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManager>();
		aSource = gameObject.GetComponent("AudioSource") as AudioSource;
	}

	//Keeps track of time
	void Update(){
		timeSinceLastScore += Time.deltaTime;
	}

	//Using time to make sure that the collision to trigger score doesn't happen multiple times off the same satellite
	void OnTriggerEnter2D(Collider2D col){
		if(col.tag == "Satellite"){
			if(timeSinceLastScore >= 1f){
				gameManager.addScore();
				timeSinceLastScore = 0;
				aSource.Play();
			}
		}
	}
}
