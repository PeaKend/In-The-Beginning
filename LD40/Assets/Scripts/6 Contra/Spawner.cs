using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject Enemy;

	private void Awake() {
		callspawnEnemies();
	}

	void callspawnEnemies() {
		StartCoroutine(spawnEnemies());
	} 

	IEnumerator spawnEnemies() {
		yield return new WaitForSeconds(Random.Range(2.0f, 10.0f));
		Instantiate(Enemy, transform.position, Enemy.transform.rotation);
		callspawnEnemies();
	}
}
