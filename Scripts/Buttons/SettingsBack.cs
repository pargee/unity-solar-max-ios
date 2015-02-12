using UnityEngine;
using System.Collections;

public class SettingsBack : MonoBehaviour {

	void OnMouseUpAsButton() {
		MainMenuManager.instance.gameObject.SetActive (true);
		MainMenuManager.instance.optionsMenu.gameObject.SetActive(false);
	}
}
