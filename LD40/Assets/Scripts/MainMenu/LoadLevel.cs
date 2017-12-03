using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour {
	
	public bool PlayerReady = false;
	public AudioClip ReadyAudioClip;
	Text currentText;
	AudioSource audioSource;
	bool levelLoading = false;

	private void Awake() {
		currentText = gameObject.GetComponent<Text>();
		audioSource = gameObject.GetComponent<AudioSource>();
	}

	void Update () {
		if (PlayerReady) {
			currentText.text = "";
			StartCoroutine(loadLevel());
		}
	}

	IEnumerator loadLevel () {
		if (!levelLoading) {
			audioSource.PlayOneShot(ReadyAudioClip, 0.5f);
			levelLoading = true;
			yield return new WaitForSeconds(3.0f);
			SceneManager.LoadScene("1 StoryScene");
		}
	}
}
