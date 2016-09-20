using UnityEngine;
using System.Collections;

public class Grab : MonoBehaviour {
	public Transform HoldPoint;
	public bool grabbed;
	public float throwForce;
	private Transform Grabbable;
	public bool hasPlayer;

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
		hasPlayer = false;
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

		if (Input.GetKeyUp(KeyCode.B)) {
			rigidBody.isKinematic = false;
			Grabbable.transform.position = Grabbable.transform.position;
		}
		if (Input.GetKey(KeyCode.B)) {
			Grabbable.transform.position = HoldPoint.position;
			// rigidBody.gravityScale = 0;
			// rigidBody.velocity = Vector2.zero;
			rigidBody.isKinematic = true;
		}


	}
}
