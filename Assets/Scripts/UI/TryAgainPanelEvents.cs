using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TryAgainPanelEvents : MonoBehaviour 
{
	TAScoreLabel taScore;
	TAHighScoreLabel taHighScore;

	void Start(){
		taScore = GameObject.Find ("TAScoreLabel").GetComponent<TAScoreLabel>();
	}
	public void OnIsVisibleChanged( dfControl control, bool value )
	{
		if(value){
			updateLabels();
		}
	}

	void updateLabels(){
		taScore.updateLabel();
	}
}
