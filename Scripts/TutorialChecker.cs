using UnityEngine;
using System.Collections;

public class TutorialChecker : MonoBehaviour {
	public GameObject leftThrusterTutorial;
	public GameObject rightThrusterTutorial;
	public GameObject bothThrusterTutorial;
	public bool leftThrusterPressed;
	public bool rightThrusterPressed;
	public bool bothStarted;
	
	void Start () {
	
	}
	
	
	void Update () {
		if (leftThrusterPressed && rightThrusterPressed && !bothStarted) {
			bothThrusterTutorial.SetActive(true);
			bothStarted = true;
		}
	}
}
