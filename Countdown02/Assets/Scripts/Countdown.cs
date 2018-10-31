using UnityEngine;
using System.Collections;

public class Countdown : MonoBehaviour {

	float timer = 5f;
	float multiplier = 0.6f;
	public AudioClip soundBlip;

	void Update (){
		if (timer > 0f){
			timer -= Time.deltaTime * multiplier;
		} else {
			timer = 0f;
			if(!isZeroBlinking) {
				StartCoroutine(ZeroBlink());
			}
		}
		
		if (timer < 10f) {
			GetComponent<TextMesh>().color = Color.red;
			multiplier = 0.6f;
		} else if (timer < 20f) {
			GetComponent<TextMesh>().color = Color.yellow;
			multiplier = 0.8f;
		} else {
			multiplier = 1.0f;
		}
		
		if (Mathf.Round(timer * 100) / 100 % 1f == 0 && timer > 0f) {
			GetComponent<AudioSource>().PlayOneShot(soundBlip);
			
			if (timer < 10f && timer > 0f) {
				if(!isBlinking) {
					StartCoroutine(Blink());
				}
			}
		}
		
		GetComponent<TextMesh>().text = timer.ToString("F2");
	}
	
	private bool isBlinking = false;
	private IEnumerator Blink() {
		isBlinking = true;
		float startScale = transform.localScale.x;
		transform.localScale = Vector3.one * startScale * 1.4f;
		yield return new WaitForSeconds(0.3f);
		transform.localScale = Vector3.one * startScale;
		isBlinking = false;
	}
	
	private bool isZeroBlinking = false;
	private IEnumerator ZeroBlink() {
		isZeroBlinking = true;
		GetComponent<Renderer>().enabled = false;
		yield return new WaitForSeconds(1.5f);
		GetComponent<Renderer>().enabled = true;
		yield return new WaitForSeconds(1.5f);
		isZeroBlinking = false;
	}
}
