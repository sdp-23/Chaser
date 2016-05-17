// ClickToMove.cs
using UnityEngine;

[RequireComponent (typeof (NavMeshAgent))]
public class ClickToMove : MonoBehaviour {
	RaycastHit hitInfo = new RaycastHit();
	NavMeshAgent agent;
	
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
	}
	void Update () {
		
		float x = transform.position.x;
		float y = transform.position.y;
		float z = transform.position.z;

		if (Input.GetKey (KeyCode.UpArrow)) {

			if (Input.GetKey (KeyCode.LeftArrow)) {
				agent.destination = new Vector3 (x - (agent.radius), y, z + (agent.radius));
			}
			else if (Input.GetKey (KeyCode.RightArrow)) {
						agent.destination = new Vector3 (x + (agent.radius), y, z + (agent.radius));
			} else {
				agent.destination = new Vector3 (x, y, z + (agent.radius));
			}
		} 

		else if (Input.GetKey (KeyCode.DownArrow)) {
			if (Input.GetKey (KeyCode.LeftArrow)) {
				agent.destination = new Vector3 (x - (agent.radius), y, z - (agent.radius));
			}
			else if (Input.GetKey (KeyCode.RightArrow)) {
				agent.destination = new Vector3 (x + (agent.radius), y, z - (agent.radius));
			} else {
				agent.destination = new Vector3 (x, y, z - (agent.radius));
			}
		} 

		else if (Input.GetKey (KeyCode.LeftArrow)) {
			if (Input.GetKey (KeyCode.UpArrow)) {
				agent.destination = new Vector3 (x - (agent.radius), y, z + (agent.radius));
			}
			else if (Input.GetKey (KeyCode.DownArrow)) {
				agent.destination = new Vector3 (x - (agent.radius), y, z - (agent.radius));
			} else {
				agent.destination = new Vector3 (x - (agent.radius), y, z);
			}
		} 

		else if (Input.GetKey (KeyCode.RightArrow)) {
			if (Input.GetKey (KeyCode.UpArrow)) {
				agent.destination = new Vector3 (x + (agent.radius), y, z + (agent.radius));
			}
			else if (Input.GetKey (KeyCode.DownArrow)) {
				agent.destination = new Vector3 (x + (agent.radius), y, z - (agent.radius));
			} else {
				agent.destination = new Vector3 (x + (agent.radius), y, z);
			}
		} 
		else {
			agent.destination = transform.position;
		}
	}
}
