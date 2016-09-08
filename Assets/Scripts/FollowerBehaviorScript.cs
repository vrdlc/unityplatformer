using UnityEngine;
using System.Collections;

public class FollowerBehaviorScript : MonoBehaviour {

	[HideInInspector] public Vector2 cubePos;
	[HideInInspector] public Vector2 cylinderPos;

	public Transform trackingObject;
	public Transform trackedObject;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		float x = trackingObject.position.x - trackedObject.position.x;
		float y = trackingObject.position.y - trackedObject.position.y;

		// Vector2 cubePos = new Vector2(trackedObject.position.x, trackedObject.position.y);
		// Vector2 cylinderPos = new Vector2(trackingObject.position.x, trackedObject.position.y);
		float angle = Mathf.Atan2(y, x) * Mathf.Rad2Deg + 90;
		Debug.Log(angle);
		trackingObject.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

	}
}


// Vector3 mousePos = Input.mousePosition;
// mousePos.z = 5.23f;
//
// Vector3 objectPos = Camera.main.WorldToScreenPoint (transform.position);
// mousePos.x = mousePos.x - objectPos.x;
// mousePos.y = mousePos.y - objectPos.y;
//
// float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
// transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
