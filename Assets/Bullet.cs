using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	Rigidbody2D rb;
	public float movespeed;
	public int damage = 1;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();

//		rb.AddForce (new Vector2 (4000, 0));
	}

	void OnEnable(){
		RandomizeStartTransform ();

		if (IsInvoking()) {
			CancelInvoke ();
		}

		Invoke ("Die", 3);
	}
	
	// Update is called once per frame
	void Update () {
		rb.velocity = transform.right * movespeed * 60 * Time.deltaTime;
//		if (Mathf.Round(rb.velocity.x) == 0) {
//			Destroy (this.gameObject);
//		}
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Enemy") {
			col.gameObject.GetComponent<Attackable> ().Hit (damage);
			Die ();
		} else if (col.gameObject.tag == "Ground") {
			Die ();
		}
	}

	void Die(){
		SimplePool.Despawn (this.gameObject);
	}

	void RandomizeStartTransform(){
		float random = Random.Range (-4f, 4f);
		transform.position += (transform.up * (random * 0.1f)) + (transform.right * 1.5f);
		transform.Rotate (new Vector3 (0, 0, random));
	}
}
