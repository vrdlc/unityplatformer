using UnityEngine;
using System.Collections;

public class FollowerBehaviorScript : MonoBehaviour {

	[HideInInspector] public Vector2 cubePos;
	[HideInInspector] public Vector2 cylinderPos;
	[HideInInspector] public float angle;

	public Transform trackingObject;
	public Transform trackedObject;

	private float nextFire;
	private float fireRate;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		float x = trackingObject.position.x - trackedObject.position.x;
		float y = trackingObject.position.y - trackedObject.position.y;
		angle = Mathf.Atan2(y, x) * Mathf.Rad2Deg + 90;

		trackingObject.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
	}

	public float getAngle() {
		return angle;
	}
}
