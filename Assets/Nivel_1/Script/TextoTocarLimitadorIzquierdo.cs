using UnityEngine;
using System.Collections;

public class TextoTocarLimitadorIzquierdo : MonoBehaviour {

	public GameObject limi;

	void Start(){

	}

	void OnCollisionEnter2D(Collision2D coli){
		limi.GetComponentInChildren<GUIText>().enabled = true;
	}

	void OnCollisionExit2D(Collision2D coli){
		limi.GetComponentInChildren<GUIText>().enabled = false;
	}
	/*void OnCollisionEnter2D(Collision2D coli){
		this.GetComponentInChildren (GUIText).enabled = true;
	}

	void OnColiisionExit2D(Collision2D coli2){
		this.GetComponentInChildren (GUIText).enabled = false;
	}*/

}
