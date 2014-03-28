using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	
	public int currentScore = 0;

	//Used to reset time scale if try again is clicked
	public bool restartGame = false;

	//Used to update score label in UI
	ScoreLabel scoreLabel;
	dfPanel taPanel;

	//Reference to check if our player dies
	PlayerControl player;

	// Use this for initialization
	void Start () {
		scoreLabel = GameObject.Find ("ScoreLabel").GetComponent<ScoreLabel>();
		player = GameObject.Find ("Player").GetComponent<PlayerControl>();
		taPanel = GameObject.Find ("TryAgainPanel").GetComponent<dfPanel>();

	}

	/// <summary>
	/// Checks if the player has lost and displays game over screen. Also
	/// resets the time scale if we chose to play again.
	/// </summary>
	void Update(){
		if(player.catDied){
			showTryAgain ();
		}

		if(restartGame){
			Time.timeScale = 1;
			restartGame = false;
		}
	}

	/// <summary>
	/// Display the try again panel and pause the game
	/// </summary>
	void showTryAgain(){
		Time.timeScale = 0;
		taPanel.Show();
	}

	/// <summary>
	/// Increase counter by 1 and update the label
	/// </summary>
	public void addScore(){
		currentScore++;
		scoreLabel.updateScore();
	}
}
