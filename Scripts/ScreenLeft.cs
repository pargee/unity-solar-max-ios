using UnityEngine;
using System.Collections;

public class ScreenLeft : MonoBehaviour {
	public bool leftScreen;
	private static ScreenLeft _instance;
	public static ScreenLeft instance
	{
		get
		{
			if(_instance == null)
				_instance = GameObject.FindObjectOfType<ScreenLeft>();
			return _instance;
		}
	}
	void Update() {
		for (int i = 0; i < Input.touchCount; i++) {
				Touch touch = Input.GetTouch (i);
				if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Stationary) {
						if (touch.position.x < (Screen.width / 2)) {
								leftScreen = true;
						}

				} 
			else if(touch.phase == TouchPhase.Moved) {
				if (touch.position.x > (Screen.width / 2) && Input.touchCount == 1) {
					leftScreen = false;
				}
			}
			else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled) {
					leftScreen = false;
				}
		}
	}

}
