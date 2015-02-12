using UnityEngine;
using System.Collections;

public class PauseMenuManager : MonoBehaviour {
	public GameObject pauseButton;
	public GameObject leftThrusterTutorial;
	public GameObject rightThrusterTutorial;
	public GameObject bothThrustersTutorial;
	public bool bothThrusterActive = false;
	public bool leftThrusterActive = false;
	public bool rightThrusterActive = false;
	public GUIText scoreText;
	public GUIText pauseScoreText;
	public GUIText pauseScoreTitle;

	private static PauseMenuManager _instance;
	public static PauseMenuManager instance
	{
		get
		{
			if(_instance == null)
				_instance = GameObject.FindObjectOfType<PauseMenuManager>();
			return _instance;
		}
	}

	void OnEnable () {
		scoreText.gameObject.SetActive (false);
		if (leftThrusterTutorial.activeSelf) {
			leftThrusterActive = true;
			leftThrusterTutorial.SetActive(false);
		}
		if (rightThrusterTutorial.activeSelf) {
			rightThrusterActive = true;
			rightThrusterTutorial.SetActive(false);
		}
		if (bothThrustersTutorial.activeSelf) {
			bothThrusterActive = true;
			bothThrustersTutorial.SetActive(false);
		}
		pauseScoreText.gameObject.SetActive (true);
		pauseScoreTitle.gameObject.SetActive (true);
	}

	void OnGUI () {
		pauseScoreText.text = scoreText.text;

	}
}
