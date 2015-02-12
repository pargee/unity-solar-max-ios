using UnityEngine;
using System.Collections;

public class ScaleFont : MonoBehaviour {
	public GUIText guiText;
	public float fontScale;

	
	void Start () {
		guiText.fontSize = Mathf.RoundToInt(Screen.width * fontScale);
	}
	
	
	void Update () {
	
	}
}
