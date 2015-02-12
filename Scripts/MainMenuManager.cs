using UnityEngine;
using System.Collections;

public class MainMenuManager : MonoBehaviour {
	public GameObject optionsMenu;

	private static MainMenuManager _instance;
	public static MainMenuManager instance
	{
		get
		{
			if(_instance == null)
				_instance = GameObject.FindObjectOfType<MainMenuManager>();
			return _instance;
		}
	}

	void Awake () {
		Time.timeScale = 1.0f;
		PlayerPrefs.SetInt ("First Playthrough", 0);
	}
}
