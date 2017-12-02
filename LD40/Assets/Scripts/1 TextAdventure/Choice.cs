using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Choice : MonoBehaviour {

	Text choiceText;
	public GameObject GameText;
	public bool choosen;
	public int choice;
	private void Awake() {
		choiceText = GetComponent<Text>();

		if (choice == 1) {
			choosen = true;
			choiceText.text = "Let's go to the right.";	
		}

		if (choice == 2) {
			choiceText.text = "Let's go to the left.";
		}
		if (choice == 3) {
			choosen = true;
			choiceText.text = "NO";	
		}

		if (choice == 4) {
			choiceText.text = "NO";
		}
	}

	private void Update() {
		if (choosen == true) {
			choiceText.color = Color.blue;
		} else {
			choiceText.color = Color.green;
		}
		if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow)) {
			if (choosen == true) {
				choosen = false;
			} else {
				choosen = true;
			}
		}
		if (Input.GetKeyDown(KeyCode.Return)) {
			GameObject.Find("Text").GetComponent<Lose>().enabled = true;
			if (gameObject.name == "Choice 3" || gameObject.name == "Choice 4") {
				GameText.GetComponent<Lose>().starthardGames();
				Destroy(gameObject);
			}
		}
	}
}
