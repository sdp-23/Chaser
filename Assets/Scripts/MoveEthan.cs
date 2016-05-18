// ClickToMove.cs
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof (NavMeshAgent))]
public class MoveEthan : MonoBehaviour {

	NavMeshAgent agent;

	private float speedDiff = 1.0f;
	public GameObject mainCamera;
	public Text text;
	public float winCount = 5f;
	public GameObject horse;

	public bool tense = false;
	public bool end = false;

	void Start () {
		agent = GetComponent<NavMeshAgent> ();
		text.enabled = false;
	}
	void Update () {
		
		float x = transform.position.x;
		float y = transform.position.y;
		float z = transform.position.z;

		if (Input.GetKey(KeyCode.LeftShift)) {
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
		if (Vector3.Distance (transform.position, horse.transform.position) <= 15) {
			tense = true;
			text.enabled = true;
			text.text = "Seconds needed to be near the horse: " + ((int)winCount).ToString ();
			winCount -= Time.deltaTime;
			if (winCount <= 0f) {
				end = true;
				Time.timeScale = 0;
			}
		} else {
			tense = false;
			text.enabled = false;
			winCount = 5f;
		}
	}
}
