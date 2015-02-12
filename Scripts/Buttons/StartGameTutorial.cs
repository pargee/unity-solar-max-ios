using UnityEngine;
using System.Collections;

public class StartGameTutorial : MonoBehaviour {
	public GameObject pauseButton;
	public GameObject scoreText;
	public GameObject ThrusterTutorial;

	void OnMouseUpAsButton() {
		PlayerPrefs.SetInt ("First Playthrough", 1);
		pauseButton.SetActive (true);
		transform.parent.gameObject.SetActive (false);
		scoreText.SetActive(true);
		ThrusterTutorial.SetActive (true);
		Time.timeScale = 1.0f;
	}
}
