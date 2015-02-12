using UnityEngine;
using System.Collections;

public class EnvironmentSweep : MonoBehaviour {

	
	void Start () {
	
	}
	
	
	void Update () {
	
	}

	void OnTriggerStay2D(Collider2D other) {
		if (other.tag == "Environmental") {
			other.GetComponent<Environmental>().HandlePhysics();

		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.tag == "Environmental") {
			other.GetComponent<Environmental>().DisablePhysics();
			
		}
	}
}
