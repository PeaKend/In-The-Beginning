using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lose : MonoBehaviour {

	Text adventuretext;
	void Start () {
		adventuretext = GetComponent<Text>();
		adventuretext.text = "";
		eraseallText();
		StartCoroutine(asktoplayAgain());
	}

	void eraseallText() {
		Destroy(GetComponent<StoryText>());
		Destroy(GetComponent<StaticStoryText>());
		Destroy(GetComponent<Choice>());
		GameObject.Find("Choice 1").GetComponent<Choice>().enabled = false;
	}

	IEnumerator asktoplayAgain() {
		Destroy(GameObject.Find("Choice 1"));
		Destroy(GameObject.Find("Choice 2"));
		yield return new WaitForSeconds(2.0f);
		adventuretext.text = "YOU LOSE";
		yield return new WaitForSeconds(2.0f);
		adventuretext.text = "YOU LOSE\n\nPLAY AGAIN?";
		yield return new WaitForSeconds(2.0f);
		GameObject.Find("Choice 3").GetComponent<Choice>().enabled = true;
		GameObject.Find("Choice 4").GetComponent<Choice>().enabled = true;
	}

	public void starthardGames() {
		StartCoroutine(hardGames());
	}

	IEnumerator hardGames() {
		adventuretext.text = "";
		yield return new WaitForSeconds(3.0f);
		adventuretext.text = "GAMES WERE PRETTY HARD BACK THEN, HUH?";
		StartCoroutine(endLevel());
	}

	IEnumerator endLevel() {
		yield return new WaitForSeconds(5.0f);
		adventuretext.text = "";
	}

}
