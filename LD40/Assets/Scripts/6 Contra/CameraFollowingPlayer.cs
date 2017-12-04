using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraFollowingPlayer : MonoBehaviour {

	GameObject playerGameobject;
	private void Awake() {
		playerGameobject = GameObject.FindGameObjectWithTag("Player");
	}
	
	void FixedUpdate() {
		transform.position = new Vector3(playerGameobject.transform.position.x, playerGameobject.transform.position.y, transform.position.z);	
	}

	
}
