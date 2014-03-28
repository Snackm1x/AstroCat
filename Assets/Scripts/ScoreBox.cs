using UnityEngine;
using System.Collections;

public class ScoreBox : MonoBehaviour {

	GameManager gameManager;
	float timeSinceLastScore = 0;
	// Use this for initialization
	void Start () {
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManager>();
	}

	void Update(){
		timeSinceLastScore += Time.deltaTime;
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.tag == "Satellite"){
			if(timeSinceLastScore >= 1f){
				gameManager.addScore();
				timeSinceLastScore = 0;
			}
		}
	}
}
