using UnityEngine;
using System.Collections;

public class RestartGame : MonoBehaviour {

	void OnMouseUpAsButton() {
		GameManager.instance.DetermineInsterstitial();
		Application.LoadLevel(1);
	}
}
