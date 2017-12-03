using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {

	private void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			other.gameObject.GetComponent<PlayerMovement>().teleport();
			GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>().SpawnEnemies();
		}
	}
}
