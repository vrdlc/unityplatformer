
using UnityEngine;
using System.Collections;

public class CubeBehaviorScript : MonoBehaviour {

	[HideInInspector] public bool facingRight = true;
	[HideInInspector] public bool jump = true;
	[HideInInspector] public bool wallJump;

	public float moveForce;
	public float jumpForce;
	public float aerialForce;
	public float maxSpeed;
	public float maxSlideSpeed;
	public float friction;
	public Transform groundCheckLeft;
	public Transform groundCheckRight;
	public Transform wallCheckLeft;
	public Transform wallCheckRight;
	public float health;

	private bool grounded = false;
	private bool sliding = false;
	private bool slidingRight;
	private bool walljumping = false;
	private Rigidbody2D rb2d;

	void Awake () {
		rb2d = GetComponent<Rigidbody2D>();
		health = 5;
	}

	void Update () {
		grounded = Physics2D.Linecast(transform.position, groundCheckLeft.position, 1 << LayerMask.NameToLayer("Ground")) ||
		Physics2D.Linecast(transform.position, groundCheckRight.position, 1 << LayerMask.NameToLayer("Ground"));

		sliding = (Physics2D.Linecast(transform.position, wallCheckRight.position, 1 << LayerMask.NameToLayer("Wall")) || Physics2D.Linecast(transform.position, wallCheckLeft.position, 1 << LayerMask.NameToLayer("Wall"))) && !grounded;

		if (sliding) {
			slidingRight = Physics2D.Linecast(transform.position, wallCheckRight.position, 1 << LayerMask.NameToLayer("Wall"));
		}

		if (Input.GetButtonDown("Jump") && grounded) {
			jump = true;
		}
	}

	void FixedUpdate() {
		float h = 0;

		if (grounded || sliding) {
			walljumping = false;
		}

		//Should make character rotate
		h = Input.GetAxis("Horizontal");
		if (Input.GetKeyDown(KeyCode.RightArrow)){
			if(transform.rotation != Quaternion.Euler(0, 180, 0))
			transform.rotation = Quaternion.Euler(0, 180, 0);
		}

		if (Input.GetKeyDown(KeyCode.LeftArrow)){
			if(transform.rotation != Quaternion.Euler(0, 0, 0))
			transform.rotation = Quaternion.Euler(0, 0, 0);
		}


		if (h * rb2d.velocity.x < maxSpeed) {
			if (walljumping) {
				rb2d.AddForce(Vector2.right * h * aerialForce);
			} else {
				rb2d.AddForce(Vector2.right * h * moveForce);
			}
		}

		if (Mathf.Abs(rb2d.velocity.x) > maxSpeed) {
			rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);
		}

		if (rb2d.velocity.y > maxSpeed) {
			rb2d.velocity = new Vector2(rb2d.velocity.x, maxSpeed);
		}

		if (sliding) {
			if (rb2d.velocity.y < -maxSlideSpeed) {
				Vector2 vel = rb2d.velocity;
				vel.y = -maxSlideSpeed;
				rb2d.velocity = vel;
			}

			if (Input.GetButtonDown("Jump")) {
				if (slidingRight) {
					rb2d.AddForce(new Vector2(-jumpForce, jumpForce));
				} else {
					rb2d.AddForce(new Vector2(jumpForce, jumpForce));
				}
				walljumping = true;
			}
		}

		if (jump) {
			rb2d.AddForce(new Vector2(0f, jumpForce));
			jump = false;
		}

		if (rb2d.velocity.y > 0) {
			Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Ground"), true);
		} else {
			Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Ground"), false);
		}

		if(Mathf.Abs(h) < 0.75 && grounded) {
			Vector2 vel = rb2d.velocity;
			vel.x = rb2d.velocity.x * friction;
			rb2d.velocity = vel;
		}
	}
}
