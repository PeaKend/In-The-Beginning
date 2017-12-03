using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public AudioClip movementSound;
	AudioSource audioSource;
	public GameObject Camera2;
	bool soundbeingPlayed = false;
	float movementSpeed = 0.1f;
	
	private void Awake() {
		audioSource = GetComponent<AudioSource>();
	}

	void FixedUpdate () {
		if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.0f || Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.0f) {
			transform.position += new Vector3 (Input.GetAxisRaw("Horizontal") * movementSpeed, Input.GetAxisRaw("Vertical") * movementSpeed);
			playmovementSound();
		} else {
			StopCoroutine(playSound());
		}
	}

	void playmovementSound () {
		if (!soundbeingPlayed) {
			StartCoroutine(playSound());
		}
	}

	IEnumerator playSound () {
		audioSource.PlayOneShot(movementSound, 0.5f);
		soundbeingPlayed = true;
		yield return new WaitForSeconds(0.5f);
		soundbeingPlayed = false;
	}

	public void playerDie () {
		Destroy(gameObject);
	} 

	public void teleport () {
		transform.position = GameObject.Find("TeleportPoint").transform.position;
		GameObject.Find("Camera1").SetActive(false);
		Instantiate(Camera2);
	}

}
