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
		/*if(Input.GetMouseButtonDown(0)) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray.origin, ray.direction, out hitInfo))
				agent.destination = hitInfo.point;
		}*/
		
		float x = transform.position.x;
		float y = transform.position.y;
		float z = transform.position.z;
		bool walk = false;
		if (Input.GetKey (KeyCode.UpArrow)) {
			walk = true;
			agent.destination = new Vector3 (x, y, z + (agent.radius));
		} else if (Input.GetKey (KeyCode.DownArrow)) {
			walk = true;
			agent.destination = new Vector3 (x, y, z - (agent.radius));
		} else if (Input.GetKey (KeyCode.LeftArrow)) {
			walk = true;
			agent.destination = new Vector3 (x - (agent.radius), y, z);
		} else if (Input.GetKey (KeyCode.RightArrow)) {
			walk = true;
			agent.destination = new Vector3 (x + (agent.radius), y, z);
		} else {
			agent.destination = transform.position;
		}
		//GetComponent<AstrellaLocomotion> ().shouldWalk = walk;
	}
}
