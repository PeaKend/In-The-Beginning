using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StoryText : MonoBehaviour {

	Text adventuretext;
	string textToprint;
	int storyLenght = 4;
	int numberofText = 0;
	public bool lost = false;

	private void Awake() {
		adventuretext = GetComponent<Text>();
		StartCoroutine(textController());
	}

	IEnumerator textController() {
		textToprint = textoftheStory[numberofText];
		yield return StartCoroutine(printText());

	}

	private void Update() {
		if (lost) {
			StopAllCoroutines();
			storyLenght = 0;
		}
	}

	IEnumerator printText() {
		for (int i = 0; i <= textToprint.Length; i++) {
			adventuretext.text = textToprint.Substring(0, i);
			yield return new WaitForSeconds(0.01F);
		}
		if (numberofText < storyLenght) {
			numberofText++;
			yield return new WaitForSeconds(1.0f);
			StartCoroutine(textController());
		}
		else {
			yield return new WaitForSeconds(4.0f);
			StartCoroutine(printdecisionText());
			yield return new WaitForSeconds(10.0f);
			GameObject.Find("Choice 1").GetComponent<Choice>().enabled = true;
			GameObject.Find("Choice 2").GetComponent<Choice>().enabled = true;
		}
		
	}

	IEnumerator printdecisionText() {
		adventuretext.text = "";
		yield return new WaitForSeconds(5.0f);
		textToprint = "You’re inside your room. The sun is shinning outside like it never did. The doors at the left and the right are open. What do you do?";
		StartCoroutine(printText());
		yield return new WaitForSeconds(2.0f);
		GetComponent<StaticStoryText>().enabled = true;
		GetComponent<StoryText>().enabled = false;
	}

	// Story:
	string[] textoftheStory = new string[]
	{
	"Before...", 
	"Before the 2 kingdoms entered in an endless war...",
	"Everything was beautiful and full of colors.",
	"But there is nothing now.",
	"Your mission, as Lord Ni, is to end the war and discover whom are causing it, recovering every precious tesoure you can."
	};

}
