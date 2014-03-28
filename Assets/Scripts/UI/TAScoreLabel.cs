using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TAScoreLabel : MonoBehaviour 
{
	dfLabel taScore;
	GameManager gameManager;

	void Start(){
		taScore = gameObject.GetComponent<dfLabel>();
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManager>();
	}

	public void updateLabel(){
		taScore.Text = "Score : " + gameManager.currentScore;
	}

}
