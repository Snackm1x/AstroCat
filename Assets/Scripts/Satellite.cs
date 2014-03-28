using UnityEngine;
using System.Collections;

public class Satellite : MonoBehaviour {
	
	string satName;
	
	Vector3 targetDir;
	float moveSpeed = 25f;
	int currentNode = 1;

	[SerializeField]
	bool reached1 = false;
	
	[SerializeField]
	bool reached2 = false;
	
	[SerializeField]
	bool reached3 = false;
	
	[SerializeField]
	bool reachedEnd = false;
	
	GameObject node1;
	GameObject node2;
	GameObject node3;
	GameObject endNode;
	// Use this for initialization
	void Start () {
		checkName ();
		node1 = GameObject.Find (satName + "Node1") as GameObject;
		node2 = GameObject.Find (satName + "Node2") as GameObject;
		node3 = GameObject.Find (satName + "Node3") as GameObject;
		endNode = GameObject.Find (satName +  "EndNode") as GameObject;
		moveToNode(currentNode);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		checkCurrentNode();
	}
	
	void checkCurrentNode(){
		switch(currentNode){
		case 1:
			if(!reached1){
				if(Vector3.Distance(transform.position, node1.transform.position) <= .5f){
					reached1 = true;
					currentNode++;
					moveToNode(currentNode);
				}
			}
			break;
		case 2:
			if(!reached2){
				if(Vector3.Distance(transform.position, node2.transform.position) <= .05f){
					reached2 = true;
					currentNode++;
					moveToNode(currentNode);
				}
			}
			break;
		case 3:
			if(!reached3){
				if(Vector3.Distance(transform.position, node3.transform.position) <= .05f){
					reached3 = true;
					currentNode++;
					moveToNode(currentNode);
				}
			}
			break;
		case 4:
			if(!reachedEnd){
				if(Vector3.Distance(transform.position, endNode.transform.position) <= .05f){
					reachedEnd = true;
					currentNode++;
					moveToNode(currentNode);
				}
			}
			break;
		default:
			break;
		}
	}
	
	void moveToNode(int current){
		switch(current){
		case 1:
			targetDir = node1.transform.position - transform.position;
			targetDir = targetDir * moveSpeed * Time.deltaTime;
			rigidbody2D.velocity = new Vector2(targetDir.x, targetDir.y);
			break;
		case 2:
			targetDir = node2.transform.position - transform.position;
			targetDir = targetDir * moveSpeed * Time.deltaTime;
			rigidbody2D.velocity = new Vector2(targetDir.x, targetDir.y);
			break;
		case 3:
			targetDir = node3.transform.position - transform.position;
			targetDir = targetDir * moveSpeed * Time.deltaTime;
			rigidbody2D.velocity = new Vector2(targetDir.x, targetDir.y);
			break;
		case 4:
			targetDir = endNode.transform.position - transform.position;
			targetDir = targetDir * moveSpeed * Time.deltaTime;
			rigidbody2D.velocity = new Vector2(targetDir.x, targetDir.y);
			break;
		default:
			break;
		}
	}
	
	void checkName(){
		switch(gameObject.name){
		case "TopSatellite":
			satName = "Top";
			break;
		case "MidSatellite":
			satName = "Mid";
			break;
		case "BottomSatellite":
			satName = "Bottom";
			break;
		default:
			Debug.Log ("Sat Name error!!");
			break;
		}
	}
}
