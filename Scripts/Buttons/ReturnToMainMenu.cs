using UnityEngine;
using System.Collections;

public class ReturnToMainMenu : MonoBehaviour {

	void OnMouseUpAsButton() {
		GameManager.instance.DetermineInsterstitial();
		Application.LoadLevel(0);
	}
}
