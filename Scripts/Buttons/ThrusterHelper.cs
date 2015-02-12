using UnityEngine;
using System.Collections;

public class ThrusterHelper : MonoBehaviour {
	private TutorialChecker tutorialChecker;
	public GameObject tutorialCheckerObject;
	void OnMouseDown () {
		if (this.gameObject.name == "thrusterRightTutorial") {
						tutorialChecker.rightThrusterPressed = true;
						gameObject.SetActive (false);
				} else {
			tutorialChecker.leftThrusterPressed = true;
			gameObject.SetActive (false);
				}
	}
	
	void Start () {
		tutorialChecker = tutorialCheckerObject.GetComponent<TutorialChecker> ();
	}
	
	
	void Update () {

	}
}
