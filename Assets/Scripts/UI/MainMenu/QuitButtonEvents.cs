using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class QuitButtonEvents : MonoBehaviour 
{

	public void OnClick( dfControl control, dfMouseEventArgs mouseEvent )
	{
		Application.Quit ();
	}

}
