using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayButtonEvents : MonoBehaviour 
{
	void Start(){
	
	}
	public void OnClick( dfControl control, dfMouseEventArgs mouseEvent )
	{
		Application.LoadLevel (1);
	}

}
