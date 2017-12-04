using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

	public GameObject PlayerBR;
	public GameObject PlayerBL;
	AudioSource audioSource;
	public AudioClip ShootClip;
	bool canShoot = true;

	private void Awake() {
		audioSource = GetComponent<AudioSource>();
	}
	
	void Update () {
		if (Input.GetKey(KeyCode.LeftControl) && canShoot) {
			StartCoroutine(shootandWait());
		}
	}

	IEnumerator shootandWait () {
		if (canShoot) {
			audioSource.PlayOneShot(ShootClip, 0.3f);
			if (gameObject.transform.rotation.y == 0.0f) {
				Instantiate(PlayerBR, transform.position, Quaternion.identity);
			} else {
				Instantiate(PlayerBL, transform.position, Quaternion.identity);
			}
		}
		canShoot = false;
		yield return new WaitForSeconds(0.5f);
		canShoot = true;
	}

}
