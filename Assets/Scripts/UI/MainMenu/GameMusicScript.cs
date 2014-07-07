using UnityEngine;
using System.Collections;

public class GameMusicScript : MonoBehaviour {

	/* Method to keep music playing between scenes. Checks to see that
	 * the object doesn't already exist, and if it does it destroys the new one.
	 * 
	 * */
	private static GameMusicScript instance = null;
	public static GameMusicScript Instance{get {return instance;} }

	// Use this for initialization
	void Start () {
		if(instance != null && instance != this) {
			Destroy (this.gameObject);
			return;
		}else {
			instance = this;
		}
		DontDestroyOnLoad(gameObject);
	}
}
