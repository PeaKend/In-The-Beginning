﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StoryTell : MonoBehaviour {

	Text adventuretext;
	CanvasRenderer canvasRenderer;
	AudioSource audioSource;
	public AudioClip writingSound;
	public bool FadeWhenTextEnds;
	public float TimeBeforeFadeOut;
	public float WaitToBegin;
	bool begined;
	string textToprint;
	int storyLenght;
	int numberofText = 0;
	public string NextLevel;

	private void Awake() {
		adventuretext = gameObject.GetComponent<Text>();
		adventuretext.text = "";
		canvasRenderer = gameObject.GetComponent<CanvasRenderer>();
		audioSource = gameObject.GetComponent<AudioSource>();
		storyLenght = textoftheStory.GetLength(0) - 1;
		StartCoroutine(textController());
	}

	private void Update() {
		endingController();
	}

	IEnumerator textController() {
		if (!begined) {
			yield return new WaitForSeconds(WaitToBegin);
		}
		textToprint = textoftheStory[numberofText];
		yield return StartCoroutine(printText());
	}

	IEnumerator printText() {
		for (int i = 0; i <= textToprint.Length; i++) {	
			adventuretext.text = textToprint.Substring(0, i);
			audioSource.PlayOneShot(writingSound, 0.2f);
			yield return new WaitForSeconds(0.05F);
		}
		if (numberofText == storyLenght) {
			StartCoroutine(fadeoutController());
		}
		if (numberofText < storyLenght) {
			numberofText++;
			yield return new WaitForSeconds(1.0f);
			StartCoroutine(textController());
		}
	}

	IEnumerator fadeoutController() {
		yield return new WaitForSeconds(TimeBeforeFadeOut);
		StartCoroutine(fadeOut());
	}

	IEnumerator fadeOut() {
		for (float i = 1.0f; i >= 0.0f; i = i - 0.1f) {
			canvasRenderer.SetColor(new Color (i, i, i, i));
			yield return new WaitForSeconds(0.25f);
		}
		StartCoroutine(loadLevel());
	}

	IEnumerator loadLevel() {
		yield return new WaitForSeconds(2.0f);
		SceneManager.LoadScene(NextLevel);
	}

	void endingController() {
		if (SceneManager.GetActiveScene().name == "9 Ending") {
			if (numberofText == 7) {
				StartCoroutine(waitandquitGame());
			}
		}	
	}

	IEnumerator waitandquitGame() {
		yield return new WaitForSeconds(8.0f);
		Application.Quit();
	}

	public string[] textoftheStory = new string[]
	{
	};
}
