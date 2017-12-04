using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {

	public bool ShootRight;
	public bool ShootLeft;

	void FixedUpdate() {
		if (ShootRight) {
			transform.position += Vector3.right * 0.2f;
		}
		if (ShootLeft) {
			transform.position += Vector3.left * 0.2f;
		}
	}
	private void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			other.gameObject.GetComponent<Player>().PlayerDie();
		}
	}
}
