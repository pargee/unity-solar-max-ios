using UnityEngine;
using System.Collections;

public class ScreenRight : MonoBehaviour {
	public bool rightScreen;
	private static ScreenRight _instance;
	public static ScreenRight instance
	{
		get
		{
			if(_instance == null)
				_instance = GameObject.FindObjectOfType<ScreenRight>();
			return _instance;
		}
	}

	void Update() {
		for (int i = 0; i < Input.touchCount; i++) {
				Touch touch = Input.GetTouch (i);
			if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Stationary) {
				if (touch.position.x > (Screen.width / 2)) {
								rightScreen = true;
						}
						
				} 
			else if(touch.phase == TouchPhase.Moved) {
				if (touch.position.x < (Screen.width / 2) && Input.touchCount == 1) {
					rightScreen = false;
				}
			}

			else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled) {
					rightScreen = false;
				}
		}

	}
}
