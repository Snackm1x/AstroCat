using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	//Players score during current run
	public int currentScore = 0;

	//Used to reset time scale if try again is clicked
	public bool restartGame = false;

	//Used to update score label in UI
	ScoreLabel scoreLabel;
	dfPanel taPanel;
	TAHighScoreLabel highScoreLabel;

	// Use this for initialization
	void Start () {
		//References to update our UI
		scoreLabel = GameObject.Find ("ScoreLabel").GetComponent<ScoreLabel>();
		taPanel = GameObject.Find ("TryAgainPanel").GetComponent<dfPanel>();
		highScoreLabel = GameObject.Find ("TAHighScore").GetComponent<TAHighScoreLabel>();

	}

	//Main game loop used to restart the game if the player wishes to try again
	void Update(){
		if(restartGame){
			Time.timeScale = 1;
			restartGame = false;
		}
	}

	//Pauses game on player death and displays our UI
	public void showTryAgain(){
		saveHighScore();
		Time.timeScale = 0;
		taPanel.Show();
	}

	//Increase currentScore and update our Score UI Label
	public void addScore(){
		currentScore++;
		scoreLabel.updateScore();
	}

	//Save and update players high score
	private void saveHighScore(){

		//First check if we have a saved high score
		if(PlayerPrefs.HasKey("High Score")){
			int highScore = PlayerPrefs.GetInt ("High Score");

			//If we beat our high score update and display
			if(currentScore > highScore){
				PlayerPrefs.SetInt ("High Score", currentScore);
				highScoreLabel.displayHighScore();
			}
		} else{
			PlayerPrefs.SetInt ("High Score", currentScore);
			highScoreLabel.displayHighScore();
		}
	}
}
