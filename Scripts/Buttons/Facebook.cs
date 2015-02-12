using UnityEngine;
using System.Collections;

public class Facebook : MonoBehaviour {

	private string text = "Sample Text";
	private string url = "facebook.com/solarmaxgame";
	
	void OnMouseUpAsButton() {
		if (Application.loadedLevel == 0) {
			text = "Guys. Seriously. @SolarMaxGame. NOW: ";
			
		} else {
			text = "Yup, I just got "+GameManager.instance.score.ToString()+" points in @SolarMaxGame! ";
		}
		
		#if UNITY_IPHONE
		if (Application.platform == RuntimePlatform.IPhonePlayer) {
			// Tweet (iOS 5.0 or later)
			iOS_PostToServices.PostToFacebook (text, url);
		}
		#endif
	}
}
