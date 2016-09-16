
using UnityEngine;
using System.Collections;

public class CubeBehaviorScript : MonoBehaviour {

	[HideInInspector] public bool facingRight = true;
	[HideInInspector] public bool jump = true;

	public float moveForce;
	public float maxSpeed;
	public float jumpForce;
	public float friction;
	public Transform groundCheckLeft;
	public Transform groundCheckRight;

	private bool grounded = false;

	private Rigidbody2D rb2d;
	private Rigidbody2D wall;


	// Use this for initialization
	void Awake () {

		rb2d = GetComponent<Rigidbody2D>();

	}

	// Update is called once per frame
	void Update () {
		grounded = Physics2D.Linecast(transform.position, groundCheckLeft.position, 1 << LayerMask.NameToLayer("Ground")) ||
		Physics2D.Linecast(transform.position, groundCheckRight.position, 1 << LayerMask.NameToLayer("Ground"));

		if (Input.GetButtonDown("Jump") && grounded) {
			jump = true;
		}

	}

	void FixedUpdate() {
		float h = Input.GetAxis("Horizontal");

		if (rb2d.velocity.y > 0) {
			Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Ground"), true);
		} else {
			Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Ground"), false);
		}

		if (h * rb2d.velocity.x < maxSpeed)
		rb2d.AddForce(Vector2.right * h * moveForce);

		if (Mathf.Abs (rb2d.velocity.x) > maxSpeed)
		rb2d.velocity = new Vector2 (Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);

		if (jump) {
			rb2d.AddForce(new Vector2(0f, jumpForce));
			jump = false;
		}

		if(rb2d.velocity.y == 0 && !grounded) {
			Vector2 fallingVel = new Vector2(0, -5);
			rb2d.velocity = fallingVel;
		}

		if(Mathf.Abs(h) < 0.75) {
			Vector2 vel = rb2d.velocity;
			vel.x = rb2d.velocity.x * friction;
			rb2d.velocity = vel;
		}
	}
}
