using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public float pukeThreshold;
	public float thrusterStrength;
	public float turnSpeed;
	public float angularCorrection;
	public Vector2 thrusterLeftOffset;
	public Vector2 thrusterRightOffset;

	public GameObject thrusterLeft;
	public GameObject thrusterRight;
	public GameObject puke;
	public GameObject player;
	public GameObject bothThrusterTutorial;
	public bool bSlowDown;

	private SlowDownHelper slowDownHelper;

	public AudioSource thrusterLeftAudio;
	public AudioSource thrusterRightAudio;

	private Animator cameraAnimator;

	private Animator animator;

	
	void Start () {
		slowDownHelper = GameObject.FindGameObjectWithTag ("SlowDown").GetComponent<SlowDownHelper> ();
		animator = player.GetComponent<Animator>();
		cameraAnimator = Camera.main.GetComponent<Animator>();
		thrusterLeftAudio = thrusterLeft.GetComponent<AudioSource> ();
		thrusterRightAudio = thrusterRight.GetComponent<AudioSource> ();
		DisableThruster (thrusterLeft);
		DisableThruster (thrusterRight);

	}
	
	void Update () {
		CheckForDeath ();
		CheckForSlowDown ();
	}

	void CheckForSlowDown () {
		if (!animator.GetBool ("bDead")) {
				if (rigidbody2D.velocity.magnitude > 1.4f) {
						if (!bSlowDown) {
								slowDownHelper.gameObject.SetActive (true);

								StartCoroutine (slowDownHelper.UpdateSlowDownText (0.05f));
								bSlowDown = true;
						}
				} else {
						slowDownHelper.gameObject.SetActive (false);
						bSlowDown = false;
				}
		} else {
			slowDownHelper.gameObject.SetActive (false);
		}
	
	}

void FixedUpdate () {
		if (!animator.GetBool ("bDead")) {
			
			if(ScreenRight.instance.rightScreen) {
				EnableThruster (thrusterRight);
				if(!thrusterRightAudio.isPlaying == true) {
					thrusterRightAudio.Play ();
				}
			}
			else if(!ScreenRight.instance.rightScreen){
				DisableThruster (thrusterRight);
				thrusterRightAudio.Stop ();
			}

			if(ScreenLeft.instance.leftScreen) {

				EnableThruster (thrusterLeft);
				if(!thrusterLeftAudio.isPlaying == true) {
					thrusterLeftAudio.Play ();
				}
			}
			else if(!ScreenLeft.instance.leftScreen){
				DisableThruster (thrusterLeft);
				thrusterLeftAudio.Stop ();
			}
			if(ScreenLeft.instance.leftScreen && ScreenRight.instance.rightScreen) {
				bothThrusterTutorial.SetActive(false);
			}
		

#if UNITY_EDITOR
		if (Input.GetKey (KeyCode.D)) {
				EnableThruster (thrusterLeft);
				if(!thrusterLeftAudio.isPlaying == true) {
					thrusterLeftAudio.Play ();
				}

		} else {
				DisableThruster (thrusterLeft);
				thrusterLeftAudio.Stop ();

		}

		if (Input.GetKey (KeyCode.A)) {
				EnableThruster (thrusterRight);
				if(!thrusterRightAudio.isPlaying == true) {
					thrusterRightAudio.Play ();
				}

		} else {
				DisableThruster (thrusterRight);
				thrusterRightAudio.Stop ();

		}
#endif 
			CheckForPuke ();

		}
		CheckPosition ();

	}

	void OnCollisionEnter2D (Collision2D other) {
		int randomIndex;
		if (rigidbody2D.velocity.magnitude > 0.15f && rigidbody2D.velocity.magnitude < 0.6f) {
			randomIndex = Random.Range(0, 4);
			SoundManager.instance.Play(SoundManager.instance.playerSounds[randomIndex]);
			cameraAnimator.SetTrigger("PlayerHit");
		} else if (rigidbody2D.velocity.magnitude > 0.6f) {
			randomIndex = Random.Range(5, 6);
			cameraAnimator.SetTrigger("PlayerHitHard");

			SoundManager.instance.Play(SoundManager.instance.playerSounds[randomIndex]);

		}

	}


	void EnableThruster (GameObject thruster) {
		if (thruster.gameObject == thrusterLeft) {
			if(rigidbody2D.angularVelocity < 0) {
				rigidbody2D.AddTorque(-turnSpeed);
			}
			else {
				rigidbody2D.AddTorque(-turnSpeed * angularCorrection);
			}
		} else {
			if(rigidbody2D.angularVelocity > 0) {
				rigidbody2D.AddTorque(turnSpeed);
			}
			else {
				rigidbody2D.AddTorque(turnSpeed * angularCorrection);
			}
		}

		rigidbody2D.velocity += new Vector2 (transform.up.x * thrusterStrength / 100, transform.up.y * thrusterStrength / 100);
		//rigidbody2D.AddForce(transform.up * (rigidbody2D.velocity.magnitude * thrusterStrength + 1), ForceMode2D.Impulse);
		//rigidbody2D.AddForceAtPosition(transform.up * thrusterStrength, new Vector3(thruster.transform.position.x + thrusterOffset.x, thruster.transform.position.y + thrusterOffset.y, thruster.transform.position.z), ForceMode2D.Force);
		thruster.GetComponent<ParticleSystem>().enableEmission = true;
	}

	void DisableThruster (GameObject thruster) {
		thruster.GetComponent<ParticleSystem>().enableEmission = false;
	}

	void CheckForPuke () {
		if(rigidbody2D.angularVelocity < -pukeThreshold || rigidbody2D.angularVelocity > pukeThreshold) {
			ParticleSystem pukeFX = puke.GetComponent<ParticleSystem>();
			AudioSource pukeSound = puke.GetComponent<AudioSource>();
			if(!pukeFX.isPlaying) {
				pukeFX.Play ();
			}
			if(!pukeSound.isPlaying) {
				pukeSound.Play();

			}

			puke.GetComponent<ParticleSystem>().enableEmission = true;
			animator.SetBool("bSick", true);
				
		}
		else {
			puke.GetComponent<ParticleSystem>().enableEmission = false;
			animator.SetBool("bSick", false);
		}
	}

	void CheckForDeath () {
		if (animator.GetBool ("bDead")) {
			thrusterRightAudio.Stop ();
			thrusterLeftAudio.Stop ();

			DisableThruster (thrusterLeft);
			DisableThruster (thrusterRight);

		}
	}

	void CheckPosition () {
		if (transform.position.x > Literals.lWorldScale) {
			transform.position = new Vector3(-Literals.lWorldScale, transform.position.y, transform.position.z);
		}
		else if (transform.position.y > Literals.lWorldScale) {
			transform.position = new Vector3(transform.position.x, -Literals.lWorldScale, transform.position.z);
		}
		else if (transform.position.x < -Literals.lWorldScale) {
			transform.position = new Vector3(Literals.lWorldScale, transform.position.y, transform.position.z);
		}
		else if (transform.position.y < -Literals.lWorldScale) {
			transform.position = new Vector3(transform.position.x, Literals.lWorldScale, transform.position.z);
		}
	}


}
