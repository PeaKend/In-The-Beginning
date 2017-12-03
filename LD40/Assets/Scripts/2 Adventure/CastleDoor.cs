using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleDoor : MonoBehaviour {

	public void OpenDoor () {
		gameObject.transform.position += Vector3.up;
		Destroy(gameObject.GetComponent<Collider2D>());
	}
}
