using UnityEngine;
using System.Collections;

public class ShowLeaderboards : MonoBehaviour {
	void OnMouseUpAsButton() {
		SocialAPI.instance.showLeaderboard = true;

	}
}
