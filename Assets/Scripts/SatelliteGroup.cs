using UnityEngine;
using System.Collections;

public class SatelliteGroup : MonoBehaviour {

	//Movement Variables
	Vector3 targetDir;
	float moveSpeed = 25f;
	int currentNode = 1;

	//Node Checkpoint flags
	bool reached1 = false;
	bool reached2 = false;
	bool reached3 = false;
	bool reachedEnd = false;

	//Waypoint Nodes for movement
	GameObject node1;
	GameObject node2;
	GameObject node3;
	GameObject endNode;

	//Going to switch to object pooling, quick working hack
	float deleteZone = 4;

	// Use this for initialization
	void Start () {
		//Set references and begin movement
		node1 = GameObject.Find ("Node1") as GameObject;
		node2 = GameObject.Find ("Node2") as GameObject;
		node3 = GameObject.Find ("Node3") as GameObject;
		endNode = GameObject.Find ("EndNode") as GameObject;
		moveToNode(currentNode);
	}

	void Update(){
		deleteSat();
	}

	// Update is called once per frame
	void FixedUpdate () {
		checkCurrentNode();
	}

	/// <summary>
	/// Checks distance from the next node in list to update velocity
	/// </summary>
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
				if(Vector3.Distance(transform.position, node2.transform.position) <= .5f){
					reached2 = true;
					currentNode++;
					moveToNode(currentNode);
				}
			}
			break;
		case 3:
			if(!reached3){
				if(Vector3.Distance(transform.position, node3.transform.position) <= .5f){
					reached3 = true;
					currentNode++;
					moveToNode(currentNode);
				}
			}
			break;
		case 4:
			if(!reachedEnd){
				if(Vector3.Distance(transform.position, endNode.transform.position) <= .5f){
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

	/// <summary>
	/// Switches velocity based on current node(waypoint)
	/// </summary>
	/// <param name="current">Current.</param>
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

	void deleteSat(){
		if(transform.position.x >= deleteZone){
			Destroy (gameObject);
		}
	}
}
