using UnityEngine;
using System.Collections;

public class TheRadikalSoftware : MonoBehaviour {

	public float timer = 4f; //Tiempo de carga
	public string levelToLoad = "VirusZone"; // Nivel a cargar

	// Use this for initialization
	void Start () {
		StartCoroutine ("DisplayScene");
	}
	
	IEnumerator DisplayScene(){
		yield return new WaitForSeconds (timer);
		Application.LoadLevel (levelToLoad);
		Destroy (this);
	}
}
