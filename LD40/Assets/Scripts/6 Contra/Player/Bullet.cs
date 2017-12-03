using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	float bulletVelocity = 0.2f;

	void Start () {
		
	}
	
	void FixedUpdate () {
		transform.position += Vector3.right * bulletVelocity;
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Enemy") {
			other.gameObject.GetComponent<EnemyContra>().EnemyDie();
		}
	}
}
