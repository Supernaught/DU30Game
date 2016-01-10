using UnityEngine;
using System.Collections;

public class DestroyOffCam : MonoBehaviour {

	Transform platformDestroyer;

	void Start(){
		platformDestroyer = GameObject.Find ("PlatformDestroyer").transform;
	}

	// Update is called once per frame
	void Update () {
		if (transform.position.x <= platformDestroyer.position.x) {
			SimplePool.Despawn (this.gameObject);
		}
	}
}
