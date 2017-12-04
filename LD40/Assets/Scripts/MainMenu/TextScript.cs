using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScript : MonoBehaviour {

	Text currentText;
	int iteration = 1;

	private void Awake() {
		currentText = gameObject.GetComponent<Text>();
		currentText.text = "IN THE BEGINNING...\n\n\nPress Any Key To Continue";
		startshowpressanykeyCoroutine();
	}

	private void Update() {
		checkKeys();
	}

	void startshowpressanykeyCoroutine () {
		StartCoroutine(showpressanyKey());
	}

	IEnumerator showpressanyKey () {
		yield return new WaitForSeconds(1.0f);
		if (iteration == 1) {
			currentText.text = "IN THE BEGINNING...\n\n\nPress Any Key To Continu_";
			iteration = 2;
		}
		else {
			currentText.text = "IN THE BEGINNING...\n\n\nPress Any Key To Continue";
			iteration = 1;
		}
		startshowpressanykeyCoroutine();
	}

	void checkKeys() {
		if(Input.anyKeyDown) {
			Destroy(GameObject.Find("MadeBy").gameObject);
			gameObject.GetComponent<LoadLevel>().PlayerReady = true;
			Destroy(this);
		}
	}
}
