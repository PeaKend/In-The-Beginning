using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public bool ShootLeft;
	public bool ShootRight;
	float bulletVelocity = 0.5f;

	void Start () {
		
	}
	
	void FixedUpdate () {
		if (ShootRight) {
			transform.position += Vector3.right * bulletVelocity;
		}
		if (ShootLeft) {
			transform.position += Vector3.left * bulletVelocity;
		}
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Enemy") {
			other.gameObject.GetComponent<EnemyContra>().EnemyDie();
		}
	}
}
