using UnityEngine;
using System.Collections;

public class CoinsBehaviour : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col){
		Debug.Log ("Evento mostrado");
		if (col.tag == "Coins") {
			//score += 5;
			Destroy(gameObject);
		}
	}
}
