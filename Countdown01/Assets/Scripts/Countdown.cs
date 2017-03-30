using UnityEngine;
using System.Collections;

public class Countdown : MonoBehaviour {

	float timer = 120f;

	void Update (){
		if (timer > 0f){
			timer -= Time.deltaTime;
		} else {
			timer = 0f;
		}
		
		if (timer < 10f) {
			GetComponent<TextMesh>().color = Color.red;
		} else if (timer < 20f) {
			GetComponent<TextMesh>().color = Color.yellow;
		}
		
		GetComponent<TextMesh>().text = timer.ToString("F2");
	}
}
