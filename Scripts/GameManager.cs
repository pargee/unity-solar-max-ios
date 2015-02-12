using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public GameObject goPlayer;
	public GameObject goChewFX;
	public GameObject gameOverMenu;
	public GameObject tutorialObject;
	public GameObject pauseButton;

	public GameObject[] followObject;
	public GUIText scoreText;
	public float scoreTick;
	public float scoreColorTick;
	public int score;
	private float frequency = 0.3f;
	public bool bGameOver = false;

	public GameObject player;
	private Animator animator;

	private static GameManager _instance;
	public static GameManager instance
	{
		get
		{
			if(_instance == null)
				_instance = GameObject.FindObjectOfType<GameManager>();
			return _instance;
		}
	}

	void Awake () {
		CheckForFirstPlaythrough ();

	}

	void CheckForFirstPlaythrough() {
		if (PlayerPrefs.GetInt ("First Playthrough") == 0) {
			tutorialObject.SetActive (true);
			pauseButton.SetActive(false);
			scoreText.gameObject.SetActive(false);
			Time.timeScale = 0.0f;


		} else {
			Time.timeScale = 1.0f;

		}
	}

	void Start () {
		animator = player.GetComponent<Animator>();

		StartCoroutine (UpdateScore(scoreTick));
		StartCoroutine (UpdateScoreColor(scoreColorTick));

	}

	void Update () {
		UpdateCamera ();
		FollowPlayer ();
		if(bGameOver) {
			gameOverMenu.SetActive(true);
		}
	}

	void FollowPlayer () {
		for (int i = 0; i < followObject.Length; i++) {
			followObject[i].transform.position = new Vector3(goPlayer.transform.position.x, goPlayer.transform.position.y, followObject[i].transform.position.z);		
		}
	}

	void UpdateCamera () {
		Camera.main.transform.position = new Vector3(goPlayer.transform.position.x, goPlayer.transform.position.y, Camera.main.transform.position.z);
	}

	public void TriggerGameOver () {
		CheckForNewHiScore ();
		bGameOver = true;
	}

	void CheckForNewHiScore () {
		int currentHiScore = PlayerPrefs.GetInt ("Hi-Score");
		int currentTotalScore = PlayerPrefs.GetInt ("Total Score");
		if (score > currentHiScore || currentHiScore == 0 || currentHiScore == null) {
			PlayerPrefs.SetInt("Hi-Score", score);
			Social.Active.ReportScore (score, Literals.lDefaultLeaderboard, HandleReportScore);
		}

		PlayerPrefs.SetInt ("Total Score", currentTotalScore + score);
		Social.Active.ReportScore (PlayerPrefs.GetInt ("Total Score"), Literals.lTotalScoreLeaderboard, HandleReportScore);
	}
	void HandleReportScore(bool a_success)
	{
		Debug.Log(a_success ? "Reported score successfully" : "Failed to report score");
	}

	IEnumerator UpdateScore (float tick) {
		while(true) {
			yield return new WaitForSeconds(tick);
			score++;
			if(animator.GetBool("bDead")) {
				break;
			}
		}
	}

	public void AddScore (int bonus) {
		score += bonus;
		StartCoroutine (PulseScoreText ());
	}

	IEnumerator PulseScoreText () {
		scoreText.fontSize *= 2;
		yield return new WaitForSeconds (0.15f);
		scoreText.fontSize /= 2;
	}

	IEnumerator UpdateScoreColor (float tick) {
		while(true) {
			yield return new WaitForSeconds(tick);
			int mult = Random.Range (0, 32);
			float red   = Mathf.Abs (Mathf.Sin(frequency*mult + 0) * 0.49f + 0.5f);
			float green = Mathf.Abs (Mathf.Sin(frequency*mult + 2) * 0.49f + 0.5f);
			float blue  = Mathf.Abs (Mathf.Sin(frequency*mult + 4) * 0.49f + 0.5f);

			Color newColor = new Color( red, green, blue);
			scoreText.color = newColor;
		}
	}

	public void DetermineInsterstitial () {
		PlayerPrefs.SetFloat("Play Count", PlayerPrefs.GetFloat("Play Count")+1);
		if (PlayerPrefs.GetFloat ("Play Count") % 3 == 0) {
			AppLovin.HideAd();
			AppLovin.ShowInterstitial();
		}
	}

	void OnGUI () {
		scoreText.text = score.ToString();

	}

}
