using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public GameObject Enemy;
	int currentPosition = 1;
	float speed = 1.0f;
	
	void FixedUpdate () {
		translateAround();
	}

	void translateAround() {
		if (currentPosition == 1) {
			transform.Translate(Vector2.up * speed);
		}
		if (currentPosition == 2) {
			transform.Translate(Vector2.right * speed);
		}
		if (currentPosition == 3) {
			transform.Translate(Vector2.down * speed);
		}
		if (currentPosition == 4) {
			transform.Translate(Vector2.left * speed);
		}
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.name == "1") {
			currentPosition = 1;
		}
		if (other.gameObject.name == "2") {
			currentPosition = 2;
		}
		if (other.gameObject.name == "3") {
			currentPosition = 3;
		}
		if (other.gameObject.name == "4") {
			currentPosition = 4;
		}
	}

	public void SpawnEnemies() {
		StartCoroutine(spawn());
	}

	IEnumerator spawn() {
		Instantiate(Enemy, transform.position, Quaternion.identity);
		yield return new WaitForSeconds (Random.Range(1.0f, 3.0f));
		StartCoroutine(spawn());
	}
}
