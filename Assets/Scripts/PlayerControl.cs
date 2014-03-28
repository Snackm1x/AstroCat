using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	//Force added to player
	private float jetForce = 150;

	//Used to know when player provides input
	private bool useJetPack = false;

	//Used to unpause game when player is ready
	private bool justStarting = true;

	//References to "How to play Labels"
	private dfLabel tapLabel;
	private dfLabel avoidLabel;

	//Used to stop input processing when dead
	private bool playerDead = false;

	//Reference to main game script
	GameManager gameManager;

	// Use this for initialization
	void Start () {
		//Set reference to main game script
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManager>();

		//Set references to the "How to play Labels"
		tapLabel = GameObject.Find ("TapLabel").GetComponent<dfLabel>();
		avoidLabel = GameObject.Find ("AvoidLabel").GetComponent<dfLabel>();

		//Temporarily pause game until player is ready
		Time.timeScale = 0;
	}
	
	// Update game loop used for receiving player input
	void Update () {
		//If we just started then unpause, otherwise process input
		if(!justStarting && !playerDead){
			if(Input.GetMouseButtonDown (0)){
				useJetPack = true;
			}
		} 

		if(justStarting){
			beginGame();
		}
	}

	//Physics updates (movement) handled in FixedUpate
	void FixedUpdate(){
		if(useJetPack){
			PlayerInput();
		}
	}

	//Apply player input to move character
	void PlayerInput(){
		//Clear current velocity and apply new input
		rigidbody2D.velocity = Vector2.zero;
		rigidbody2D.AddForce(new Vector2(0, jetForce));
		useJetPack = false;
	}

	//Collision check script to tell when the player loses
	void OnCollisionEnter2D(Collision2D collision){
		if(collision.collider.tag == "Death" || collision.collider.tag == "Satellite"){
			playerDead = true;
			gameManager.showTryAgain();
		}
	}

	//Called at the beginning of the game to unpause and hide our "How to play Labels"
	void beginGame(){
		if(Input.GetMouseButtonUp (0)){
			playerDead = false;
			justStarting = false;
			Time.timeScale = 1;
			tapLabel.Hide ();
			avoidLabel.Hide ();
			useJetPack = true;
		}
	}

}
