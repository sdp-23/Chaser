using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private Rigidbody rb;
	public float speed;
	private Animation an;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		an = GetComponent<Animation> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
		movement = movement * Time.deltaTime*speed;
		transform.position = transform.position + movement;
		if (Input.GetKey (KeyCode.UpArrow)) {
			an.Play ("run");
		} else {
			an.Play ("idle");
		}
	}


	void FixedUpdate()
	{
		/*float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

		rb.AddForce(movement * speed * Time.deltaTime);

		*/

	}
}
