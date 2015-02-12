using UnityEngine;
using System.Collections;

public class ToggleMusic : MonoBehaviour {

	void OnMouseUpAsButton() {
		MusicManager.instance.ToggleMusic ();
	}
}
