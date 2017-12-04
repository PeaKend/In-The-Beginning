using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public GameObject PlayerWeapon;
	Animator animator;
	Rigidbody2D playerrigidBody;
	AudioSource audioSource;
	public AudioClip ExplosionClip;
	float maxhorizontalVelocity = 10.0f;
	float jumpForce = 10.0f;
	float playerMovement = 0.2f;
	bool jumped = false;

	void Start () {
		playerrigidBody = GetComponent<Rigidbody2D>();
		audioSource = GetComponent<AudioSource>();
		animator = GetComponent<Animator>();
	}
	
	void Update () {
		playerhorizontalMovement();
		playerjumpMovement();
	}

	void playerhorizontalMovement () {
		if (Input.GetAxisRaw("Horizontal") != 0.0f) {
			animator.SetBool("Moving", true);
			playerrigidBody.AddForce(new Vector2 (Input.GetAxisRaw("Horizontal") * 10.0f, 0.0f));
		} else {
			animator.SetBool("Moving", false);
		}
		controlhorizontalVelocity();
	}

	void controlhorizontalVelocity () {
		if (Mathf.Abs(playerrigidBody.velocity.x) > maxhorizontalVelocity) {
			if (playerrigidBody.velocity.x > 0.0f) {
				playerrigidBody.velocity = new Vector2 (maxhorizontalVelocity, playerrigidBody.velocity.y);
				gameObject.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
			} else {
				playerrigidBody.velocity = new Vector2 (-maxhorizontalVelocity, playerrigidBody.velocity.y);
				gameObject.transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
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
		audioSource.PlayOneShot(ExplosionClip, 0.3f);
		GameObject.Find("Controller").GetComponent<EndLevel>().ExecuteEndLevel();
		Destroy(gameObject);
	}

	private void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "Floor") {
			jumped = false;
		}
	}
}
