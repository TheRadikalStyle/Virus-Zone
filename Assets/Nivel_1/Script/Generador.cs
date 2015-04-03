using UnityEngine;
using System.Collections;

public class Generador : MonoBehaviour {

	public GameObject[] obj;
	public float tiempoMin = 2f;
	public float tiempoMax = 4.5f;

	// Use this for initialization
	void Start () {
		//Generar();
		NotificationCenter.DefaultCenter ().AddObserver (this, "PersonajeEmpiezaACorrer");
	}

	//Metodo para cachar la noti y vincularla a otro metodo
	void PersonajeEmpiezaACorrer(Notification notificacion){
		Generar ();
	}


	void Generar(){
			Instantiate (obj [Random.Range (0, obj.Length)], transform.position, Quaternion.identity);
			Invoke ("Generar", Random.Range (tiempoMin, tiempoMax));
			Debug.Log ("Se estan creando bloques");
				
		}
}