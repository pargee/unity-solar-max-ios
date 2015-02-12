using UnityEngine;
using System.Collections;

public class Environmental : MonoBehaviour {
	private float scale;
	public bool bScalable = true;
	private float initialForce = 4800.0f;
	public float massMultiplier = 120.0f;
	public bool stationary;
	public GameObject player;
	public bool forceApplied;

	void Awake () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	
	void OnEnable () {
		if (bScalable) {
			scale = Random.Range (0.8f, 2.0f);
		} else {
			scale = 1.0f;
		}
		transform.localScale = new Vector3(scale, scale, 1.0f);
		rigidbody2D.mass = (transform.localScale.x * transform.localScale.y)/2 * massMultiplier;
		rigidbody2D.isKinematic = true;

	}
	
	
	void FixedUpdate () {

	}

	public void HandlePhysics () {

		if(!forceApplied) {

			rigidbody2D.isKinematic = false;
			rigidbody2D.AddForce (new Vector2 (Random.Range (-initialForce, initialForce), Random.Range (-initialForce, initialForce)));
			forceApplied = true;
		}
	}

	public void DisablePhysics () {
		forceApplied = false;
		rigidbody2D.velocity = Vector2.zero;
		rigidbody2D.angularVelocity = 0;
		rigidbody2D.Sleep();
		rigidbody2D.isKinematic = true;
	}
}
