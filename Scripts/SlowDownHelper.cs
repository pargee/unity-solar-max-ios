using UnityEngine;
using System.Collections;

public class SlowDownHelper : MonoBehaviour {
	private float frequency = 0.3f;

	public IEnumerator UpdateSlowDownText (float tick) {
		while(true) {
			yield return new WaitForSeconds(tick);
			int mult = Random.Range (0, 32);
			float red   = Mathf.Abs (Mathf.Sin(frequency*mult + 0) * 0.49f + 0.5f);
			float green = Mathf.Abs (Mathf.Sin(frequency*mult + 2) * 0.49f + 0.5f);
			float blue  = Mathf.Abs (Mathf.Sin(frequency*mult + 4) * 0.49f + 0.5f);
			
			//Debug.Log (red + " " + green + " " + blue);
			Color newColor = new Color( red, green, blue);
			guiText.color = newColor;

		}
	}
}
