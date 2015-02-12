using UnityEngine;
using System.Collections;

public class RandomSpawn : MonoBehaviour {
	public GameObject[] spawnObject;
	public int spawnCount = 1000;

	
	void Start () {


		for(int i = 0; i < spawnCount; i++) {
			Instantiate(spawnObject[Random.Range(0,spawnObject.Length)], new Vector3(Random.Range (-Literals.lWorldScale, Literals.lWorldScale), Random.Range (-Literals.lWorldScale, Literals.lWorldScale), 0.0f), Quaternion.Euler (0, 0, Random.Range (0, 360)));	

		}

	}
	
	
	void Update () {
	
	}
}
