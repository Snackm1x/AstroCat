using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TAYesButtonEvents : MonoBehaviour 
{
	GameManager gameManager;

	void Start(){
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManager>();
	}
	public void OnClick( dfControl control, dfMouseEventArgs mouseEvent )
	{
		gameManager.restartGame = true;
		Application.LoadLevel(Application.loadedLevel);
	}

}
