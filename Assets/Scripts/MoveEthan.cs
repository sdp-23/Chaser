﻿// ClickToMove.cs
using UnityEngine;

[RequireComponent (typeof (NavMeshAgent))]
public class MoveEthan : MonoBehaviour {

	NavMeshAgent agent;

	private float speedDiff = 1.0f;
	public GameObject mainCamera;
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
	}
	void Update () {
		
		float x = transform.position.x;
		float y = transform.position.y;
		float z = transform.position.z;

		if (Input.GetKey(KeyCode.R)) {
			speedDiff = 5.0f;
		}

		if (Input.GetKey (KeyCode.UpArrow)) {

			if (Input.GetKey (KeyCode.LeftArrow)) {
				agent.destination = new Vector3 (x - (agent.radius*speedDiff), y, z + (agent.radius*speedDiff));
			}
			else if (Input.GetKey (KeyCode.RightArrow)) {
						agent.destination = new Vector3 (x + (agent.radius*speedDiff), y, z + (agent.radius*speedDiff));
			} else {
				//agent.destination = new Vector3 (x+mainCamera.transform.forward.x, y, z + (agent.radius*speedDiff)+mainCamera.transform.forward.z);
				agent.destination = new Vector3 (x, y, z + (agent.radius*speedDiff));

			}
		} 

		else if (Input.GetKey (KeyCode.DownArrow)) {
			if (Input.GetKey (KeyCode.LeftArrow)) {
				agent.destination = new Vector3 (x - (agent.radius*speedDiff), y, z - (agent.radius*speedDiff));
			}
			else if (Input.GetKey (KeyCode.RightArrow)) {
				agent.destination = new Vector3 (x + (agent.radius*speedDiff), y, z - (agent.radius*speedDiff));
			} else {
				agent.destination = new Vector3 (x, y, z - (agent.radius*speedDiff));
			}
		} 

		else if (Input.GetKey (KeyCode.LeftArrow)) {
			if (Input.GetKey (KeyCode.UpArrow)) {
				agent.destination = new Vector3 (x - (agent.radius*speedDiff), y, z + (agent.radius*speedDiff));
			}
			else if (Input.GetKey (KeyCode.DownArrow)) {
				agent.destination = new Vector3 (x - (agent.radius*speedDiff), y, z - (agent.radius*speedDiff));
			} else {
				agent.destination = new Vector3 (x - (agent.radius*speedDiff), y, z);
			}
		} 

		else if (Input.GetKey (KeyCode.RightArrow)) {
			if (Input.GetKey (KeyCode.UpArrow)) {
				agent.destination = new Vector3 (x + (agent.radius*speedDiff), y, z + (agent.radius*speedDiff));
			}
			else if (Input.GetKey (KeyCode.DownArrow)) {
				agent.destination = new Vector3 (x + (agent.radius*speedDiff), y, z - (agent.radius*speedDiff));
			} else {
				agent.destination = new Vector3 (x + (agent.radius*speedDiff), y, z);
			}
		} 
		else {
			agent.destination = transform.position;
		}
	}
}
