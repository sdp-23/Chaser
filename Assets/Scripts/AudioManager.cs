using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour {

	public GameObject sphere;
	public GameObject ethan;
	public GameObject horse;
	HorseLocomotion hl;
	public float timer = 0;
	public float timer2 = 0;
	AudioSource aud;

	public bool freeze = false;
	public float prevWalk = 0;
	private bool saved = false;
	public float prevRun = 0;
	// Use this for initialization
	void Start(){
		aud = GetComponent<AudioSource> ();

		hl = horse.GetComponent<HorseLocomotion> ();
	}
	void Update(){
		timer += Time.deltaTime;
		if (timer >= 5 && timer < 10) {
			if (sphere.activeInHierarchy == false) {
				float new_x = Random.Range (-110, 110);
				float new_z = Random.Range (-110, 110);
				//sphere.transform.position = new Vector3 (new_x, sphere.transform.position.y, new_z);
				sphere.SetActive(true);
			}
		} else if(timer < 5) {
			sphere.SetActive(false);
		}
		if (timer >= 10) {
			timer = 0;
		}
		if (sphere.activeInHierarchy && Mathf.Abs (sphere.transform.position.x - ethan.transform.position.x) <= 5 && Mathf.Abs (sphere.transform.position.z - ethan.transform.position.z) <= 5) {
			aud.Play ();
			sphere.SetActive (false);
			timer = 0;
			timer2 = 0;
			freeze = true;
		}

		if (freeze) {
			timer2 += Time.deltaTime;
			if (timer2 <= 5) {
				if (saved == false) {
					prevWalk = hl.WALKING_SPEED;
					prevRun = hl.RUNNING_SPEED;
					hl.WALKING_SPEED = 0;
					hl.RUNNING_SPEED = 0;
					saved = true;
				}
			} else {
				timer2 = 0;
				hl.WALKING_SPEED = prevWalk;
				hl.RUNNING_SPEED = prevRun;
				freeze = false;
				saved = false;
			}
		} 

	}
}
