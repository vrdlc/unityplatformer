using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {
	public Transform player;
	public Vector3 offset;
	public float delay;

	void Start () {

	}

	void Update () {
	transform.position = new Vector3 (player.position.x + offset.x, player.position.y + offset.y, offset.z);

	//Moves Camera Down when DownArrow is held for x seconds
	if (Input.GetKey(KeyCode.DownArrow)) {
		StartCoroutine(Delay());
	}

	}
	//Delays camera panning down for x seconds
	IEnumerator Delay() {
		yield return new WaitForSeconds(delay);
		transform.position = new Vector3 (player.position.x + offset.x, player.position.y + offset.y - 6, offset.z);
		yield break;
	}
}
