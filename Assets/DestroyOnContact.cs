using UnityEngine;
using System.Collections;

public class DestroyOnContact : MonoBehaviour {

	public GameObject Player;
	public int healthValue;

	void Start () {

	}

	int OnTriggerEnter (Collider other) {
		if (healthValue > 0 && other.tag == "Shot") {
			return healthValue - 1;
		}

		if (other.tag == "Boundary") {
			return healthValue = 0;
		}

		else {
			return healthValue = 100;
		}
		Debug.Log(healthValue);
}

void DestroyPlayer() {
		if (healthValue == 0) {
			Destroy(Player);
		}
	}

}
