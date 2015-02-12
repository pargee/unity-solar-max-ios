using UnityEngine;
using System.Collections;

public class ShowAchievements : MonoBehaviour {
	void OnMouseUpAsButton() {
		SocialAPI.instance.showSocialWindow = true;

	}
}
