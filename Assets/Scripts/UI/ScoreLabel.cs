using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScoreLabel : MonoBehaviour 
{
	dfLabel scoreLabel;
	GameManager gameManager;

	void Start(){
		scoreLabel = gameObject.GetComponent<dfLabel>();
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManager>();
		updateScore();
	}


	public void updateScore(){
		scoreLabel.Text = "Score: " + gameManager.currentScore;
	}
}
