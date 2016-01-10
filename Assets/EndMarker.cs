using UnityEngine;
using System.Collections;

public class EndMarker : MonoBehaviour {

	Transform platformDestroyer;

	void Start(){
		platformDestroyer = GameObject.Find ("PlatformDestroyer").transform;
	}

	void Update(){
		if (transform.position.x <= platformDestroyer.position.x) {
			
			SimplePool.Despawn (transform.parent.gameObject);
		}
	}
}
