using UnityEngine;
using System.Collections;

public class PasoNivel : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D Colision){
		if(Colision.gameObject.tag == "Player")
			Application.LoadLevel ("level1");
	}

}
