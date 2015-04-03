using UnityEngine;
using System.Collections;

public class Virus_Plataforma : MonoBehaviour {

	Vector3 incremento;
	// Use this for initialization
	void Start () {
		incremento = new Vector3 (0.1f, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {

		if (transform.position.x >= 126) {
			//Debug.Log ("Debe de moverse a la derecha");
			//GetComponent<Transform> ().localPosition += new Vector3 (0.1f, 0, 0);
			incremento.x*= 1;	
			GetComponent<Transform>().localPosition += incremento;
		}

		if (transform.position.x >= 132) {
			//Debug.Log ("Debe de moverse a la izquierda");
			//GetComponent<Transform> ().localPosition += new Vector3 (0.1f, 0, 0);
			incremento.x *= -1;	
			GetComponent<Transform>().localPosition += incremento;
		}
}
}