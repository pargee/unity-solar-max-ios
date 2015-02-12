using UnityEngine;
using System.Collections;

public class PauseGame : MonoBehaviour {
	public AudioSource[] audioSourcesToPause;
	public GameObject pauseMenu;
	void OnMouseUpAsButton() {
		Time.timeScale = 0.0f;
		for (int i = 0; i < audioSourcesToPause.Length; i++) {
			if(audioSourcesToPause[i].isPlaying) { audioSourcesToPause[i].Stop();}
				}
		pauseMenu.SetActive(true);
		gameObject.SetActive(false);
	}	
}
