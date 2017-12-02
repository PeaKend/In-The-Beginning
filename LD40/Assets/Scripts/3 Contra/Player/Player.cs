using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	Rigidbody2D playerrigidBody;
	float maxhorizontalVelocity = 5.0f;
	float jumpForce = 10.0f;
	float playerMovement = 0.1f;
	bool jumped = false;

	void Start () {
		playerrigidBody = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
		playerhorizontalMovement();
		playerjumpMovement();
	}

	void playerhorizontalMovement () {
		if (Input.GetAxisRaw("Horizontal") != 0.0f) {
			playerrigidBody.AddForce(new Vector2 (Input.GetAxisRaw("Horizontal") * 10.0f, 0.0f));
		}
		controlhorizontalVelocity();
	}

	void controlhorizontalVelocity () {
		if (Mathf.Abs(playerrigidBody.velocity.x) > maxhorizontalVelocity) {
			if (playerrigidBody.velocity.x > 0.0f) {
				playerrigidBody.velocity = new Vector2 (maxhorizontalVelocity, playerrigidBody.velocity.y);
			} else {
				playerrigidBody.velocity = new Vector2 (-maxhorizontalVelocity, playerrigidBody.velocity.y);
			}
		}
	}

	void playerjumpMovement () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			if (!jumped) {
				jumped = true;
				playerrigidBody.AddForce(new Vector2(0.0f, jumpForce), ForceMode2D.Impulse);
			}
		}
	}

	public void PlayerDie () {
		Destroy(gameObject);
	}

	private void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "Floor") {
			jumped = false;
		}
	}
}
