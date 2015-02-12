using UnityEngine;
using System.Collections;

public class GameOverMenuManager : MonoBehaviour {

	public GameObject pauseButton;
	public GUIText scoreText;
	public GUIText gameOverScoreText;
	public GUIText gameOverScoreTitle;
	public GUIText gameOverHiScoreText;
	public GUIText gameOverHiScoreTitle;

	void Start () {
		pauseButton.SetActive(false);
		//CheckForNewHiScore (GameManager.instance.score);
	}

	void OnEnable () {
		scoreText.gameObject.SetActive (false);
		gameOverScoreText.gameObject.SetActive (true);
		gameOverScoreTitle.gameObject.SetActive (true);
		gameOverHiScoreText.gameObject.SetActive (true);
		gameOverHiScoreTitle.gameObject.SetActive (true);
	}

	void OnGUI () {
		gameOverScoreText.text = scoreText.text;
		gameOverHiScoreText.text = PlayerPrefs.GetInt ("Hi-Score").ToString ();

	}
}
