using UnityEngine;
using System.Collections;

public class ChewDebris : MonoBehaviour {
	public GameObject playerObject;

	void Start () {
		playerObject = GameObject.FindGameObjectWithTag ("Player");
		StartCoroutine (RecycleChew (1.0f));
	}

	IEnumerator RecycleChew (float waitTime) {
		Debug.Log ("Chomp?");
		yield return new WaitForSeconds (waitTime);
		Debug.Log ("CHOMP");
		this.Recycle ();
	}
	
	void Update () {
		transform.position = playerObject.transform.position;
	}
}
