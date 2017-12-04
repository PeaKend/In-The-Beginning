using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

	bool iswithPlayer = false;
	bool doorOpened = false;
	public GameObject playerGameobject;
	void Start () {
		
	}
	
	void Update () {
		if (iswithPlayer) {
			transform.position = new Vector3 (playerGameobject.transform.position.x + 0.5f, playerGameobject.transform.position.y, -17.0f);
			if (!doorOpened) {
				doorOpened = true;
				GameObject.Find("CastleDoor").GetComponent<CastleDoor>().OpenDoor();
			}
		}
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Enemy") {
			other.GetComponent<Enemy>().enemyDie();
		}
		if (other.gameObject.tag == "Player") {
			iswithPlayer = true;
		}
	}
}
