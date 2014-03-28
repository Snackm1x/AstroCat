using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScoreLabel : MonoBehaviour 
{
	//Reference to the UI ScoreLabel
	dfLabel scoreLabel;

	//Reference to main game script
	GameManager gameManager;

	void Start(){
		//Assign references
		scoreLabel = gameObject.GetComponent<dfLabel>();
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManager>();

		//Set current score on start (Should always be 0)
		updateScore();
	}

	//Called by main game script, used to change/display score
	public void updateScore(){
		scoreLabel.Text = "Score: " + gameManager.currentScore;
	}
}
