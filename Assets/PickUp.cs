// ﻿using UnityEngine;
// using System.Collections;
//
// public class PickUp : MonoBehaviour {
// 	public GameObject Player;
// 	public float throwForce = 10;
// 	bool hasPlayer = false;
// 	// bool beingCarried = false;
//
// 	void OnTriggerEnter2D(Collider2D collider) {
// 		if (collider.tag == "Player")  {
// 			transform.parent = Player.transform;
// 		}
// 		// hasPlayer = true;
// 		// Debug.Log("We're touching!");
// 	}
//
// 	// void OnTriggerExit2D(Collider2D collider) {
// 	// 	hasPlayer = false;
// 	// 	Debug.Log("We're not touching!");
// 	// }
// 	//
// 	// void Start () {
// 	//
// 	// }
// 	//
// 	// Update is called once per frame
// 	void Update () {
// 		Transform player = Player.GetComponent<Transform>();
//
// 		if (!beingCarried) {
// 			if (Input.GetKey(KeyCode.B)) {
// 				GetComponent<Rigidbody2D>().isKinematic = false;
// 				transform.parent = null;
// 				GetComponent<Rigidbody2D>().AddForce(player.forward * throwForce);
// 				// beingCarried = false;
// 			}
// 		}
// 		else {
// 			if (Input.GetKey(KeyCode.B) && hasPlayer) {
// 				Debug.Log("B was pressed!");
// 				GetComponent<Rigidbody2D>().isKinematic = true;
// 				transform.parent = player;
// 				// beingCarried = true;
// 			} else if (Input.GetKey(KeyCode.B)) {
// 				GetComponent<Rigidbody2D>().isKinematic = false;
// 				transform.parent = null;
// 				GetComponent<Rigidbody2D>().AddForce(player.forward * throwForce);
//
// 			}
// 		}
// 	}
// }
