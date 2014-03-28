using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TAHighScoreLabel : MonoBehaviour 
{
	//Reference to label
	dfLabel hsLabel;

	void Start(){
		//Set reference and display score
		hsLabel = GameObject.Find ("TAHighScore").GetComponent<dfLabel>();
		displayHighScore();
	}

	//Updates and displays high score
	public void displayHighScore(){
		if(PlayerPrefs.HasKey("High Score")){
			int highScore = PlayerPrefs.GetInt ("High Score");
			hsLabel.Text = "High Score: " + highScore;
		}
	}
}
