using UnityEngine;
using System.Collections;

public class ShowSettings : MonoBehaviour {

	void OnMouseUpAsButton() {
		MainMenuManager.instance.gameObject.SetActive (false);
		MainMenuManager.instance.optionsMenu.gameObject.SetActive(true);

	}
}
