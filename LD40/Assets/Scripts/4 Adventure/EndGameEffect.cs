using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameEffect : MonoBehaviour {

	AudioSource audioSource;
	public AudioClip explosionClip;

	private void Awake() {
		audioSource = GetComponent<AudioSource>();
	}

	public void startendgameEffect() {
		audioSource.PlayOneShot(explosionClip, 0.3f);
		StartCoroutine(endgameEffect());
		StartCoroutine(loadLevel());
	}

	IEnumerator endgameEffect() {
		yield return new WaitForSeconds(0.1f);
		transform.position = new Vector3(transform.position.x, transform.position.y, 0.0f);
		yield return new WaitForSeconds(0.1f);
		transform.position = new Vector3(transform.position.x, transform.position.y, -6.0f);
		startendgameEffect();
	}

	IEnumerator loadLevel() {
		yield return new WaitForSeconds(4.0f);
		SceneManager.LoadScene("5 StoryScene");
	}

}
