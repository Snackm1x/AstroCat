using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TANoButtonEvents : MonoBehaviour 
{

	public void OnClick( dfControl control, dfMouseEventArgs mouseEvent )
	{
		Application.LoadLevel (0);
	}

}
