using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO : MonoBehaviour {

	void Start () {
		
	}
	
	void FixedUpdate () {
		transform.Translate(Vector3.left * 0.2f);
	}
}
