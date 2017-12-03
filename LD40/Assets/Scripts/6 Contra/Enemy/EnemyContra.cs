using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyContra : MonoBehaviour {

	void Start () {
		StartCoroutine(shootinFront());
	}
	
	void Update () {
		
	}

	public void EnemyDie() {
		Destroy(gameObject);
	}

	 IEnumerator shootinFront() {
		 yield return new WaitForSeconds(0.5f);
		 Debug.Log("SHOOT!");
		 StartCoroutine(shootinFront());
	 }
}
