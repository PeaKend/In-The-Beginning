using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour {

	public float timebeforeFade;
	SpriteRenderer thisspriteRenderer;
	void Start () {
		thisspriteRenderer = GetComponent<SpriteRenderer>();
		StartCoroutine(fadeIn());
	}

	IEnumerator fadeIn() {
		yield return new WaitForSeconds(timebeforeFade);
		for (float i = 0.0f; i <= 1.0f; i = i + 0.2f) {
			thisspriteRenderer.color = new Color (1.0f, 1.0f, 1.0f, i);
			yield return new WaitForSeconds(0.5f);
		}
	}
}
