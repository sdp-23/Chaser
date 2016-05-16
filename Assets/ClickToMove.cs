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
		if (Input.GetKey(KeyCode.UpArrow)) {
			agent.destination = new Vector3(x,y,z+1);
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			agent.destination = new Vector3(x,y,z-1);
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			agent.destination = new Vector3(x-1,y,z);
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			agent.destination = new Vector3(x+1,y,z);
		}
	}
}
