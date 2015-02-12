using UnityEngine;
using System.Collections;

public class Collectable : MonoBehaviour {
	public GameObject player;

	private Animator animator;
	private PlayerOxygen playerOxygen;
	public int bonusPoints;
	public ChewDebris chewDebrisPrefab;
	public GameObject collectSnaxEffects;
	public GameObject collectOxygenEffects;
	
	void Awake () {

	}

	void Start () {
		playerOxygen = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerOxygen> ();
		player = GameManager.instance.player;
		animator = player.GetComponent<Animator>();
		collectOxygenEffects = GameObject.FindGameObjectWithTag ("FX_Oxygen");
		collectSnaxEffects = GameObject.FindGameObjectWithTag ("FX_Snax");

	}
	
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Player" && !GameManager.instance.bGameOver) {
			switch (this.gameObject.tag) {
			case "COL_Oxygen":
				playerOxygen.RefillOxygen();
				collectOxygenEffects.transform.position = transform.position;
				collectOxygenEffects.GetComponent<ParticleSystem>().Play ();
				SoundManager.instance.Play (SoundManager.instance.gameplaySounds[1]);
				break;
			case "COL_Snax":
				GameManager.instance.AddScore(bonusPoints);
				animator.SetTrigger("tChew");
				GameManager.instance.goChewFX.GetComponent<ParticleSystem>().Play();
				collectSnaxEffects.transform.position = transform.position;
				collectSnaxEffects.GetComponent<ParticleSystem>().Play ();
				SoundManager.instance.Play (SoundManager.instance.gameplaySounds[0]);

				//chewDebrisPrefab.Spawn(player.transform.position);
				break;
			default:
				break;
			}
			this.Recycle();
		}
	}

}
