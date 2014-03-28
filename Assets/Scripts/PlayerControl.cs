using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	private float jetForce = 150;
	private float maxVelocity = 250;

	bool useJetPack = false;
	public bool catDied = false;

	bool justStarting = true;
	dfLabel tapLabel;
	dfLabel avoidLabel;

	// Use this for initialization
	void Start () {
		tapLabel = GameObject.Find ("TapLabel").GetComponent<dfLabel>();
		avoidLabel = GameObject.Find ("AvoidLabel").GetComponent<dfLabel>();
		Time.timeScale = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(!justStarting){
			if(Input.GetMouseButtonDown (0)){
				useJetPack = true;
			}
		} else {
			beginGame();
		}
	}

	void FixedUpdate(){
		if(useJetPack){
			jetPack();
		}
	}

	void jetPack(){
		if(rigidbody2D.velocity.y >= 0){
			rigidbody2D.AddForce(new Vector2(0, jetForce));
		} else {
			rigidbody2D.velocity = Vector2.zero;
			rigidbody2D.AddForce(new Vector2(0, jetForce));
		}

		if(rigidbody2D.velocity.y >= maxVelocity){
			rigidbody2D.velocity = new Vector2(0, maxVelocity);
		}
		useJetPack = false;
	}

	void OnCollisionEnter2D(Collision2D collision){
		if(collision.collider.tag == "Death" || collision.collider.tag == "Satellite"){
			catDied = true;
		}
	}

	void beginGame(){
		if(Input.GetMouseButtonUp (0)){
			Time.timeScale = 1;
			tapLabel.Hide ();
			avoidLabel.Hide ();
			useJetPack = true;
		}
	}
}
