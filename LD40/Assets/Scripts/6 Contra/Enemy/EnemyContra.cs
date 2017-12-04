using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyContra : MonoBehaviour {

	public GameObject EnemyBullet;
	AudioSource audioSource;
	public AudioClip EnemyShootClip;

	void Start () {
		audioSource = GetComponent<AudioSource>();
		StartCoroutine(shootinFront());
	}
	
	void FixedUpdate () {
		transform.position = Vector2.MoveTowards(transform.position, GameObject.Find("Player").transform.position, 0.1f);
	}

	public void EnemyDie() {
		Destroy(gameObject);
	}

	 IEnumerator shootinFront() {
		 audioSource.PlayOneShot(EnemyShootClip, 0.3f);
		 yield return new WaitForSeconds(0.5f);
		 Instantiate(EnemyBullet, transform.position, Quaternion.identity);
		 StartCoroutine(shootinFront());
	 }
}
