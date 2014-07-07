using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BackButtonEvents : MonoBehaviour 
{
	dfPanel creditsPanel;

	void Start(){
		creditsPanel = GameObject.Find ("CreditsPanel").GetComponent<dfPanel>() as dfPanel;
	}
	public void OnClick( dfControl control, dfMouseEventArgs mouseEvent )
	{
		creditsPanel.Hide();
	}

}
