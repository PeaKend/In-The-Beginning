using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	GameObject PlayerGameobject;
	public bool dead = false;
	float movementSpeed = 0.1f;

	private void Awake() {
		PlayerGameobject = GameObject.FindGameObjectWithTag("Player");
	}
	
	void FixedUpdate () {
		if (!dead) {
			transform.position = Vector2.MoveTowards(transform.position, PlayerGameobject.transform.position, movementSpeed);
		}
	}

	public void enemyDie() {
		Destroy(gameObject.GetComponent<Collider2D>());
		dead = true;
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			other.gameObject.GetComponent<PlayerMovement>().playerDie();
		}
	}
}
