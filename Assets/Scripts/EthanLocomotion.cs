using UnityEngine;
using System.Collections;

[RequireComponent (typeof (NavMeshAgent))]
[RequireComponent (typeof (Animator))]
public class EthanLocomotion : MonoBehaviour {
	Animator anim;
	NavMeshAgent agent;
	AudioSource aud;

	Vector2 smoothDeltaPosition = Vector2.zero;
	Vector2 velocity = Vector2.zero;
	private float speed;

	private float soundTime = 0.33f;
	private bool audioStart = false;

	private float WALKING_SPEED = 1e2f;
	private float RUNNING_SPEED = 1e5f;
	void Start ()
	{
		anim = GetComponent<Animator> ();
		agent = GetComponent<NavMeshAgent> ();
		aud = GetComponent<AudioSource> ();

		// Don't update position automatically
		agent.updatePosition = false;
		speed = WALKING_SPEED;
	}
	
	void Update ()
	{
		Vector3 worldDeltaPosition = agent.nextPosition - transform.position;
		
		// Map 'worldDeltaPosition' to local space
		float dx = Vector3.Dot (transform.right, worldDeltaPosition);
		float dy = Vector3.Dot (transform.forward, worldDeltaPosition);
		Vector2 deltaPosition = new Vector2 (dx, dy);
		
		// Low-pass filter the deltaMove
		float smooth = Mathf.Min(1.0f, Time.deltaTime/0.15f);
		smoothDeltaPosition = Vector2.Lerp (smoothDeltaPosition, deltaPosition, smooth);
		
		// Update velocity if delta time is safe
		if (Time.deltaTime > 1e-5f)
			velocity = smoothDeltaPosition / Time.deltaTime;

		bool shouldMove = Input.GetKey (KeyCode.DownArrow) || Input.GetKey (KeyCode.UpArrow) || Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.LeftArrow);
		bool shouldRun = Input.GetKey(KeyCode.R);
		bool shouldWalk = false;

		if (shouldRun && shouldMove) {
			speed = RUNNING_SPEED;
		} else if (!shouldRun && shouldMove){
			speed = WALKING_SPEED;
			shouldWalk = true;
		}
		else{
			speed = 0f;
		}
						
		// Update animation parameters
		anim.SetBool ("move", shouldMove);
		anim.SetBool ("walk", shouldWalk);
		anim.SetBool ("run", shouldRun);

		agent.speed = speed;

		float soundDiff = 3.38f;
		if (shouldRun) {
			soundDiff = 0.23f;
		} else {
			soundDiff = 0.4f;
		}
		if (shouldMove) {
			if (audioStart) {
				if (soundTime <= 0.0f) {
					aud.Play ();
					soundTime = soundDiff;
				} else {
					soundTime -= Time.deltaTime;
				}
			} else {
				aud.Play ();
				audioStart = true;
				soundTime = soundDiff;
			}
		} else {
			soundTime = soundDiff;
			audioStart = false;
		}

		// Pull character towards agent
		//		if (worldDeltaPosition.magnitude > agent.radius)
		//			transform.position = agent.nextPosition - 0.9f*worldDeltaPosition;
		
		// Pull agent towards character
		//if (worldDeltaPosition.magnitude > agent.radius)
		//	agent.nextPosition = transform.position + 0.9f*worldDeltaPosition;
	}
	
	void OnAnimatorMove ()
	{
		// Update postion to agent position
		transform.position = agent.nextPosition;
		
		//		// Update position based on animation movement using navigation surface height
		//		Vector3 position = anim.rootPosition;
		//	
	}
}
