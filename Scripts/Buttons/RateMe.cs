using UnityEngine;
using System.Collections;

public class RateMe : MonoBehaviour {

	void OnMouseUpAsButton() {

		UniRate.Instance.RateIfNetworkAvailable();
		
	}
}
