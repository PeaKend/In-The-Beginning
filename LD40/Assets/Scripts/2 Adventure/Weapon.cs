using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

	bool iswithPlayer = false;
	public GameObject playerGameobject;
	void Start () {
		
	}
	
	void Update () {
		if (iswithPlayer) {
			transform.position = playerGameobject.transform.position;
		}
	}

	private void OnTriggerEnter2D(Collider2D other) {
		Debug.Log("asd");
		if (other.gameObject.tag == "Enemy") {
			other.GetComponent<Enemy>().enemyDie();
		}
		if (other.gameObject.tag == "Player") {
			iswithPlayer = true;
		}
	}
}
