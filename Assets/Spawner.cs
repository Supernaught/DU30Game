using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject[] _platforms;
	public static GameObject[] platforms;

	// Use this for initialization
	void Start () {
		platforms = _platforms;
		SpawnHere ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SpawnPlatformAt(Vector3 pos){
		GameObject platform = SimplePool.Spawn (platforms [0], pos + new Vector3(Random.Range(0,5f), Random.Range(-3f,3f), 0), Quaternion.identity) as GameObject;
		platform.GetComponent<Platform> ().spawner = this.gameObject;
	}

	public void SpawnHere(){
		SpawnPlatformAt (transform.position);
	}
}
