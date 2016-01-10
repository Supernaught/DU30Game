using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour {

	public GameObject spawner;
	bool hasSpawnedNext = false;

	public GameObject enemy;
	public Vector3 endPosition;

	void Start(){
//		Spawner.SpawnPlatformAt(
	}

	void Update () {
		if (!hasSpawnedNext && spawner != null && transform.position.x <= spawner.transform.position.x) {
			spawner.GetComponent<Spawner> ().SpawnPlatformAt (GetEndPosition ());
			hasSpawnedNext = true;
		}
	}

	public Vector3 GetEndPosition(){
		return endPosition;
	}

	void OnEnable(){
		endPosition = GetComponentInChildren<EndMarker> ().transform.position;	
		SimplePool.Spawn(enemy, new Vector3(Random.Range(transform.position.x, GetEndPosition().x),0,0), Quaternion.identity);
		hasSpawnedNext = false;
	}
}
