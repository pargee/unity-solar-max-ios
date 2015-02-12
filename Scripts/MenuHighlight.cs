using UnityEngine;
using System.Collections;

public class MenuHighlight : MonoBehaviour {
	public Sprite startingSprite;
	public Sprite highlightSprite;
	public bool buttonPressed = false;
	
	void Start () {
		startingSprite = gameObject.GetComponent<SpriteRenderer> ().sprite;
	}
	
	void OnMouseDown () {
		SoundManager.instance.Play (SoundManager.instance.userInterfaceSounds [0]);
		SoundManager.instance.Play (SoundManager.instance.userInterfaceSounds [1]);

		SetHighlightSprite ();

	}

	void OnMouseUp () {
		ResetSprite ();
	}
	void OnMouseEnter () {
		if(Input.GetMouseButton(0) && buttonPressed) { 
			SetHighlightSprite (); 
		}
	}

	void OnMouseExit () {
		ResetSprite ();
	}

	void OnDisable() {
		ResetSprite ();
	}

	void SetHighlightSprite () {
		buttonPressed = true;
		gameObject.GetComponent<SpriteRenderer> ().sprite = highlightSprite;

	}

	void ResetSprite () {
		if (buttonPressed) {
			gameObject.GetComponent<SpriteRenderer> ().sprite = startingSprite;
	
			buttonPressed = false;
		}
	
	}
}
