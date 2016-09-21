using UnityEngine;
using System.Collections;

public class Grab : MonoBehaviour {
	public Transform HoldPoint;
	[HideInInspector] public bool grabbed;
	public float throwForce;
	private Transform Grabbable;
	[HideInInspector] public bool hasPlayer;

	void OnTriggerEnter2D(Collider2D collider) {

		//BASIC CODE TO PICK UP ON TOUCH
		// if (collider.tag == "Ball")  {
		// 	collider.transform.position = HoldPoint.position;
		// }

		if (collider.tag == "Grabbable")  {
			hasPlayer = true;
			Grabbable = collider.transform;
		}
	}

	void OnTriggerExit2D(Collider2D collider) {
		if (collider.tag == "Grabbable") {
			hasPlayer = false;
		}
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		// Rigidbody2D rigidBody = Grabbable.GetComponent<Rigidbody2D>();
		// if (Input.GetKey(KeyCode.B) && hasPlayer == true) {
		// 	Grabbable.transform.position = HoldPoint.position;
		// 	// rigidBody.gravityScale = 0;
		// 	// rigidBody.velocity = Vector2.zero;
		// 	rigidBody.isKinematic = true;
		// }

		Rigidbody2D rigidBody = Grabbable.GetComponent<Rigidbody2D>();
		CircleCollider2D circleCollider = Grabbable.GetComponent<CircleCollider2D>();

		if (Input.GetKey(KeyCode.DownArrow) && hasPlayer == true) { //Drops item to ground
			if (Input.GetKeyUp(KeyCode.B)) {
				rigidBody.isKinematic = false;
				circleCollider.isTrigger = false;
			}
		} else if (Input.GetKeyUp(KeyCode.B) && hasPlayer == true) { //Throws Item
			rigidBody.isKinematic = false;
			circleCollider.isTrigger = false;
			Grabbable.GetComponent<Rigidbody2D>().AddForce(Vector2.left * throwForce);
		}

		if (Input.GetKey(KeyCode.B) && hasPlayer == true) { //Picks up Item
			Grabbable.transform.position = HoldPoint.position;
			// rigidBody.gravityScale = 0;
			// rigidBody.velocity = Vector2.zero;
			rigidBody.isKinematic = true;
			circleCollider.isTrigger = true;
		}



	}
}
