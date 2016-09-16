using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	void Update () {
		Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
		if (screenPosition.x > Screen.width || screenPosition.x < 0 || screenPosition.y > Screen.height || screenPosition.y < 0)
		Destroy(this.gameObject);
	}
}
