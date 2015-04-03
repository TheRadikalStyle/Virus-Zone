using UnityEngine;
using System.Collections;

public class SpawnBallsDestruction : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy (gameObject, 2.5f);
	}

	void OnCollisionEnter2D(Collision2D coli){
		if(coli.gameObject.tag== "Virus"){
			Debug.Log ("Colision con virus");
			Destroy (gameObject);
		}
	}
}
