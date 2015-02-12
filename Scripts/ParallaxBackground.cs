using UnityEngine;
using System.Collections;

public class ParallaxBackground : MonoBehaviour {
	public GameObject[] backgroundLayer;
	public float[] layerOffset;
	
	void Update () {

		for(int i = 0; i < backgroundLayer.Length; i++) {
			//backgroundLayer[i].transform.position = new Vector3(player.transform.position.x, player.transform.position.y, backgroundLayer[i].transform.position.z);
			backgroundLayer[i].renderer.material.SetTextureOffset("_MainTex", new Vector2(transform.position.x * layerOffset[i] % 1, transform.position.y * layerOffset[i] % 1));
		}
	}
}
