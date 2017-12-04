using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour {

	AudioSource audioSource;
	public AudioClip ExplosionClip;

	private void Awake() {
		audioSource = GetComponent<AudioSource>();
	}
	public void ExecuteEndLevel() {
		StartCoroutine(endLevel());
	}

	IEnumerator endLevel() {
		audioSource.PlayOneShot(ExplosionClip, 0.3f);
		yield return new WaitForSeconds(3.0f);
		SceneManager.LoadScene("7 StoryScene");
	}
}
