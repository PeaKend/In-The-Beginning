using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {

	float bulletVelocity = 0.2f;

	void Start () {
		
	}
	
	void FixedUpdate () {
		transform.position += Vector3.left * bulletVelocity;
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			other.gameObject.GetComponent<Player>().PlayerDie();
		}
	}
}
