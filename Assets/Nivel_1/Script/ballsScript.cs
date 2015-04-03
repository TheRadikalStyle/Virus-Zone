using UnityEngine;
using System.Collections;

public class ballsScript : MonoBehaviour {

	private GameObject gos;
	private float velocidad = 4.5f;

	// Use this for initialization
	void Start () {
		gos  = GameObject.FindGameObjectWithTag("Player");
	}
	
	void FixedUpdate(){
		if(gos.GetComponent<PersonajeBehaviour>().facingRight){
		rigidbody2D.velocity = new Vector2(velocidad, rigidbody2D.velocity.y);
		}else{
			rigidbody2D.velocity = new Vector2(-velocidad, rigidbody2D.velocity.y);
		}
	}

	/*AL COLISIONAR CON VIRUS SE DESTRUYEN Y CONTABILIZAN*/
	/*Choque con Virus*/
	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Virus") {
			//Debug.Log ("Colision con Virus");
			gos.GetComponent<PersonajeBehaviour>().score += 15; //Contabilizando 15pts por cada Virus muerto
			Destroy(col.gameObject);
		}

		/*Choque con Virus Policia*/
		if (col.tag == "Police_Virus") {
			//Debug.Log ("Colision con Police_Virus");
			//scoreVirus = gos.GetComponent<PersonajeBehaviour>().score;
			//scoreVirus += 25;
			gos.GetComponent<PersonajeBehaviour>().score += 25; //25pts por cada Police_Virus muerto
			Destroy(col.gameObject);
		}
	}
}
