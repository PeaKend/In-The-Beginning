using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaticStoryText : MonoBehaviour {

	void Update() {
		GetComponent<Text>().text = "You’re inside your room. The sun is shinning outside like it never did. The doors at the left and the right are open. What do you do?";	
	}
}
