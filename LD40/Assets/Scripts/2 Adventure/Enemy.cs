using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public GameObject PlayerGameobject;
	public bool dead = false;
	float movementSpeed = 0.1f;

	void Start () {

	}
	
	void FixedUpdate () {
		if (!dead) {
			transform.position = Vector2.MoveTowards(transform.position, PlayerGameobject.transform.position, movementSpeed);
		} else {
			Debug.Log("dead");
		}
	}

	public void enemyDie() {
		dead = true;
	}
}
