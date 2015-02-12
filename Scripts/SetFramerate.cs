using UnityEngine;
using System.Collections;

public class SetFramerate : MonoBehaviour {

	void Awake () {
		Application.targetFrameRate = 60;
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
	}

}
