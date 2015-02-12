using UnityEngine;
using System.Collections;

public class ResumeGame : MonoBehaviour {

	void OnMouseUpAsButton() {
		Time.timeScale = 1.0f;
		PauseMenuManager.instance.scoreText.gameObject.SetActive (true);
		PauseMenuManager.instance.pauseScoreText.gameObject.SetActive (false);
		PauseMenuManager.instance.pauseScoreTitle.gameObject.SetActive (false);
		PauseMenuManager.instance.pauseButton.SetActive(true);
		PauseMenuManager.instance.gameObject.SetActive (false);
		if (PauseMenuManager.instance.leftThrusterActive == true) {
			PauseMenuManager.instance.leftThrusterTutorial.SetActive (true);
			PauseMenuManager.instance.leftThrusterActive = false;
			Debug.Log ("left is true");
		}
		if (PauseMenuManager.instance.rightThrusterActive == true) {
			PauseMenuManager.instance.rightThrusterTutorial.SetActive (true);
			PauseMenuManager.instance.rightThrusterActive = false;

			Debug.Log ("right is true");

		}
		if (PauseMenuManager.instance.bothThrusterActive == true) {
			PauseMenuManager.instance.bothThrustersTutorial.SetActive (true);
			PauseMenuManager.instance.bothThrusterActive = false;
			
			Debug.Log ("right is true");
			
		}
	}
}
