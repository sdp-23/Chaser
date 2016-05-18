using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject player;

	private Vector3 offset;

	void Start()
	{
		offset = transform.position - player.transform.position;
	}

	void LateUpdate()
	{
		transform.position = player.transform.position + offset;
		//transform.rotation = new Quaternion(transform.rotation.x, player.transform.rotation.y, player.transform.rotation.z, transform.rotation.w);
		float xValue = 0f;
		float yValue = 0f;

		if (Input.GetKey (KeyCode.A)) {
			yValue = -45;
		}
		if (Input.GetKey (KeyCode.D)) {
			yValue = 45;
		}

		float new_x = 0f;
		if (transform.rotation.eulerAngles.x > 180) {
			new_x = transform.rotation.eulerAngles.x - 360;
		} else {
			new_x = transform.rotation.eulerAngles.x;
		}

		if (Input.GetKey (KeyCode.W) && (new_x > -20)) {
			xValue = -45;
		}
		if (Input.GetKey (KeyCode.S) && (new_x < 30)) {
			xValue = 45;
		}
		transform.Rotate(new Vector3(0f, yValue, 0f)* Time.deltaTime, Space.World);
		transform.Rotate(new Vector3(xValue, 0f, 0f)* Time.deltaTime);

		/*if (transform.rotation.eulerAngles.x > 70 ) {
			transform.rotation = Quaternion.Euler(70, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
		}
		else if (transform.rotation.eulerAngles.x < -70 ) {
			transform.rotation = Quaternion.Euler(-70, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
		}
		*/
	}
}
