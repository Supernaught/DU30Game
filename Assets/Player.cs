using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	private Rigidbody2D rb;

	// Movement
	public float movespeed;
	private CanJump jumper;
	private CanShoot shooter;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();

		jumper = GetComponent<CanJump> ();
		shooter = GetComponent<CanShoot> ();
	}
	
	// Update is called once per frame
	void Update () {
		rb.velocity = new Vector2 (movespeed, rb.velocity.y);
		Debug.Log (rb.velocity.y);
		Controls ();
	}

	void Controls(){
		// Shooting
		if (Input.GetKey (KeyCode.X)) {
			shooter.Shoot (transform.position, Quaternion.Euler(new Vector3(0,0,0)));
		}

		// Jump
		if (Input.GetKey (KeyCode.Space) || Input.GetKey(KeyCode.Z)) {
			if (jumper.canJump) {
				jumper.Jump ();
			} else {
				rb.gravityScale = jumper.DEFAULT_GRAVITY_SCALE / 2.5f;
			}
		} else {
			rb.gravityScale = jumper.DEFAULT_GRAVITY_SCALE;
		}
	}
}
