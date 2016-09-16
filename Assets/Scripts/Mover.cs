using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {
	Rigidbody2D rb;
	// public float speed;
	// public Transform Follower;
	// public Transform Player;
	public GameObject Follower;
	public GameObject Player;


	// Use this for initialization
	void Start () {
		// rb = GetComponent<Rigidbody2D>();
		// Transform follower = Follower.GetComponent<Transform>();
		// Transform player = Player.GetComponent<Transform>();
		//
		// // float x = player.position.x - follower.position.y;
		// // float y = player.position.x - follower.position.y;
		// float x = follower.position.x - player.position.x;
		// float y = follower.position.y - player.position.y;
		// float angle = Mathf.Atan2(y, x) * Mathf.Rad2Deg + 90;
		// Debug.Log(angle);
		// follower.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
		//
		// rb.velocity = new Vector2(x, y) * speed;

		//Trying to get angle gun is pointing at player so it can shoot. Need to calculate or recalculate angle

	}

	void Update () {
	}
}

//Looking into how to fire shot at target. Currently line 11 instantiates shots + 2y, then they fall.
