using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour {

	public GameObject enemyShot;
	public Transform enemyShotSpawn;
	public float fireRate;
	public float delay;

	public float speed;
	public GameObject Follower;
	public GameObject Player;

	private float nextFireTime;

	// Use this for initialization
	void Start () {

		InvokeRepeating("Fire", delay, fireRate);
		// nextFireTime = 0.0f;

	}

	void Fire () {
		GameObject shot = (GameObject) Instantiate(enemyShot, enemyShotSpawn.position, enemyShotSpawn.rotation);

		Transform follower = Follower.GetComponent<Transform>();
		Transform player = Player.GetComponent<Transform>();
		// float x = player.position.x - follower.position.y;
		// float y = player.position.x - follower.position.y;
		float x = follower.position.x - player.position.x;
		float y = follower.position.y - player.position.y;
		// float angle = Mathf.Atan2(y, x) * Mathf.Rad2Deg + 90;
		// follower.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

		Vector2 direction = new Vector2(-x, -y);
		direction.Normalize();
		shot.GetComponent<Rigidbody2D>().velocity = direction * speed;


	}

	// void Update() {
	// 	float currentTime = Time.time;
	// 	if(currentTime - nextFireTime > fireRate) {
	// 		nextFireTime = Time.time + fireRate;
	// 		Fire();
	// 	}
	// 	print(Player.GetComponent<Transform>().position);
	//
	// }
}
