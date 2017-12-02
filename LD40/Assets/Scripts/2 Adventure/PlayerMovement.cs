using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	float movementSpeed = 0.1f;
	
	void FixedUpdate () {
		transform.position += new Vector3 (Input.GetAxisRaw("Horizontal") * movementSpeed, Input.GetAxisRaw("Vertical") * movementSpeed);
	}
}
