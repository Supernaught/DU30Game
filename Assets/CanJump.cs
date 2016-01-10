using UnityEngine;
using System.Collections;

public class CanJump : MonoBehaviour {
	private Rigidbody2D rb;

	// Jump Stuff
	public bool canJump;
	public float jumpForce = 1000;
	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	public bool grounded;

	public float DEFAULT_GRAVITY_SCALE;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();

		canJump = true;

		DEFAULT_GRAVITY_SCALE = rb.gravityScale;
	}

	void FixedUpdate(){
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void Jump(){
		if (canJump) {
			if (rb.velocity.y <= 0) {
				rb.velocity = new Vector2 (rb.velocity.x, 0);
			}
			rb.AddForce(new Vector2(0,jumpForce));	
			canJump = false;
		}
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Ground") {
			canJump = true;
		}
	}
}
