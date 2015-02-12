using UnityEngine;
using System.Collections;

public class WorldManager : MonoBehaviour {

	private int worldChunkSize = 16;
	public static float distLoad = 8.0f;
	public static float distUnload = 16.0f;

	public Environmental[] environmentalPrefabs;
	public Collectable[] collectablePrefabs;
	public WorldChunk worldChunkPrefab;


	public GameObject playerObject;

	void Awake () {
		worldChunkPrefab.CreatePool ();
		for (int i = 0; i < environmentalPrefabs.Length; i++) {
			environmentalPrefabs[i].CreatePool();
		}
		for (int i = 0; i < collectablePrefabs.Length; i++) {
			collectablePrefabs[i].CreatePool();
		}
		collectablePrefabs [0].chewDebrisPrefab.CreatePool ();

	}

	void Start () {
		StartCoroutine (SpawnGrid ());

	}

	IEnumerator SpawnGrid () {
		for (int x = -(int)Literals.lWorldScale; x < Literals.lWorldScale; x += worldChunkSize*2) {
			for (int y = -(int)Literals.lWorldScale; y < Literals.lWorldScale; y += worldChunkSize*2) {
				worldChunkPrefab.Spawn (new Vector3 (x+16, y+16, 0));
			}
		}
		yield return 0;
	}
	
	
	void Update () {

	}
}
