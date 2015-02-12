using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WorldChunk : MonoBehaviour {
	private float distance;
	private WorldManager worldManager;
//	private GameObject playerObject;
//	public Environment[] environmentPrefabs;
//	public Collectable[] collectablePrefabs;
	public float spawnRadius;
	public bool enteredRadius = false;

	List<Environmental> environmentalPointers = new List<Environmental>();
	List<Collectable> collectablePointers = new List<Collectable>();

	
	void Awake (){
//		for (int i = 0; i < environmentPrefabs.Length; i++) {
//			environmentPrefabs[i].CreatePool();
//		}
//		for (int i = 0; i < collectablePrefabs.Length; i++) {
//			collectablePrefabs[i].CreatePool();
//		}
		worldManager = GameObject.FindGameObjectWithTag ("WorldManager").GetComponent<WorldManager>();

	}

	void Start () {
		//playerObject = GameObject.FindGameObjectWithTag ("Player");
	}
	
	
	void Update () {

	}

	void OnTriggerStay2D(Collider2D other) {
		if (other.tag == "Player" && !enteredRadius) {
			float distance = Vector3.Distance(other.gameObject.transform.position, transform.position);
			if (distance < 20.0f) {
				Debug.Log ("SPAWNING");
				int environmentalSpawnCount = Random.Range (50, 100);
				int collectableSpawnCount = Random.Range (50, 70);

				for (int i = 0; i < environmentalSpawnCount; i++) {
					Environmental environmentalPrefabPointer = worldManager.environmentalPrefabs[Random.Range (0, worldManager.environmentalPrefabs.Length)]
															.Spawn (new Vector3(Random.Range ((transform.localPosition.x-spawnRadius), 
					                                  		(transform.localPosition.x+spawnRadius)), Random.Range ((transform.localPosition.y-spawnRadius), 
					                                        (transform.localPosition.y+spawnRadius)), 0.0f), Quaternion.Euler (0, 0, Random.Range (0, 360)));

					environmentalPointers.Add (environmentalPrefabPointer);
				}
				for (int i = 0; i < collectableSpawnCount; i++) {
					Collectable collectablePrefabPointer = worldManager.collectablePrefabs[Random.Range (0, worldManager.collectablePrefabs.Length)]
															.Spawn (new Vector3(Random.Range ((transform.localPosition.x-spawnRadius), (transform.localPosition.x+spawnRadius)), 
					                    					Random.Range ((transform.localPosition.y-spawnRadius), (transform.localPosition.y+spawnRadius)), 0.0f), 
					        								Quaternion.Euler (0, 0, Random.Range (0, 360)));
					collectablePointers.Add (collectablePrefabPointer);
				}
				enteredRadius = true;
			}
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.tag == "Player") {
			enteredRadius = false;
			for (int i = 0; i < environmentalPointers.Count; i++) {
				environmentalPointers[i].Recycle ();
			}
			for (int i = 0; i < collectablePointers.Count; i++) {
				collectablePointers[i].Recycle ();
			}
			environmentalPointers.Clear ();
			collectablePointers.Clear ();
			
		}
	}
}
