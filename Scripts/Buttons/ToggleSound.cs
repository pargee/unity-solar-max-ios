using UnityEngine;
using System.Collections;

public class ToggleSound : MonoBehaviour {

	void OnMouseUpAsButton() {
		SoundManager.instance.ToggleSound ();

	}
}
