using UnityEngine;
using System.Collections;

public class RotatePlanet : MonoBehaviour {

	private float rotateSpeed = .05f;

	// Update is called once per frame
	void Update () {
		//Rotate planet clockwise
		transform.Rotate (new Vector3(0, 0, rotateSpeed));
	}
}
