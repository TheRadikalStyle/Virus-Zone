using UnityEngine;
using System.Collections;

public class CamaraSigueJugador : MonoBehaviour {

	public Transform personaje;
	private float separacion = 5f;
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (personaje.position.x + separacion, transform.position.y, transform.position.z);
	}
}
