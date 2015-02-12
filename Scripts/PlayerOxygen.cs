using UnityEngine;
using System.Collections;

public class PlayerOxygen : MonoBehaviour {
	public float oxygenDecay;
	public float oxygenTick;
	private float oxygenMax;

	public GameObject oxygenMeter;
	private SpriteRenderer oxygenSprite;

	public Color oxygenAlertColor;
	public Color oxygenColor;

	public GameObject deathAlert;
	private AudioSource deathAlertAudio;

	public GameObject player;
	private Animator animator;


	void Start () {
		deathAlertAudio = deathAlert.GetComponent<AudioSource> ();

		animator = player.GetComponent<Animator>();

		oxygenSprite = oxygenMeter.GetComponent<SpriteRenderer>();
		oxygenColor = oxygenSprite.color;
		oxygenMax = oxygenMeter.transform.localScale.x;
		StartCoroutine(UpdateOxygen(oxygenTick));

	}

	public void RefillOxygen() {
		oxygenMeter.transform.localScale = new Vector3(oxygenMax, oxygenMeter.transform.localScale.y, oxygenMeter.transform.localScale.z);
		StartCoroutine (FlashOxygen (0.1f));
	}

	IEnumerator FlashOxygen(float waitTime) {
		oxygenSprite.color = Color.white;
		yield return new WaitForSeconds (waitTime);
		oxygenSprite.color = oxygenColor;
	}

	IEnumerator UpdateOxygen(float tick) {
		while(true) {
			yield return new WaitForSeconds(tick);
			oxygenMeter.transform.localScale = new Vector3(oxygenMeter.transform.localScale.x-oxygenDecay, oxygenMeter.transform.localScale.y, oxygenMeter.transform.localScale.z);

			if(oxygenMeter.transform.localScale.x <= 0.0f) {
				oxygenMeter.transform.localScale = new Vector3(0.0f, oxygenMeter.transform.localScale.y, oxygenMeter.transform.localScale.z);
				GameManager.instance.TriggerGameOver();
				SoundManager.instance.Play (SoundManager.instance.playerSounds[7]);
				animator.SetBool("bDead", true);
				break;
			}
			else if((oxygenMeter.transform.localScale.x/oxygenMax) <= 0.25f) {
				oxygenSprite.color = oxygenAlertColor;

				animator.SetBool("bOxygenLow", true);

			}

		}
	}

	void Update () {
		OxygenAlert ();
	}

	void OxygenAlert () {
		if ((oxygenMeter.transform.localScale.x / oxygenMax) > 0.25f && !GameManager.instance.bGameOver) {

			animator.SetBool("bOxygenLow", false);
			
		}
		if ((oxygenMeter.transform.localScale.x / oxygenMax) <= 0.25f && !GameManager.instance.bGameOver) {

			if (!deathAlertAudio.isPlaying) {
	
				deathAlertAudio.Play ();
			}
		} else {
			deathAlertAudio.Stop ();

		}
	}

}
