using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	public GameObject Player;

	void Update () {
		Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
		if (screenPosition.x > Screen.width || screenPosition.x < 0 || screenPosition.y > Screen.height || screenPosition.y < 0)
		Destroy(this.gameObject);
	}

	void OnTriggerEnter2D(Collider2D collider) {

		if (collider.gameObject.tag == "Player") {
			Player.GetComponent<CubeBehaviorScript>().health -= 1;
			Debug.Log(Player.GetComponent<CubeBehaviorScript>().health);
		}
	}
}
