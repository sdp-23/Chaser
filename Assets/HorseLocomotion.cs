using UnityEngine;
using System.Collections;

public class HorseLocomotion : MonoBehaviour {

	Animator anim;
	NavMeshAgent agent;
	AudioSource aud;

	Vector2 smoothDeltaPosition = Vector2.zero;
	Vector2 velocity = Vector2.zero;
	private float speed = 0;
	public bool shouldMove;
	public bool shouldRun;
	public bool shouldWalk;

	private float soundTime = 0.33f;
	private bool audioStart = false;

	public float WALKING_SPEED = 5f;
	private float RUNNING_SPEED = 10f;
	void Start ()
	{
		anim = GetComponent<Animator> ();
		agent = GetComponent<NavMeshAgent> ();
		aud = GetComponent<AudioSource> ();

		// Don't update position automatically
		agent.updatePosition = false;
		shouldRun = false;
		shouldMove = true;
		shouldWalk = true;
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


		if (shouldWalk && !shouldRun) {
			speed = WALKING_SPEED;
		} else if (shouldRun && !shouldWalk) {
			speed = RUNNING_SPEED;	
		} else {
			speed = 0;
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

	}

	void OnAnimatorMove ()
	{
		// Update postion to agent position
		transform.position = agent.nextPosition;
	}
}
