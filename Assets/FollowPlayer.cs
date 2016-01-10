using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

	public GameObject p;
	public Vector3 offset;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.position = Vector3.Lerp (transform.position,
			new Vector3(p.transform.position.x, p.transform.position.y, transform.position.z) + offset, 10 * Time.deltaTime);
	}
}
